using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PokemonCollections.Models;
using PokemonCard = PokemonCollections.Models.PokemonCard;

namespace PokemonCollections.Context;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : IdentityDbContext<PokemonUser>(options)
{
    public DbSet<PokemonCollection> Collections { get; set; }
    public DbSet<PokemonCard> Cards { get; set; }
    public DbSet<CardCollection> CardCollections { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<CardCollection>().HasKey(cc => new { cc.CardId, cc.CollectionId });
        modelBuilder.Entity<CardCollection>().HasMany<PokemonCollection>(cc => cc.PokemonCollections).WithMany(cc => cc.CardCollections);
        modelBuilder.Entity<CardCollection>().HasMany<PokemonCard>(cc => cc.PokemonCards).WithMany(cc => cc.CardCollections);
        modelBuilder.Entity<PokemonUser>().HasMany<PokemonCollection>(cc => cc.PokemonCollections).WithOne(cc => cc.User);

    }
    
}