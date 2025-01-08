using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PokemonCollections.Models;

public class CardCollection
{ 
    public int CollectionId { get; set; }
    public int CardId { get; set; }
    public IEnumerable<PokemonCollection> PokemonCollections { get; set; }
    public IEnumerable<PokemonCard> PokemonCards { get; set; }
}
