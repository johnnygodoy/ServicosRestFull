using Microsoft.EntityFrameworkCore;

namespace ServicosRestFull.Models
{
    public class MeuBanco : DbContext
    {
        public MeuBanco(DbContextOptions<MeuBanco> options) : base(options)
        {
        }

        public DbSet<Vinho> Vinho { get; set; }
        public DbSet<UsuariosSistema> UsuarioSistema { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UsuarioRole> UsuarioRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vinho>().HasKey(v => v.Cod_vinho);
            modelBuilder.Entity<Vinho>()
                .Property(v => v.Nome_vinho)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("VARCHAR");

            modelBuilder.Entity<UsuariosSistema>().HasKey(u => u.Id); // Supondo que o Id seja a chave primária
            modelBuilder.Entity<UsuariosSistema>()
                .Property(u => u.Login)
                .IsRequired()
                .HasMaxLength(255); // Defina o tamanho máximo do login conforme necessário



            // Configuração das chaves primárias compostas para a relação entre UsuariosSistema e Role
            modelBuilder.Entity<UsuarioRole>()
                .HasKey(ur => new { ur.UsuarioId, ur.RoleId });

            // Relacionamento muitos-para-muitos entre UsuariosSistema e Role
            modelBuilder.Entity<UsuarioRole>()
                .HasOne(ur => ur.Usuario)
                .WithMany(u => u.Roles)
                .HasForeignKey(ur => ur.UsuarioId);

            modelBuilder.Entity<UsuarioRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.Usuarios)
                .HasForeignKey(ur => ur.RoleId);
        }
    }
}
