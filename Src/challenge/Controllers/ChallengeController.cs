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

         [HttpPost]
        public int FrogJmp(int X, int Y, int D)
        {
              var service = new FrogJmp();
              return service.Solution(X,Y,D);
        }

        [HttpPost]
        public int PermMissingElem(int[] A)
        {
            var service = new PermMissingElem();
              return service.Solution(A);
        }

        [HttpPost]
        public double CurrencyConversion(string inputCurrency, string outputCurrency, double amount)
        {
              var service = new CurrencyConversion();
              var res =  service.Convert(inputCurrency, outputCurrency, amount);
              return res;
        }
        
    }
}