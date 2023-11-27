using ApiPokemon.Models;
using ApiPokemon.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ApiPokemon.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PokemonController : ControllerBase
	{
		private readonly PokemonService _pokemonService;

		public PokemonController(PokemonService pokemonService)
		{
			_pokemonService = pokemonService;
		}

		[HttpGet("/")]
		public async Task<ActionResult<List<PokemonResults>>> GetAll()
		{
			var pokemon = await _pokemonService.GetPokemonAllAsync();

			if (pokemon == null)
			{
				return NotFound();
			}

			return pokemon;
		}

		[HttpPost("/MigratePokemon")]
		public async Task<ActionResult<List<Pokemon>>> MigratePokemon()
		{
			var pokemon = await _pokemonService.GetPokemonAllAsync();

			if (pokemon == null)
			{
				return NotFound();
			}

			List<Pokemon> pokemons = new();

			foreach (var item in pokemon)
			{
				var pokemonItem = new Pokemon { Name = item.Name, Url = item.Url };
				await _pokemonService.SavePokemonAsync(pokemonItem);
				pokemons.Add(pokemonItem);
			}

			return pokemons;
		}
	}
}
