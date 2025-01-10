using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonCollections.Context;
using PokemonCollections.Models;

namespace PokemonCollections.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PokemonCollectionController(DatabaseContext _context) : ControllerBase
{
    [Authorize]
    [HttpPost]
    public async Task CreateCollection(string userId)
    {
        var newCollection = new PokemonCollection()
        {
            UserId = userId,
        };
            _context.Collections.Add(newCollection);
            await _context.SaveChangesAsync();
    }
    
    [Authorize]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PokemonCollection>>> GetCollections(string userId)
    {
        var allCards = await _context.Collections.Where(c => c.UserId == userId).ToListAsync();
        List<int> collectionIds = new List<int>();
        foreach (var card in allCards)
        {
            collectionIds.Add(card.CollectionId);
        }
        return Ok(collectionIds);
    }
}