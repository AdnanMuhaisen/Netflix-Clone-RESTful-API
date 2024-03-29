﻿using MediatR;
using Netflix_Clone.Shared.DTOs;

namespace Netflix_Clone.Infrastructure.DataAccess.TVShows.Queries
{
    public class GetTVShowQuery(int TVShowId) : IRequest<ApiResponseDto<TVShowDto>>
    {
        public readonly int tVShowId = TVShowId;
    }
}
