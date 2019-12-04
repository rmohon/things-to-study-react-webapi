using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ThingsToStudyAPI.Data
{
    public partial class RepositoryContext : DbContext
    {
        public RepositoryContext()
            : base("name=RepositoryContext")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Technology> Technologies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.CategoryName)
                .IsUnicode(false);

            modelBuilder.Entity<Technology>()
                .Property(e => e.TechName)
                .IsUnicode(false);

            modelBuilder.Entity<Technology>()
                .Property(e => e.Category)
                .IsUnicode(false);

            modelBuilder.Entity<Technology>()
                .Property(e => e.TechDescription)
                .IsUnicode(false);
        }
    }
}
