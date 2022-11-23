using Flashy.Server.Services.FlashsetService;
using Flashy.Shared.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flashy.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FlashsetController : ControllerBase
    {
        private readonly IFlashsetService _flashsetService;

        public FlashsetController(IFlashsetService flashsetService)
        {
            _flashsetService = flashsetService; 
        }

        [HttpGet]
        public async Task<ActionResult<List<Flashset>>?> GetSets()
        {
            var sets = await _flashsetService.GetFlashSets();

            if (sets == null) return NotFound("Sorry there are no sets"); 

            return Ok(sets); 
        }

        [HttpGet]
        public async Task<ActionResult<Flashset>> GetSetById(int id)
        {
            var set = await _flashsetService.GetFlashsetById(id);
            if (set == null) return NotFound("Flashcard was not found");
            return Ok(set);
        }

        [HttpPost]
        public async Task<ActionResult<List<Flashset>>> CreateFlashSet([FromBody] Flashset set)
        {

            if (set == null) return BadRequest("Error Flashset cannot be null"); 
            
            var flashset = await _flashsetService.CreateFlashset(set);

            return Ok(flashset);
        }

        [HttpPut]
        public async Task<ActionResult<List<Flashset>>> UpdateSet(Flashset set)
        {
            var updatedSets = await _flashsetService.EditFlashSet(set);

            if(updatedSets?.Count < 0)
            {
                return NotFound("This set doesn't exist");
            }

            return Ok(updatedSets);
        }

        [HttpDelete]
        public async Task<ActionResult<Boolean>> DeleteSet(int id)
        {
            bool isRemoved = await _flashsetService.DeleteFlashsetById(id);

            if (!isRemoved) return NotFound("Unable to remove, set doesn't exist");

            return Ok("Set was successfully removed"); 
        }

        [HttpDelete]
        public async Task<ActionResult<Boolean>> DeleteAllSets()
        {
            bool isRemoved = await _flashsetService.DeleteAllFlashSets();

            if (!isRemoved) return BadRequest("Unable to remove sets");

            return Ok("Set's removed successfully"); 
        }
    }
}
