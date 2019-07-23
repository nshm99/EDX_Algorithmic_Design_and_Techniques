using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A4
{
    public class Program
    {
        static void Main(string[] args)
        {
            MaximizeSalary6(3, new long[] { 2, 21, 2 });
        }

        //1.........................................................................................

        public static long ChangingMony1(long mony)
        {
            if (mony == 0)
                return 0;
            else
            {
                if (mony >= 10)
                    return 1 + ChangingMony1(mony - 10);
                else
                    if (mony >= 5)
                    return 1 + ChangingMony1(mony - 5);
                else
                    return 1 + ChangingMony1(mony - 1);
            }
        }

        public static string ProcessChangingMony1(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)ChangingMony1);

        //2.............................................................................
        public static long MaximizingLoot2(
            long capacity, long[] weights, long[] values)
        {
            List<double> vpw = new List<double>();
            for (int i = 0; i < weights.Length; i++)
                vpw.Add((values[i] / (double)weights[i]));
            int maxIndex;
            double totalValue = 0;
            while (capacity > 0)
            {
                maxIndex = vpw.IndexOf(vpw.Max());
                if (weights[maxIndex] >= capacity)
                {
                    totalValue += capacity * vpw[maxIndex];
                    break;
                }
                if (vpw[maxIndex] == -1)
                    return (long)totalValue;
                else
                {
                    totalValue += (values[maxIndex]);
                    vpw[maxIndex] = -1;
                    capacity -= weights[maxIndex];

                }
            }
            return (long)totalValue;
        }

        public static string ProcessMaximizingLoot2(string inStr) =>
            TestTools.Process(inStr
                , (Func<long, long[], long[], long>)MaximizingLoot2);

        //3.................................................................................

        public static long MaximizingOnlineAdRevenue3(long slotCount,
            long[] adRevenue, long[] averageDailyClick)
        {
            long s = 0;
            for (int i = 0; i < adRevenue.Length; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (adRevenue[j] > adRevenue[i])
                    {
                        long a = adRevenue[j];
                        adRevenue[j] = adRevenue[i];
                        adRevenue[i] = a;
                    }

                    if (averageDailyClick[j] > averageDailyClick[i])
                    {
                        long a = averageDailyClick[j];
                        averageDailyClick[j] = averageDailyClick[i];
                        averageDailyClick[i] = a;
                    }
                }
            }
            for (int i = 0; i < adRevenue.Length; i++)
            {
                s += adRevenue[i] * averageDailyClick[i];
            }
            return s;
        }

        public static string ProcessMaximizingOnlineAdRevenue3(string inStr) =>
            TestTools.Process(inStr
                , (Func<long, long[], long[], long>)MaximizingOnlineAdRevenue3);

        //4.........................................................................
        public static long CollectingSignatures4(long tenatCount,
            long[] startTimes, long[] endTimes)
        {
            List<long> points = new List<long>();
            List<long> end = endTimes.ToList<long>();
            List<long> start = startTimes.ToList<long>();
            while (end.Count() > 0)
            {
                points.Add(end.Min());
                int i = 0;
                while (i < end.Count)
                {
                    if (start[i] <= points[points.Count - 1] && end[i] >= points[points.Count - 1])
                    {
                        start.Remove(start[i]);
                        end.Remove(end[i]);
                    }
                    else
                        i++;
                }
            }
            return points.Count();
        }

        public static string ProcessCollectingSignatures4(string inStr) =>
            TestTools.Process(inStr
                , (Func<long, long[], long[], long>)CollectingSignatures4);

        //5..............................................................................
        public static long[] MaximizeNumberOfPrizePlaces5(long n)
        {
            int i=0 ;
            int s =0;
            while(s<= n)
            {
                i++;
                s += i;
            }
            s -= i;
            i--;
            long[] returnArray = new long[i];
            for (int j = 0; j < i; j++)
                returnArray[j] = j + 1;
            returnArray[returnArray.Length - 1] += n - s;

            return returnArray;
        }

        public static string ProcessMaximizeNumberOfPrizePlaces5(string inStr) =>
            TestTools.Process(inStr
                , (Func<long, long[]>)MaximizeNumberOfPrizePlaces5);

        //6............................................................................
        public static string MaximizeSalary6(long n,long[] numbers)
        {
            List<long> digits = numbers.ToList<long>();
            string answer = "" ;
            long maxDigit;
            while(digits.Count !=0)
            {
                maxDigit = 0;
                foreach (var digit in digits)
                {
                    if(IsGraterOrEqual(digit,maxDigit))
                    {
                        maxDigit = digit;
                    }
                }
                answer +=(maxDigit.ToString());
                digits.Remove(maxDigit);
            }
            return answer.ToString();
        }

        private static bool IsGraterOrEqual(long digit, long maxDigit)
        {
            
            string a = digit.ToString() + maxDigit.ToString();
            string b = maxDigit.ToString() + digit.ToString() ;
            if (long.Parse(a) >= long.Parse(b))
                return true;
            else
                return false;

        }

        public static string ProcessMaximizeSalary6(string inStr) =>
            TestTools.Process(inStr,(Func<long,long[],string>) MaximizeSalary6);
    }
}
