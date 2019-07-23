using System;
using TestCommon;

namespace A6
{
    public class EditDistance : Processor
    {
        public EditDistance(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, string, long>)Solve);

        public long Solve(string str1, string str2)
        {
            int b = str2.Length;
            int a = str1.Length;
            long[,] dist = new long[a + 1, b + 1];

            for (int j = 0; j < b + 1; j++)
                dist[0, j] = j;
            for (int i = 0; i < a + 1; i++)
                dist[i, 0] = i;
            
            for (int j = 1; j <= b; j++)
            {
                for (int i = 1; i <= a; i++)
                {
                    if (str1[i - 1] == str2[j - 1])
                        dist[i, j] = Minimom(dist[i - 1, j] + 1,
                            dist[i, j - 1] + 1,
                            dist[i - 1, j - 1]);
                    else
                        dist[i, j] = Minimom(dist[i - 1, j] + 1,
                            dist[i, j - 1] + 1,
                            dist[i - 1, j - 1] + 1);
                }
            }

            return dist[a, b];
        }

        private long Minimom(long a, long b, long c)
        {
            a = Math.Min(a, b);
            return Math.Min(a, c);
        }
    }
}
