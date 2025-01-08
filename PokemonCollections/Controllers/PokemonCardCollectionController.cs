using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PokemonCollections.Context;
using PokemonCollections.Interface;
using PokemonCollections.Models;

namespace PokemonCollections.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PokemonCardCollectionController : ControllerBase
{
    private readonly DatabaseContext _context;
    
    public PokemonCardCollectionController(DatabaseContext context)
    {
        _context = context;
    }
    [HttpPost]
    public async Task AddCardToCollection(int collectionId, int cardId)
    {
        var newCardCollection = new CardCollection()
        {
            CollectionId = collectionId,
            CardId = cardId
        };
            _context.CardCollections.Add(newCardCollection);
            await _context.SaveChangesAsync();
    }

    [HttpGet]
    public async Task GetCollection(string userId)
    {
        
    }
    
    
}