using Netrunner.Application.ClassicExample.Contract;
using Netrunner.Domain.Core;
using Netrunner.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace Netrunner.Application.ClassicExample.Implementaion
{
    public class CardLogic : ICardLogic
    {
        private readonly ICardRepository _cardRepository;

        public CardLogic(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }
        public async Task AddCard(Card card) //(Name, Cost, Player Type, )
        {

            //вызвать экземпляр логики работы с базой, когда закончена обработка бизнес логикой

            //создадим гуид здесь
            card.CardId = Guid.NewGuid();

            //проводим операции и черную магию бизнес требований

            //операции готовы, пора ложить в базу
            await _cardRepository.AddCard(card);

            
        }

        public async Task<Card> GetCardGetById(string cardId)
        {
            return await _cardRepository.GetCardGetById(cardId);
        }

        public async Task RemoveCard(string cardId)
        {
            if (cardId != null)
            {
                await _cardRepository.RemoveCard(cardId);
            }
            else
            {
                throw new ArgumentNullException($"CardID for delete was null: CardId: {cardId}");
            }

        }

        public async Task UpdateCard(Card card)
        {
            // изменить какие-то поля у существующей карточки
            //достаём из базы существующую карточку, меняем ей поля в соответствии с новым объектом
            Card cardForUpdate;
            if (card.CardId.HasValue)
            {
                 cardForUpdate = await _cardRepository.GetCardGetById(card.CardId.Value.ToString());
            }
            else
            {
                throw new ArgumentNullException($"CardID for update was null: CardId: {card.CardId}");
            }
            await _cardRepository.UpdateCard(card);
            
        }
    }
}
