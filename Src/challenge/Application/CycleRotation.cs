using System.Linq;

namespace challenge.Application
{
    public class CycleRotation
    {
        public int[] Rotate(int[] A, int K)
        {

            if(A == null || A.Length == 0)
            {
                return A;
            }
            if (K == A.Length)
            {
                return A;
            }
            for(var i =0 ; i< K; i++)
            {
                var temp = A[0];
                A[0] = A[A.Length - 1];
                for (int j = 0; j < A.Length - 1; j++)
                {

                    var t = A[j + 1];
                    A[j + 1] = temp;
                    temp = t;
                }
            }
            return A;
            
        }
    }
}