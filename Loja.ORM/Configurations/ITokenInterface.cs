using System.Collections.Generic;
using System.Security.Claims;

namespace Loja.ORM.Configurations
{
    public interface ITokenInterface
    {
        string GenerateAcessToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
