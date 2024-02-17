﻿using MediatR;
using Netflix_Clone.Shared.DTOs;

namespace Netflix_Clone.Infrastructure.DataAccess.Movies.Queries
{
    public class GetMovieQuery(int ContentId) : IRequest<ApiResponseDto>
    {
        public readonly int contentId = ContentId;
    }
}