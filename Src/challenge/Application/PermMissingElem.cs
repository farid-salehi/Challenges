using System.Linq;

namespace challenge.Application
{
    public class PermMissingElem
    {
        public int Solution(int[] A)
        {
            var n = A.Count() + 1;
            var sum = (n * (n +1)) /2; 
            foreach(var item in A)
            {
                sum -= item;
            } 
            return sum;
        }
    }
}