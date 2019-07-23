using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A7
{
    public class PartitioningSouvenirs : Processor
    {
        public PartitioningSouvenirs(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long souvenirsCount, long[] souvenirs)
        {
            long sum = souvenirs.Sum();
            long i, j;
            long[,] part = new long[sum + 1, souvenirsCount + 1];


            if (sum % 3 != 0)
                return 0;
            sum = sum / 3;
            for (i = 1; i <= sum; i++)
            {
                for (j = 1; j <= souvenirsCount; j++)
                {
                    var a = i - souvenirs[j - 1];
                    if (souvenirs[j - 1] == i ||
                        (a > 0 && part[a, j - 1] > 0))
                    {
                        if (part[i, j - 1] == 0)

                            part[i, j] = 1;

                        else
                            part[i, j] = 2;
                    }
                    else
                        part[i, j] = part[i, j - 1];

                }
            }

            if (part[sum, souvenirsCount] == 2)
                return 1;
            else
                return 0;
        }
    }
}
