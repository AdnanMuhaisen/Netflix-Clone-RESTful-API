﻿using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Netflix_Clone.Domain.Entities;
using Netflix_Clone.Domain.Options;
using Netflix_Clone.Infrastructure.DataAccess.Data.Contexts;
using Netflix_Clone.Infrastructure.DataAccess.TVShowEpisodes.Commands;
using Netflix_Clone.Shared.DTOs;
using System.Text;

namespace Netflix_Clone.Infrastructure.DataAccess.TVShowEpisodes.Handlers
{
    public class AddNewTVShowEpisodeCommandHandler(ILogger<AddNewTVShowEpisodeCommandHandler> logger,
        ApplicationDbContext applicationDbContext,
        IOptions<ContentTVShowOptions> options
        ) 
        : IRequestHandler<AddNewTVShowEpisodeCommand, ApiResponseDto<TVShowEpisodeDto>>
    {
        private readonly ILogger<AddNewTVShowEpisodeCommandHandler> logger = logger;
        private readonly ApplicationDbContext applicationDbContext = applicationDbContext;
        private readonly IOptions<ContentTVShowOptions> options = options;

        public async Task<ApiResponseDto<TVShowEpisodeDto>> Handle(AddNewTVShowEpisodeCommand request, CancellationToken cancellationToken)
        {
            var targetTVShow = await applicationDbContext
                .TVShows
                .Include(x => x.Seasons)
                .ThenInclude(i => i.Episodes)
                .AsSplitQuery()
                .FirstOrDefaultAsync(x => x.Id == request.TVShowEpisodeToInsertDto.TVShowId);
            
            if(targetTVShow is null)
            {
                return new ApiResponseDto<TVShowEpisodeDto>
                {
                    Result = null!,
                    IsSucceed = false,
                    Message = $"The target TV Show with Id: {request.TVShowEpisodeToInsertDto.TVShowId} does not exist !"
                };
            }

            var targetSeason = targetTVShow
                .Seasons
                .FirstOrDefault(x => x.Id == request.TVShowEpisodeToInsertDto.SeasonId);
                
            if(targetSeason is null)
            {
                return new ApiResponseDto<TVShowEpisodeDto>
                {
                    Result = null!,
                    IsSucceed = false,
                    Message = $"The target TV Show season with Id: {request.TVShowEpisodeToInsertDto.SeasonId} does not exist !"
                };
            }
            
            var IsTargetEpisodeExist = targetSeason
                .Episodes
                .Any(x => x.EpisodeNumber == request.TVShowEpisodeToInsertDto.EpisodeNumber);

            if (IsTargetEpisodeExist)
            {
                return new ApiResponseDto<TVShowEpisodeDto>
                {
                    Result = null!,
                    IsSucceed = false,
                    Message = $"The target Episode with number : " +
                    $"{request.TVShowEpisodeToInsertDto.EpisodeNumber} in the season number " +
                    $"{request.TVShowEpisodeToInsertDto.SeasonNumber} in the TV Show with id : " +
                    $"{request.TVShowEpisodeToInsertDto.TVShowId} is already exist!"
                };
            }

            //episode file name "{TVShow Title}-{Season number}-{Episode number}" 
            // validate if the episode is already exist
            string pathOfTheTVShowDirectory = Path.Combine(options.Value.TargetDirectoryToSaveTo,
                targetTVShow.Title);

            if(!Directory.Exists(pathOfTheTVShowDirectory))
            {
                return new ApiResponseDto<TVShowEpisodeDto>
                {
                    Result = null!,
                    IsSucceed = false,
                    Message = $"The directory of the target TV Show with id {request.TVShowEpisodeToInsertDto.TVShowId} does not exist"
                };
            }

            var pathOfTheTargetSeason = new StringBuilder(Path.Combine(pathOfTheTVShowDirectory,
                Encoding.UTF8.GetString(Convert.FromBase64String(targetSeason.DirectoryName))));

            if (!Directory.Exists(pathOfTheTargetSeason.ToString()))
            {
                return new ApiResponseDto<TVShowEpisodeDto>
                {
                    Result = null!,
                    IsSucceed = false,
                    Message = $"The directory of the target TV Show season with id {request.TVShowEpisodeToInsertDto.SeasonId} does not exist"
                };
            }

            string episodeFilePath = Path.Combine(pathOfTheTargetSeason.ToString(),
                $"{targetTVShow.Title}" +
                $"-{targetSeason.SeasonNumber}" +
                $"-{request.TVShowEpisodeToInsertDto.EpisodeNumber}") 
                + Path.GetExtension(request.TVShowEpisodeToInsertDto.Location);

            if(File.Exists(episodeFilePath))
            {
                return new ApiResponseDto<TVShowEpisodeDto>
                {
                    Result = null!,
                    IsSucceed = false,
                    Message = $"The episode of the TVShow with id : {targetTVShow.Id}" +
                    $" in season number {targetSeason.SeasonNumber} with episode number : {request.TVShowEpisodeToInsertDto.EpisodeNumber}" +
                    $" is already exist"
                };
            }

            //create the file and save in the database:
            try
            {
                File.Copy(request.TVShowEpisodeToInsertDto.Location, episodeFilePath);
            }
            catch(Exception ex)
            {
                return new ApiResponseDto<TVShowEpisodeDto>
                {
                    Result = null!,
                    IsSucceed = false,
                    Message = "Can not add the episode"
                };
            }

            //save to the database:
            var episodeToInsert = request.TVShowEpisodeToInsertDto.Adapt<TVShowEpisode>();
            //this the location of the episode file / file name
            episodeToInsert.FileName = episodeFilePath.Split('\\').Last();
            episodeToInsert.FileName = Convert.ToBase64String(Encoding.UTF8.GetBytes(episodeToInsert.FileName));

            try
            {
                targetSeason.Episodes.Add(episodeToInsert);

                //applicationDbContext.Entry(episodeToInsert.TVShow).State = EntityState.Detached;  

                targetSeason.TotalNumberOfEpisodes++;
                targetTVShow.TotalNumberOfEpisodes++;

                var attachedEntities = applicationDbContext.ChangeTracker.Entries();

                await applicationDbContext.SaveChangesAsync();

                return new ApiResponseDto<TVShowEpisodeDto>
                {
                    Result = episodeToInsert.Adapt<TVShowEpisodeDto>(),
                    IsSucceed = true,
                    Message = string.Empty
                };
            }
            catch(Exception ex)
            {
                File.Delete(episodeFilePath);

                return new ApiResponseDto<TVShowEpisodeDto>
                {
                    Result = episodeToInsert.Adapt<TVShowEpisodeDto>(),
                    IsSucceed = false,
                    Message = "An error occur while trying to add the episode"
                };
            }
        }
    }
}
