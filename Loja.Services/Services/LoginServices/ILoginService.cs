using Loja.Services.Services.PersonServices.Models;
using Loja.Services.Services.TokenServices.Model;

namespace Loja.Services.Services.LoginServices
{
    public interface ILoginService
    {
        TokenVO ValidateCredentials(User user);
    }
}
