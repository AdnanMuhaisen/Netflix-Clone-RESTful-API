﻿using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Netflix_Clone.Infrastructure.DataAccess.Authentication.Commands;
using Netflix_Clone.Shared.DTOs;

namespace Netflix_Clone.Infrastructure.DataAccess.Authentication.Handlers
{
    public class AddNewRoleCommandHandler(
        ILogger<AddNewRoleCommandHandler> logger,
        RoleManager<IdentityRole> roleManager) : IRequestHandler<AddNewRoleCommand, ApiResponseDto<AddNewRoleResponseDto>>
    {
        private readonly ILogger<AddNewRoleCommandHandler> logger = logger;
        private readonly RoleManager<IdentityRole> roleManager = roleManager;

        public async Task<ApiResponseDto<AddNewRoleResponseDto>> Handle(AddNewRoleCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.roleName))
            {
                return new ApiResponseDto<AddNewRoleResponseDto>
                {
                    Result = new AddNewRoleResponseDto
                    {
                        IsAdded = false
                    },
                    Message = $"Invalid Role Name: {request.roleName}",
                    IsSucceed = false
                };
            }

            if (await roleManager.RoleExistsAsync(request.roleName))
            {
                return new ApiResponseDto<AddNewRoleResponseDto>
                {
                    Result = new AddNewRoleResponseDto
                    {
                        IsAdded = false
                    },
                    Message = $"The role with the name {request.roleName} is already exist",
                    IsSucceed = false
                };
            }

            //add the role 
            try
            {
                var result = await roleManager.CreateAsync(new IdentityRole
                {
                    Name = request.roleName,
                    NormalizedName = request.roleName.ToUpper(),
                });

                return result.Succeeded
                    ? new ApiResponseDto<AddNewRoleResponseDto>
                    {
                        Result = new AddNewRoleResponseDto { IsAdded = true },
                        Message = string.Empty,
                        IsSucceed = true
                    }
                    : new ApiResponseDto<AddNewRoleResponseDto>
                    {
                        Result = new AddNewRoleResponseDto { IsAdded = false },
                        Message = string.Join(',', result.Errors.Select(x => x.Description)),
                        IsSucceed = false
                    };
            }
            catch(Exception ex)
            {
                return new ApiResponseDto<AddNewRoleResponseDto>
                {
                    Result = new AddNewRoleResponseDto { IsAdded = false },
                    Message = "An error occur while adding the role",
                    IsSucceed = false
                };
            }
        }
    }
}
