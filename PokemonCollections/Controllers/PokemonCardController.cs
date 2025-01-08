
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonCollections.Context;
using PokemonCollections.Interface;
using PokemonCollections.Models;

namespace PokemonCollections.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PokemonCardController : ControllerBase
{
    private readonly DatabaseContext _context;

    private readonly IPokemonTcgApiClient _pokemonClient;
    
    public PokemonCardController(DatabaseContext context, IPokemonTcgApiClient pokemonClient)
    {
        _context = context;
        _pokemonClient = pokemonClient;
    }

    [HttpPost]
    public async Task<ActionResult<PokemonCard>> SetAllCards()
    {
        foreach (var card in _pokemonClient.GetCardList())
        {
            var newCard = new PokemonCard()
            {
                CardName = card.Name,
                SmallCardUrl = card.Images.Small,
                LargeCardUrl = card.Images.Large
            };
            _context.Cards.Add(newCard);
        }
    
        await _context.SaveChangesAsync();
        
        return Ok(await _context.Cards.ToListAsync());
    }
    
    //
    // [HttpPost("{id}")]
    // public async Task<ActionResult<PokemonCard>> AddToCollection(int id)
    // {
    //     return Ok(await _context.Cards.FindAsync(id));
    // }

    [HttpGet] 
    [Authorize]
        public async Task<ActionResult<IEnumerable<PokemonCard>>> GetAllCards()
        {
            var allCards = await _context.Cards.ToListAsync();
        return Ok(allCards);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<IEnumerable<PokemonCard>>> GetCardById(int id)
    {
        var card = await _context.Cards.FindAsync(id);
        if (card is null)
            return NotFound("Card not found");
        return Ok(card);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<IEnumerable<PokemonCard>>> DeleteCardById(int id)
    {
        var card = await _context.Cards.FindAsync(id);
        if (card is null)
            return NotFound("Card not found");

        _context.Cards.Remove(card);
        await _context.SaveChangesAsync();
        return Ok("Deleted " + card + " Successfully");
    }
}