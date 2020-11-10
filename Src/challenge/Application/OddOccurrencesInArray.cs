using System;
using System.Collections;

namespace challenge.Application
{
    public class OddOccurrencesInArray
    {

        public int solution(int[] A)
        {
            var countHashTable = new Hashtable();
            for(var i = 0; i <A.Length; i++)
            {
                if(countHashTable.ContainsKey(A[i]))
                {
                    countHashTable[A[i]] =  (int)countHashTable[A[i]] + 1;
                }
                else
                {
                    countHashTable.Add(A[i],1);
                }
            }

            foreach(var item in countHashTable.Keys)
            {
                if((int) countHashTable[item] % 2 != 0)
                {
                    return (int)item;
                }
            }
            return 0;
        }
        // public static int[] b;
        // public int solution(int[] A)
        // {
        //     b = A;
        //     var li = new List<Task<int>>();
        //     foreach (var item in A.Distinct())
        //     {
        //         li.Add(Task.Factory.StartNew<int>
        //         (() => findAsync(item)));
        //     }
        //     var res = li.Where(x=> x.Result != 0).FirstOrDefault();
        //     return res.Result;
        // }
        // public int findAsync(int item)
        // {
        //     if (b.Where(x => x == item).Count() % 2 == 0)
        //     {
        //         return 0;
        //     }
        //     return item;
        // }
    }
}