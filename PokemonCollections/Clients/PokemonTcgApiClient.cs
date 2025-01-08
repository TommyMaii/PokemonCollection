using PokemonCollections.Interface;
using PokemonTcgSdk.Standard.Infrastructure.HttpClients;
using PokemonTcgSdk.Standard.Infrastructure.HttpClients.Base;
using PokemonTcgSdk.Standard.Infrastructure.HttpClients.Cards;

namespace PokemonCollections.Controllers;

public class PokemonTcgApiClient : IPokemonTcgApiClient
{
    static PokemonApiClient pokeClient = new PokemonApiClient("82ec9f25-352e-4a3d-88dc-e66238b94720");
    public async Task<ApiResourceList<Card>> GetApiCall()
    {
        return await pokeClient.GetApiResourceAsync<Card>();
    }        
    
    public List<Card> GetCardList()
    {
        var cardList = GetApiCall().Result;
        var cards = cardList.Results.ToList();
        return cards;
    }     
    
    public Card GetCard(int id)
    {
        var cardList = GetApiCall().Result;
        var cards = cardList.Results.ToList();
        return cards[id];
    }
}
