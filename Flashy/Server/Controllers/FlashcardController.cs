using Flashy.Server.Services.FlashcardService;
using Flashy.Shared.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flashy.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FlashcardController : ControllerBase
    {
        private readonly IFlashcardService _flashcardService; 
        public FlashcardController(IFlashcardService flashcardService)
        {
            _flashcardService = flashcardService;    
        }

        [HttpGet]
        public async Task<ActionResult<List<Flashcard>>> GetFlashcards() {
            var cards = await _flashcardService.GetFlashcards(); 

            if(cards == null) return NotFound("Sorry there are not flashcards");

            return Ok(cards); 
        }

        [HttpGet]
        public async Task<ActionResult<List<Flashcard>>> GetFlashcardById(int Id)
        {
            var card = await _flashcardService.GetFlashcardById(Id); 

            if(card == null) return NotFound("Flashcard was not found");

            return Ok(await _flashcardService.GetFlashcardById(Id)); 
        }

        [HttpPost]
        public async Task<ActionResult<List<Flashcard>>> CreateFlashcard([FromBody] Flashcard card)
        {
            var flashcard = await _flashcardService.CreateFlashcard(card);

            if (card == null) return BadRequest("Error! Flashcard cannot be null!");

            return Ok(flashcard); 
            
        }

        [HttpDelete]
        public async Task<ActionResult<Boolean>> DeleteFlashcardById(int id)
        {
            var isRemoved = await _flashcardService.RemoveFlashcardsById(id);

            if (!isRemoved) return NotFound("Flashcard was not found");  

            return Ok("flashcard was removed successfully"); 
        }

        public async Task<ActionResult<Boolean>> DeleteAllFlashcards()
        {
            var isRemoved = await _flashcardService.RemoveAllFlashCards();

            if (!isRemoved) return BadRequest("There was an error removing all cards");

            return Ok("Flashcards removed successfully"); 
        }
    }
}
