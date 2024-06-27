using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netrunner.Application.ClassicExample.Contract;
using Netrunner.Domain.Core;
using System.Diagnostics;

namespace Netrunner.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardLogic _cardLogic;
        public CardController(ICardLogic cardLogic)
        {
            _cardLogic = cardLogic;
        }

        [HttpPost("create")] //localhost:8080/api/cardcontroller/create можно отправить post запрос с объектом, который похож на карту
        public async Task<IActionResult> AddCard([FromBody] Card card)
        {
            await _cardLogic.AddCard(card);
            return Ok();
        }



        [HttpGet("get/{cardId:Guid}")]
        public async Task<IActionResult> getById([FromRoute] Guid cardId)
        {
            var card = await _cardLogic.GetCardGetById(cardId.ToString());
            return Ok(card);
        }

    }
}
