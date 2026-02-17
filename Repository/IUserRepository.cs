using APIAgroCoreLogin.Model;
using MongoDB.Driver;

namespace APIAgroCoreLogin.Repository
{
    public interface IUserRepository
    {
        Task CreateAsync(BasicUserRequestModel user, CancellationToken cancellationToken = default);
    }
}
