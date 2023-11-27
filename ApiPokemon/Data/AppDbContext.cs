using ApiPokemon.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPokemon.Data
{
	public partial class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
	{
		public virtual DbSet<Pokemon> Pokemons { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseNpgsql("Name=ConnectionStrings:DatabaseContext");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Pokemon>(entity =>
			{
				entity.HasKey(p => p.Id);
				entity.Property(p => p.Name).IsRequired();
			});

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}
