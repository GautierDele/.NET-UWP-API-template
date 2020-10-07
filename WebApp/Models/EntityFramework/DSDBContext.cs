using Microsoft.EntityFrameworkCore;

namespace WebApp.Models.EntityFramework
{
    /*
     * Installer `dotnet ef` (normalement que sur Mac)
     * $ dotnet tool install --global dotnet-ef
     * 
     * $ dotnet ef migrations add 'MigrationName' --project 'WebApp'
     * $ dotnet ef migrations remove --project 'WebApp'
     * 
     * Mettre à jour
     * $ dotnet ef database update --project 'WebApp'
     * 
     * Se positionner à une migration
     * $ dotnet ef database update 'MigrationName' --project 'WebApp'
     * 
     * Tout supprimer
     * $ dotnet ef database update 0 --project 'WebApp'
     * $ dotnet ef migrations remove --project 'WebApp'
     */
    public partial class DSDBContext : DbContext
    {
        public DSDBContext()
        {
        }

        public DSDBContext(DbContextOptions<DSDBContext> options) : base(options)
        {
        }

        public virtual DbSet<MyEntity> MyEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Compte>(entity =>
            //{
            //    entity.HasIndex(c => c.Mel)
            //        .IsUnique()
            //        .HasName("uq_cpt_mel");

            //    entity.Property(c => c.Pays)
            //        .HasDefaultValue("France");

            //    entity.Property(c => c.DateCreation)
            //        .HasDefaultValueSql("current_date");
            //});

            //modelBuilder.Entity<Favori>(entity =>
            //{
            //    entity.HasKey(e => new { e.FilmId, e.CompteId })
            //        .HasName("pk_fav");

            //    entity.HasOne(f => f.FilmFavori)
            //        .WithMany(f => f.FavorisFilm)
            //        .HasForeignKey(f => f.FilmId)
            //        .OnDelete(DeleteBehavior.Cascade)
            //        .HasConstraintName("fk_fav_flm");

            //    entity.HasOne(f => f.CompteFavori)
            //        .WithMany(c => c.FavorisCompte)
            //        .HasForeignKey(f => f.CompteId)
            //        .OnDelete(DeleteBehavior.Cascade)
            //        .HasConstraintName("fk_fav_cpt");
            //});

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
