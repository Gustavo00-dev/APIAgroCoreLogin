using APIAgroCoreLogin.Data;
using APIAgroCoreLogin.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace APIAgroCoreLogin.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> GetByEmailAndSenhaAsync(string email, string senha)
        {
            return await _context.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email && u.Senha == senha);
        }

        public async Task<Usuario> CreateAsync(Usuario usuario)
        {
            var dbName = _context.Database.GetDbConnection().Database;
            var dataSource = _context.Database.GetDbConnection().DataSource;

            Console.WriteLine($"Banco: {dbName}");
            Console.WriteLine($"Servidor: {dataSource}");

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }
    }
}
