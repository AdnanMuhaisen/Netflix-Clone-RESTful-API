﻿using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Netflix_Clone.Application.Services.IServices;
using Netflix_Clone.Domain;
using Netflix_Clone.Domain.DTOs;
using Netflix_Clone.Domain.Entities;
using Netflix_Clone.Domain.Exceptions;
using Netflix_Clone.Infrastructure.DataAccess.Commands;
using Netflix_Clone.Infrastructure.DataAccess.Data.Contexts;
using System.Text;

namespace Netflix_Clone.Infrastructure.DataAccess.Handlers
{
    public class AddNewMovieCommandHandler : IRequestHandler<AddNewMovieCommand, ApiResponseDto>
    {
        private readonly ILogger<AddNewMovieCommandHandler> logger;
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IOptions<ContentMovieOptions> contentOptions;
        private readonly IFileManager fileManager;

        public AddNewMovieCommandHandler(ILogger<AddNewMovieCommandHandler> logger,
            ApplicationDbContext applicationDbContext,
            IOptions<ContentMovieOptions> contentOptions,
            IFileManager fileManager)
        {
            this.logger = logger;
            this.applicationDbContext = applicationDbContext;
            this.contentOptions = contentOptions;
            this.fileManager = fileManager;
        }

        public async Task<ApiResponseDto> Handle(AddNewMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = request.movieToInsertDto.Adapt<Movie>();

            if (movie is null)
            {
                logger.LogError($"The mapper package can not map the the {nameof(request.movieToInsertDto)} entity to {nameof(movie)}");

                throw new InvalidMappingOperationException($"The mapper package can not map the the {nameof(request.movieToInsertDto)} entity to {nameof(movie)}");
            }

            string movieFileNameToSave = $"{request.movieToInsertDto.Title}-{request.movieToInsertDto.ReleaseYear}-{Guid.NewGuid().ToString().Substring(0, 4)}";

            fileManager.SaveTheOriginalAndCompressedContentFile(
                request.movieToInsertDto.Location,
                contentOptions.Value.TargetDirectoryToCompressTo,
                movieFileNameToSave);

            movie.Location = Convert.ToBase64String(Encoding.UTF8.GetBytes(movieFileNameToSave + $"{Path.GetExtension(request.movieToInsertDto.Location)}"));

            // save to the database
            try
            {
                logger.LogTrace($"Try to save the movie info in the database");

                await applicationDbContext.Movies.AddAsync(movie);
                await applicationDbContext.SaveChangesAsync();

                logger.LogTrace($"The movie added to the database successfully");

                var result = movie.Adapt<MovieDto>();

                return new ApiResponseDto { Result = result };
            }
            catch (Exception ex)
            {
                // remove the added files 
                File.Delete(Path.Combine(contentOptions.Value.TargetDirectoryToSaveTo, movieFileNameToSave +
                    $"{Path.GetExtension(request.movieToInsertDto.Location)}"));
                File.Delete(Path.Combine(contentOptions.Value.TargetDirectoryToCompressTo, movieFileNameToSave) + ".gz");

                logger.LogError($"An error occur while saving the movie due to : {ex.Message}");

                throw new InsertionException(ex.Message);
            }
        }


    }
}