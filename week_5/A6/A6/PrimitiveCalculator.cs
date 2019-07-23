using System;
using System.Collections.Generic;
using TestCommon;

namespace A6
{
    public class PrimitiveCalculator : Processor
    {
        public PrimitiveCalculator(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[]>)Solve);

        public long[] Solve(long n)
        {
            List<long> dist = new List<long> { 0, 1 };
            for (int i = 2; i <= n; i++)
            {
                if (i % 3 == 0)
                {
                    if (dist[i / 3] < dist[i - 1])
                        dist.Add(dist[i / 3] + 1);
                    else
                        dist.Add(dist[i - 1] + 1);
                }   
                else if (i % 2 == 0)
                {
                    if (dist[i / 2] < dist[i - 1])
                        dist.Add(dist[i / 2] + 1);
                    else
                        dist.Add(dist[i - 1] + 1);
                }
                else
                    dist.Add(dist[i - 1] + 1);
            }

            List<long> sequence = new List<long>(dist.Count) { n } ;
            
            for (long i = n; i > 1;)
            {

                if (i % 3 == 0)
                {
                    if (dist[(int)i / 3] <= dist[(int)i - 1])
                        i = i / 3;
                    else
                        i = i - 1;
                    sequence.Add(i);
                }

                else if (i % 2 == 0)
                {
                    if (dist[(int)i / 2] <= dist[(int)i - 1])
                        i = i / 2;
                    else
                        i = i - 1;
                    sequence.Add(i);
                }

                else
                {
                    i--;
                    sequence.Add(i);
                }
            }

            sequence.Reverse();
            return sequence.ToArray();
        }
    }
}
