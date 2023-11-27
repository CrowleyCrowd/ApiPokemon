using ApiPokemon.Data;
using ApiPokemon.Models;
using System.Text.Json;

namespace ApiPokemon.Services
{
	public class PokemonService
	{
		private readonly HttpClient _httpClient;
		private readonly AppDbContext _dbContext;

		public PokemonService(HttpClient httpClient, AppDbContext dbContext)
		{
			_httpClient = httpClient;
			_dbContext = dbContext;
		}

		public async Task<List<PokemonResults>> GetPokemonAllAsync()
		{
			var response = await _httpClient.GetAsync($"https://pokeapi.co/api/v2/pokemon");

			response.EnsureSuccessStatusCode();

			var content = await response.Content.ReadAsStringAsync();
			var pokemonJson = JsonSerializer.Deserialize<PokemonAll>(content);
			var results = pokemonJson.Results;

			return results;
		}

		public async Task SavePokemonAsync(Pokemon pokemon)
		{
			_dbContext.Pokemons.Add(pokemon);
			await _dbContext.SaveChangesAsync();
		}
	}
}
