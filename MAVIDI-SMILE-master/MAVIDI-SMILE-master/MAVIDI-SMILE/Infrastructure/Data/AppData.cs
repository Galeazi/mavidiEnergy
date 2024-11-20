using MAVIDI_SMILE.Domain.Entities;
using MAVIDI_SMILE.mavidiSmile.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MAVIDI_SMILE.Infrastructure.Data
{
    public class AppData(DbContextOptions<AppData> options) : DbContext(options)
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Progresso> Progresso { get; set; }
        public DbSet<Nivel> Niveis { get; set; }
        public DbSet<Premio> Premios { get; set; }
        public DbSet<Amigo> Amigos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração do relacionamento entre Amigo e Usuario
            modelBuilder.Entity<Amigo>()
                .HasOne(a => a.Usuario)
                .WithMany(u => u.Amigos)
                .HasForeignKey(a => a.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Amigo>()
                .HasOne(a => a.AmigoUsuario)
                .WithMany()
                .HasForeignKey(a => a.AmigoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
