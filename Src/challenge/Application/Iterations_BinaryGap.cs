using System;
using System.Collections.Generic;
using System.Linq;

namespace challenge.Application
{
    //Deescription
    // https://docs.google.com/document/d/11hzBu_jggLZAYmggFCkMQmkJFTNvpVXDD34yCfyCyXI/edit?usp=sharing
    public class Iterations_BinaryGap
    {      
        public int BinaryGap(int N)
        {
            var binary = Convert.ToString(N, 2);
            var gapList = new List<int>();
            var gapCounter = 0;
            foreach (var item in binary)
            {
                if (item == '0')
                {
                    gapCounter++;

                }
                else
                {
                    if (gapCounter > 0)
                    {
                        gapList.Add(gapCounter);
                        gapCounter = 0;
                    }
                }
            }
            if (gapList.Count == 0)
            {
                return 0;
            }

            if (gapList.Count == 1)
            {
                return gapList.First();
            }
            return gapList.Max(x => x);
        }
    }
}