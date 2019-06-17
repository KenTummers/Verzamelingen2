namespace KenTummersVerzamelingen2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PokemonModel : DbContext
    {
        public PokemonModel()
            : base("name=PokeModel")
        {
        }

        public virtual DbSet<ChildPokemon> ChildPokemon { get; set; }
        public virtual DbSet<ParentPokemon> ParentPokemon { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChildPokemon>()
                .Property(e => e.Status)
                .IsFixedLength();

            modelBuilder.Entity<ParentPokemon>()
                .Property(e => e.Status)
                .IsFixedLength();

            modelBuilder.Entity<ParentPokemon>()
                .HasMany(e => e.ChildPokemon)
                .WithRequired(e => e.ParentPokemon)
                .HasForeignKey(e => e.ParentID)
                .WillCascadeOnDelete(false);
        }
    }
}
