using Netrunner.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netrunner.Application.ClassicExample.Contract
{
    public interface ICardLogic
    {
        Task AddCard(Card card);
        Task RemoveCard(string cardId);
        Task UpdateCard(Card card);
        Task<Card> GetCardGetById(string cardId);
    }
}
