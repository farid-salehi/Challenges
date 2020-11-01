using challenge.Application;
using Microsoft.AspNetCore.Mvc;

namespace challenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChallengeController: ControllerBase
    {
        [HttpGet]
        public int BinaryGap(int number)
        {
            var service = new Iterations_BinaryGap();
            return service.BinaryGap(number);
        }
        
    }
}