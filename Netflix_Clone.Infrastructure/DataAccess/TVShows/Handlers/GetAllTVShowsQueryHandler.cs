﻿using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Netflix_Clone.Domain.Options;
using Netflix_Clone.Infrastructure.DataAccess.Data.Contexts;
using Netflix_Clone.Infrastructure.DataAccess.TVShows.Queries;
using Netflix_Clone.Shared.DTOs;
using System.Text;

namespace Netflix_Clone.Infrastructure.DataAccess.TVShows.Handlers
{
    public class GetAllTVShowsQueryHandler(ILogger<GetAllTVShowsQuery> logger
            , ApplicationDbContext applicationDbContext,
        IOptions<ContentTVShowOptions> options) : IRequestHandler<GetAllTVShowsQuery, ApiResponseDto<IEnumerable<TVShowDto>>>
    {
        private readonly ILogger<GetAllTVShowsQuery> logger = logger;
        private readonly ApplicationDbContext applicationDbContext = applicationDbContext;
        private readonly IOptions<ContentTVShowOptions> options = options;

        public async Task<ApiResponseDto<IEnumerable<TVShowDto>>> Handle(GetAllTVShowsQuery request, CancellationToken cancellationToken)
        {
            var tvShows = applicationDbContext
                .TVShows
                .AsNoTracking()
                .Include(x => x.Seasons)
                .ThenInclude(x => x.Episodes)
                .AsSplitQuery()
                .ToList();

            if(tvShows is null)
            {
                logger.LogInformation($"There`s no tv shows to retrieve");

                return new ApiResponseDto<IEnumerable<TVShowDto>> 
                { 
                    Result = Enumerable.Empty<TVShowDto>(),
                    IsSucceed = false
                };
            }

            var result = tvShows.Adapt<List<TVShowDto>>();

            foreach (var tvShow in result)
            {
                tvShow.Location = Path.Combine(options.Value.TargetDirectoryToSaveTo,
                    Encoding.UTF8.GetString(Convert.FromBase64String(tvShow.Location)));

                foreach (var season in tvShow.Seasons)
                {
                    season.DirectoryName =Encoding.UTF8.GetString(Convert.FromBase64String(season.DirectoryName));
                    foreach (var episode in season.Episodes)
                    {
                        episode.FileName = Path.Combine(tvShow.Location,
                            season.DirectoryName,
                             Encoding.UTF8.GetString(Convert.FromBase64String(episode.FileName))
                            );
                    }
                }
            }

            logger.LogInformation($"The tv shows are retrieved successfully");

            return new ApiResponseDto<IEnumerable<TVShowDto>>
            {
                Result = result,
                IsSucceed = true
            };
        }
    }
}
