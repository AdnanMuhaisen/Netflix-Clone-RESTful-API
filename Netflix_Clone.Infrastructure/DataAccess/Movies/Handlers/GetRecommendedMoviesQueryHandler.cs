﻿using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Netflix_Clone.Domain.Entities;
using Netflix_Clone.Infrastructure.DataAccess.Data.Contexts;
using Netflix_Clone.Infrastructure.DataAccess.Movies.Queries;
using Netflix_Clone.Shared.DTOs;

namespace Netflix_Clone.Infrastructure.DataAccess.Movies.Handlers
{
    public class GetRecommendedMoviesQueryHandler(ILogger<GetRecommendedMoviesQueryHandler> logger,
        ApplicationDbContext applicationDbContext)
        : IRequestHandler<GetRecommendedMoviesQuery, ApiResponseDto<IEnumerable<MovieDto>>>
    {
        private readonly ILogger<GetRecommendedMoviesQueryHandler> logger = logger;
        private readonly ApplicationDbContext applicationDbContext = applicationDbContext;

        public async Task<ApiResponseDto<IEnumerable<MovieDto>>> Handle(GetRecommendedMoviesQuery request, CancellationToken cancellationToken)
        {
            var userHistory = await applicationDbContext
                .UsersWatchHistories
                .AsNoTracking()
                .Where(x => x.ApplicationUserId == request.userId)
                .Include(x => x.Content)
                .ToListAsync();

            logger.LogTrace($"Get the user watch history for the user with id : {request.userId}");

            userHistory = userHistory
                .DistinctBy(x => x.ContentId)
                .ToList();

            // the operation is as follows:
            // we will get the genres of the user watch history and then get 
            // the movies based on this genres 

            var preferredGenres = userHistory
                .Select(x => x.Content?.ContentGenreId)
                .Distinct();

            var recommendedMovies = Enumerable.Empty<Movie>();

            // in case of there`s no movies according to preferred genres
            if (userHistory is null || !userHistory.Any() || !preferredGenres.Any())
            {
                logger.LogInformation($"The user with id : {request.userId} has no watch history");

                // return random movies
                recommendedMovies = await applicationDbContext
                    .Movies
                    .AsNoTracking()
                    .OrderBy(x => Guid.NewGuid())
                    .Take(request.totalNumberOfItemsRetrieved)
                    .ToListAsync();

                recommendedMovies ??= [];

                logger.LogTrace("There`s no movies to retrieve from the database");

                return new ApiResponseDto<IEnumerable<MovieDto>>
                {
                    Result = recommendedMovies.Adapt<List<MovieDto>>(),
                    Message = "There`s no movies to retrieve",
                    IsSucceed = false
                };
            }

            recommendedMovies = applicationDbContext
                .Movies
                .AsNoTracking()
                .Where(x => preferredGenres.Contains(x.ContentGenreId))
                .Take(request.totalNumberOfItemsRetrieved)
                .ToList();

            if(recommendedMovies.Count() < request.totalNumberOfItemsRetrieved)
            {
                recommendedMovies = recommendedMovies.Union(applicationDbContext
                    .Movies
                    .AsNoTracking()
                    .Where(x => !recommendedMovies.Contains(x))
                    .OrderBy(x => Guid.NewGuid())
                    .Take(request.totalNumberOfItemsRetrieved - recommendedMovies.Count()))
                    .ToList();
            }

            var result = recommendedMovies.Adapt<List<MovieDto>>();

            logger.LogTrace($"The recommended movies is retrieved successfully");

            return new ApiResponseDto<IEnumerable<MovieDto>>
            {
                Result = result,
                IsSucceed = true
            };
        }
    }
}
