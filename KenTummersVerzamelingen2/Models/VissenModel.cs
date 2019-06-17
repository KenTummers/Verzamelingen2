namespace KenTummersVerzamelingen2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class VissenModel : DbContext
    {
        public VissenModel()
            : base("name=FishModel")
        {
        }

        public virtual DbSet<ChildFish> ChildFish { get; set; }
        public virtual DbSet<ParentFish> ParentFish { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChildFish>()
                .Property(e => e.Status)
                .IsFixedLength();

            modelBuilder.Entity<ParentFish>()
                .HasMany(e => e.ChildFish)
                .WithRequired(e => e.ParentFish)
                .HasForeignKey(e => e.ParentID)
                .WillCascadeOnDelete(false);
        }
    }
}
