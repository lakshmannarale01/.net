using CardValidation.Interfaces;
using CardValidation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CardValidation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }
        [HttpPost]
        public ActionResult ValidateCard(Card card)
        {
            if (ModelState.IsValid)
            {
                var result = _cardService.ValidateCard(card.CardNumber);
                if (result)
                {
                    CardResult cardResult = new CardResult()
                    {
                        CardNumber = card.CardNumber,
                        IsValid = result
                    };
                    return Ok(cardResult);
                }
            }
            return BadRequest("Invalid card number. Dont cheat!!!");
        }
    }
}
