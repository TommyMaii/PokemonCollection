using PokemonTcgSdk.Standard.Infrastructure.HttpClients;
using PokemonTcgSdk.Standard.Infrastructure.HttpClients.Cards;

namespace PokemonCollections.Interface;

public interface IPokemonTcgApiClient
{
    public List<Card> GetCardList();
}