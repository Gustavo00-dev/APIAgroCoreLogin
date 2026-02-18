using APIAgroCoreLogin.Model;
using Microsoft.EntityFrameworkCore;

namespace APIAgroCoreLogin.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Email).HasColumnName("email").IsRequired();
                entity.Property(e => e.Senha).HasColumnName("senha").IsRequired();
            });
        }
    }
}
