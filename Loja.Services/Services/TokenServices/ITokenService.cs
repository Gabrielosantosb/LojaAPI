﻿using System.Collections.Generic;
using System.Security.Claims;

namespace Loja.ORM.Implementations
{
    public interface ITokenService
    {
        string GenerateAcessToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}