﻿using MediatR;
using Netflix_Clone.Shared.DTOs;

namespace Netflix_Clone.Infrastructure.DataAccess.TVShowEpisodes.Queries
{
    public class GetTVShowEpisodeQuery(TVShowEpisodeRequestDto tVShowEpisodeRequestDto)
        : IRequest<ApiResponseDto<TVShowEpisodeDto>>
    {
        public readonly TVShowEpisodeRequestDto tVShowEpisodeRequestDto = tVShowEpisodeRequestDto;
    }
}
