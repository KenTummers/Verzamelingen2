namespace KenTummersVerzamelingen2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class YuGiOhModel : DbContext
    {
        public YuGiOhModel()
            : base("name=YuGiOhModel")
        {
        }

        public virtual DbSet<ChildYuGiOh> ChildYuGiOh { get; set; }
        public virtual DbSet<ParentYuGiOh> ParentYuGiOh { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChildYuGiOh>()
                .Property(e => e.Status)
                .IsFixedLength();

            modelBuilder.Entity<ParentYuGiOh>()
                .Property(e => e.Status)
                .IsFixedLength();

            modelBuilder.Entity<ParentYuGiOh>()
                .HasMany(e => e.ChildYuGiOh)
                .WithRequired(e => e.ParentYuGiOh)
                .HasForeignKey(e => e.ParentID)
                .WillCascadeOnDelete(false);
        }
    }
}
