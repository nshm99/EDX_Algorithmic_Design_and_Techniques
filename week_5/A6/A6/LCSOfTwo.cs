using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class LCSOfTwo: Processor
    {
        public LCSOfTwo(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long>)Solve);

        public long Solve(long[] seq1, long[] seq2)
        {
            int l1 = seq1.Length;
            int l2 = seq2.Length;
            long[,] array = new long[l1 + 1, l2+ 1];
            for(int i = 0; i <= l1;i++)
            {
                for(int j =0; j<= l2;j++)
                {
                    if(i==0 || j ==0 )
                    {
                        array[i, j] = 0;
                    }
                    else
                    {
                        if (seq1[i - 1] == seq2[j - 1])
                            array[i, j] = array[i - 1, j - 1] + 1;
                        else
                        {
                            if (array[i - 1, j] > array[i, j - 1])
                                array[i, j] = array[i - 1, j];
                            else
                                array[i, j] = array[i, j - 1];
                        }
                    }
                }
            }
            return array[l1,l2];
        }
    }
}
