﻿using MediatR;
using Netflix_Clone.Shared.DTOs;

namespace Netflix_Clone.Infrastructure.DataAccess.Authentication.Commands
{
    public class AddNewRoleCommand(string RoleName) : IRequest<ApiResponseDto<AddNewRoleResponseDto>>
    {
        public readonly string roleName = RoleName;
    }
}
