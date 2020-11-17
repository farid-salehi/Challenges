using System;

namespace challenge.Application
{
    public class FrogJmp
    {
        
        public int Solution(int X, int Y, int D)
        {
            return decimal.ToInt32(Math.Ceiling(Decimal.Divide((Y - X) , D)));
           
        }
    }
}