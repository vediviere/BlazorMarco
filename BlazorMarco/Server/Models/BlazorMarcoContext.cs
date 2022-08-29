using BlazorMarco.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorMarco.Server.Models
{
    public class BlazorMarcoContext : DbContext
    {
        public BlazorMarcoContext(DbContextOptions<BlazorMarcoContext> options) : base(options)
        {

        }

        public DbSet<Meta> Metas { get; set; }
        public DbSet<Tarea> Tareas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meta>().HasKey(m => m.MetaId);
            modelBuilder.Entity<Meta>().Property(m => m.NombreMeta).HasMaxLength(80);

            modelBuilder.Entity <Tarea>()
                .HasOne(m => m.Meta)
                .WithMany(t => t.Tareas)
                .HasForeignKey(m => m.MetaId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Tarea>().HasKey(t => t.TareaId);
            modelBuilder.Entity<Tarea>().Property(t => t.NombreTarea).HasMaxLength(80);
            modelBuilder.Entity<Tarea>().HasIndex(t => new { t.NombreTarea, t.MetaId } ).IsUnique();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }
    }
}
