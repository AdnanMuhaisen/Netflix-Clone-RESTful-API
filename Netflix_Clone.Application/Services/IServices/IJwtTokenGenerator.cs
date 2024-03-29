﻿using Netflix_Clone.Domain.Entities;

namespace Netflix_Clone.Application.Services.IServices
{
    public interface IJwtTokenGenerator : IScopedService
    {
        string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> UserRoles);
    }
}
