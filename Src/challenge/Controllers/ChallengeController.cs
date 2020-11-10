using System.Threading.Tasks;
using challenge.Application;
using Microsoft.AspNetCore.Mvc;

namespace challenge.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class ChallengeController: ControllerBase
    {
        [HttpGet]
        public int BinaryGap(int number)
        {
            var service = new Iterations_BinaryGap();
            return service.BinaryGap(number);
        }

        [HttpPost]
        public int[] CycleRotation(int[] A, int k)
        {
           var service = new CycleRotation();
            return service.Rotate(A,k);
        }

        [HttpPost]
        public int OddOccurrencesInArray(int[] A)
        {
            var service = new OddOccurrencesInArray();
            return service.solution(A);
        }
        
    }
}