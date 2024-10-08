﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Service.Interface
{
    public interface IRoleService
    {
        Task<bool> CreateRoleAsync(string roleName);
        Task<bool> addClaimToRoleAsync(string roles, string claimType, string value);
        Task<IEnumerable<Claim>> GetClaimsForRolesAsync(string roles, string claimType, string Value);
        Task<bool> CheckPermForRolesAsync(string roles, string claimType, string Value);
    }
}
