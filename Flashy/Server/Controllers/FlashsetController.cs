using Flashy.Server.Services.FlashsetService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flashy.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlashsetController : ControllerBase
    {
        private readonly IFlashsetService _flashsetService;

        public FlashsetController(IFlashsetService flashsetService)
        {
            _flashsetService = flashsetService; 
        }

    }
}
