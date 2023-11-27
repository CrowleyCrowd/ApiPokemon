using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiPokemon.Models
{
	public class PokemonAll
	{
		[JsonPropertyName("count")]
		public int Count { get; set; }
		[JsonPropertyName("next")]
		public string Next { get; set; }
		[JsonPropertyName("previous")]
		public string Previous { get; set; }
		[JsonPropertyName("results")]
		public List<PokemonResults> Results { get; set; }
	}


	public class PokemonResults
	{
		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("url")]
		public string Url { get; set; }
	}
}
