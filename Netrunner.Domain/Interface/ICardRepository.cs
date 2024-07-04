

using Netrunner.Domain.Core;

namespace Netrunner.Domain.Interface
{
    public interface ICardRepository //работа именно с объектом
    {
        //int Action(); //желательно будет вынести в новую логику для имплементации
        //CRUD

        Task AddCard(Card card);
        Task RemoveCard(string cardId);
        Task UpdateCard(Card card);
        Task<Card> GetCardGetById(string cardId);
       
    }
}
