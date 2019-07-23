using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class LCSOfThree: Processor
    {
        public LCSOfThree(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long>)Solve);

        public long Solve(long[] seq1, long[] seq2, long[] seq3)
        {
            int l1 = seq1.Length;
            int l2 = seq2.Length;
            int l3 = seq3.Length;
            long[,,] array = new long[l1, l2, l3];
            for (int i = 0; i <= l1; i++)
            {
                for (int j = 0; j <= l2; j++)
                {
                    for (int k = 0; k <= l3; k++)
                    {
                        if (i == 0 || j == 0 || k == 0)
                            array[i, j, k] = 0;

                        else if (seq1[i - 1] == seq2[j - 1] && seq1[i - 1] == seq3[k - 1])
                            array[i, j, k] = array[i - 1, j - 1, k - 1] + 1;

                        else
                            array[i, j, k] =
                                FindMax(array[i - 1, j, k], array[i, j - 1, k],
                                array[i, j, k - 1]);
                    }
                }
            }

            return array[l1,l2,l3];

        }

        private long FindMax(long v1, long v2,long v3)
        {
            if(v2>v1)
            {
                if (v3 > v2)
                    return v3;
                else
                    return v2;
            }
            else
            {
                if (v3 > v1)
                    return v3;
                else
                    return v1;
            }
        }
    }
}
