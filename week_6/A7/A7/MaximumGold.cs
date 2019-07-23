using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A7
{
    public class MaximumGold : Processor
    {
        public MaximumGold(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long W, long[] goldBars)
        {
            long n = W + 1;
            long m = goldBars.Length + 1;
            long[,] Value = new long[n , m];
           /* for (int i = 0; i <= W; i++)
                Value[i, 0] = 0;
            for (int i = 0; i <= goldBars.Length; i++)
                Value[0, i] = 0;*/

            for(int i =1;i<m;i++)
            {
                for(int j = 1;j<n;j++)
                {
                    Value[j, i] = Value[j, i - 1];
                    if(j>=goldBars[i-1])
                    {
                        long val = Value[j- goldBars[i - 1], i - 1] + goldBars[i - 1];
                        if (val > Value[j, i])
                            Value[j, i] = val;
                    }
                }
            }

            return Value[W , goldBars.Length];
        }
    }
}
