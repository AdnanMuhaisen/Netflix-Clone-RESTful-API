﻿using MediatR;
using Netflix_Clone.Domain.DTOs;

namespace Netflix_Clone.Infrastructure.DataAccess.Queries
{
    public class GetAllMoviesQuery : IRequest<ApiResponseDto>
    {
    }
}
