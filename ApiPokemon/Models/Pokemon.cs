using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiPokemon.Models
{
	[Table("Pokemons")]
	public class Pokemon
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Required]
		[Column("name")]
		public string Name { get; set; }

		[Required]
		[Column("url")]
		public string Url { get; set; }
	}
}
