using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokemonCollections.Models;

public class PokemonCard
{
    [Key]
    public int CardId { get; set; }
    public string CardName { get; set; }
    public Uri SmallCardUrl { get; set; }
    public Uri LargeCardUrl { get; set; }
    
    [ForeignKey("CardId")]
    public ICollection<CardCollection> CardCollections { get; set; }
    
}