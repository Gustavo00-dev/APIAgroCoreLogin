using APIAgroCoreLogin.Model;
using System.Threading.Tasks;


namespace APIAgroCoreLogin.Repository
{
    public interface IUserRepository
    {
        Task<Usuario?> GetByEmailAndSenhaAsync(string email, string senha);
        Task<Usuario> CreateAsync(Usuario usuario);
    }
}
