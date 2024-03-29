﻿using MediatR;
using Netflix_Clone.Shared.DTOs;

namespace Netflix_Clone.Infrastructure.DataAccess.Movies.Commands
{
    public class AddNewMovieCommand(MovieToInsertDto movieToInsertDto)  
        : IRequest<ApiResponseDto<MovieDto>>
    {
        public readonly MovieToInsertDto movieToInsertDto = movieToInsertDto;
    }
}
