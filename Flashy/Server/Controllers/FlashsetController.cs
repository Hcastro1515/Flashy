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
            return Ok(await _flashsetService.GetFlashSets()); 
        }

        [HttpGet]
        public async Task<ActionResult<Flashset>> GetSetById(int id)
        {
            return Ok(await _flashsetService.GetFlashsetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<List<Flashset>>> CreateFlashSet(Flashset set)
        {
            var FLashsetInDb = _flashsetService.GetFlashsetById(set.Id);

            if (FLashsetInDb != null) return BadRequest("Cannot create set, Set already exists");
            
            await _flashsetService.CreateFlashset(set);

            return Ok(await _flashsetService.GetFlashSets());
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
