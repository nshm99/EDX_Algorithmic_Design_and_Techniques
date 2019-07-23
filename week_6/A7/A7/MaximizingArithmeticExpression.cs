using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A7
{
    public class MaximizingArithmeticExpression : Processor
    {
        public MaximizingArithmeticExpression(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, long>)Solve);

        public long Solve(string expression)
        {
            string[] expressionArray = expression.Split(new char[] { '+', '-', '*' }
            , StringSplitOptions.RemoveEmptyEntries);
            string[] opp = expression.Split(new char[] 
            { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }
            ,StringSplitOptions.RemoveEmptyEntries);
            int n = expressionArray.Length;
            long[,] minArray = new long[n,n];
            long[,] maxArray = new long[n, n];
            for(int i = 0; i<n;i++)
            {
                minArray[i, i] = long.Parse(expressionArray[i]);
                maxArray[i, i] = long.Parse(expressionArray[i]);
            }
            for(int a = 1; a<n;a++)
            {
                for(int i =0;i< n-a;i++)
                {
                    int j = i + a;
                    minArray[i, j] = MinArray(i, j,maxArray,minArray,expressionArray,opp);
                    maxArray[i, j] = MaxArray(i, j,maxArray,minArray,expressionArray,opp);
                }

            }
            return maxArray[0,n-1];
        }

        private long MaxArray(int i, int j, long[,] maxArray, long[,] minArray
            ,string[] expressionArray, string[] opp)
        {
            long max = long.MinValue;
            long a, b, c, d;
            for (int k = i; k < j; k++)
            {
                a = calculate(maxArray[i, k], maxArray[k + 1, j], opp[k]);
                b = calculate(maxArray[i, k], minArray[k + 1, j], opp[k]);
                c = calculate(minArray[i, k], maxArray[k + 1, j], opp[k]);
                d = calculate(minArray[i, k], minArray[k + 1, j], opp[k]);
                max = Math.Max(max, Math.Max(a, (Math.Max(b, Math.Max(c, d)))));
            }
            return max;
        }

        private long MinArray(int i, int j , long[,] maxArray, long[,] minArray
            ,string[] expressionArray,string[] opp)
        {
            long min = long.MaxValue;
            long a, b, c, d;
            for (int k = i; k<j; k++)
            {
                a = calculate(maxArray[i, k], maxArray[k + 1, j], opp[k]);
                b = calculate(maxArray[i, k], minArray[k + 1, j], opp[k]);
                c = calculate(minArray[i, k], maxArray[k + 1, j], opp[k]);
                d = calculate(minArray[i, k], minArray[k + 1, j], opp[k]);
                min = Math.Min(min,Math.Min(a, (Math.Min(b, Math.Min(c, d)))));
            }
            return min;
        }

        private long calculate(long v1, long v2, string v3)
        {
            if (v3 == "*")
                return v1 * v2;
            if (v3 == "-")
                return v1 - v2;
            else
                return v1 + v2;
        }
    }
}
