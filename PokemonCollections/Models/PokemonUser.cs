using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace PokemonCollections.Models;

public class PokemonUser : IdentityUser
{
    public ICollection<PokemonCollection> PokemonCollections { get; set; }
}