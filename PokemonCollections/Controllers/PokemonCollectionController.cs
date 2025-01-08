using Microsoft.AspNetCore.Mvc;
using PokemonCollections.Context;
using PokemonCollections.Models;

namespace PokemonCollections.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PokemonCollectionController(DatabaseContext context) : ControllerBase
{
    [HttpPost]
    public async Task CreateCollection(string userId)
    {
        var newCollection = new PokemonCollection()
        {
            UserId = userId,
        };
            context.Collections.Add(newCollection);
            await context.SaveChangesAsync();
    }
}