﻿using MediatR;
using Netflix_Clone.Shared.DTOs;

namespace Netflix_Clone.Infrastructure.DataAccess.TVShowsSeasons.Commands
{
    public class DeleteTVShowSeasonCommand(DeleteTVShowSeasonRequestDto deleteTVShowSeasonRequestDto)
        : IRequest<ApiResponseDto<DeletionResultDto>>
    {
        public readonly DeleteTVShowSeasonRequestDto deleteTVShowSeasonRequestDto = deleteTVShowSeasonRequestDto;
    }
}
