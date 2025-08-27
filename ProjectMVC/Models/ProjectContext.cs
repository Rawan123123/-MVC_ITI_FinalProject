using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ProjectMVC.Models
{
    public class ProjectContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

          => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=MVCProjectt;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Topic>()
            .HasIndex(t => t.Name)
            .IsUnique();

            //M:M between Author & Artical
            modelBuilder.Entity<AuthorsArticlas>().HasKey(AA => new { AA.AuthorId, AA.ArticalId });

            modelBuilder.Entity<AuthorsArticlas>()
                .HasOne(aa => aa.authoer)
                .WithMany(a => a.AuthorsArticlas)
                .HasForeignKey(aa => aa.AuthorId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AuthorsArticlas>()
                .HasOne(aa => aa.artical)
                .WithMany(ar => ar.ArticalsAuthors)
                .HasForeignKey(aa => aa.ArticalId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder
                .Entity<Author>()
                .Property(a => a.Gender)
                .HasConversion<string>();


        }
        public DbSet<Author> Author { get; set; }
        public DbSet<Artical> Artical { get; set; }
        public DbSet<Topic> Topic { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<AuthorsArticlas> AuthorsArticlas { get; set; }


    }
}
