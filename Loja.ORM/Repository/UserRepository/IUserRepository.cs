using Loja.Services.Services.PersonServices.Models;

namespace Loja.ORM.Repository.UserRepository
{
    public interface IUserRepository
    {
        User ValidateCredentials(User user);
        User ValidateCredentials(string username);

        bool RevokeToken(string username);

        User RefreshUserInfo(User user);   
    }
}
