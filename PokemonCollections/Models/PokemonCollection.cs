using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokemonCollections.Models;

public class PokemonCollection
{
    [Key]
    public int CollectionId { get; set; }
    public string UserId { get; set; }
    [ForeignKey("UserId")]
    public PokemonUser User { get; set; }
    
    [ForeignKey("CollectionId")]
    public ICollection<CardCollection> CardCollections { get; } = [];
    
}