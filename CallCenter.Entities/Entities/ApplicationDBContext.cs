using CallCenter.Models.BM;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenter.Entities.Entities
{
    public partial class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext()
        {
        }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }

        public virtual DbSet<TablaPago> TablaPagos { get; set; }
        public virtual DbSet<SPClienteBM> SPClienteBM { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

            => optionsBuilder.UseSqlServer("Server=DESKTOP-1HLEKSK\\SQLEXPRESS; Database=CallCenter;Trusted_Connection=true;Encrypt=False;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Cedula);

                entity.ToTable("CLIENTE");

                entity.Property(e => e.Cedula)
                    .ValueGeneratedNever()
                    .HasColumnName("CEDULA");
                entity.Property(e => e.NombreCompleto)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE_COMPLETO");
                entity.Property(e => e.Pin).HasColumnName("PIN");
            });

            modelBuilder.Entity<TablaPago>(entity =>
            {
                entity.HasKey(e => e.IdPagos);

                entity.ToTable("TABLA_PAGO");

                entity.Property(e => e.IdPagos).HasColumnName("ID_PAGOS");
                entity.Property(e => e.Cedula).HasColumnName("CEDULA");
                entity.Property(e => e.FechaPago)
                    .HasColumnType("date")
                    .HasColumnName("FECHA_PAGO");
                entity.Property(e => e.Monto)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("MONTO");

                entity.HasOne(d => d.CedulaNavigation).WithMany(p => p.TablaPagos)
                    .HasForeignKey(d => d.Cedula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TABLA_PAGO_CLIENTE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

