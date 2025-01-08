using Microsoft.AspNetCore.Mvc;
using PokemonCollections.Context;
using PokemonCollections.Models;

namespace PokemonCollections.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PokemonUserController : ControllerBase
{
    
    private readonly DatabaseContext _context;

    [HttpGet]
    public async Task<ActionResult<PokemonUser>> GetUserIdByEmail()
    {
        var user = await _context.Users.FindAsync("tommymaimai@gmail.com");
        if (user is null)
            return NotFound("Card not found");
        return Ok(user.Id);
    }
    
    //TODO SE NÆRMERE PÅ IDENTITY CLAIMS
}