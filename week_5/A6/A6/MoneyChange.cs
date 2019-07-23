using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class MoneyChange : Processor
    {
        private static readonly int[] COINS = new int[] { 1, 3, 4 };

        public MoneyChange(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        public long Solve(long n)
        {
            long minNumCoins = 0;
            List<long> minNumber = new List<long>((int)n)
            {
                0
            };
            for (int m = 1; m <= n; m++)
            {
                minNumber.Add(long.MaxValue);

                for (int i = 0; i < COINS.Length; i++)
                    if (m >= COINS[i])
                    {
                        minNumCoins = minNumber[m - COINS[i]] + 1;
                        if (minNumCoins < minNumber[m])
                            minNumber[m] = minNumCoins;
                    }
            }
            return minNumber[(int)n];
        }
    }
}
