using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
{
    public class Program
    {
        static void Main(string[] args)
        {
            long a=Fibonacci_Partial_Sum(10, 200);
        }



        public static string Process(string inStr, Func<long, long> longProcessor)
        {
            long n = long.Parse(inStr);
            return longProcessor(n).ToString();
        }

        public static string Process(string inStr, Func<long, long,long> longProcessor)
        {
            var toks = inStr.Split(new char[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            long a = long.Parse(toks[0]);
            long b = long.Parse(toks[1]);
            return longProcessor(a, b).ToString();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////

        public static long Fibonacci(long n)
        {
            long[] fibNumbers = new long[n+1];
            fibNumbers[0] = 0;
            if (n == 0)
                return fibNumbers[0];
            fibNumbers[1] = 1;
            for (int i = 2; i <= n; i++)
                fibNumbers[i] = fibNumbers[i - 1] + fibNumbers[i - 2];
            return fibNumbers[n];
        }

        public static string ProcessFibonacci(string inStr) =>
            Process(inStr, Fibonacci);
        
        /////////////////////////////////////////////////////////////////////////////////////////////

        public static long Fibonacci_LastDigit(long n)
        {
            long[] fibNumbers_lastDigit = new long[n + 1];
            fibNumbers_lastDigit[0] = 0;
            if (n == 0)
                return fibNumbers_lastDigit[0];
            fibNumbers_lastDigit[1] = 1;
            for (int i = 2; i <= n; i++)
                fibNumbers_lastDigit[i] = 
                    ((fibNumbers_lastDigit[i - 1] % 10) + (fibNumbers_lastDigit[i - 2] % 10))%10;
            return fibNumbers_lastDigit[n]%10;
        }
        
        public static string ProcessFibonacci_LastDigit(string inStr) =>
            Process(inStr, Fibonacci_LastDigit);

        /////////////////////////////////////////////////////////////////////////////////////////////

        public static long GCD (long a,long b)
        {

            if(b>a)
            {
                long c = a;
                a = b;
                b = c;
            }
            if (b == 0)
                return a;
            else
                return GCD(b, a % b);
        }

        public static string ProcessGCD(string inStr) =>
            Process(inStr, GCD);

        ////////////////////////////////////////////////////////////////////////////////////////////

        public static long LCM (long a,long b)
        {
            return (a * b) / GCD(a, b);
        }

        public static string ProcessLCM(string inStr) =>
            Process(inStr, LCM);

        ////////////////////////////////////////////////////////////////////////////////////////////

        public static long Fibonacci_Mod(long n,long m)
        {
            List<long> Array = new List<long>();
            Array.Add(0);
            Array.Add(1);
            int i = 2;
            while(true)
            {
                Array.Add((Array[i-1]+Array[i-2]) % m);
                if (Array[i] == 1 && Array[i - 1] == 0)
                    break;
                i++;
            }
            Array.RemoveRange(Array.Count - 2, 2);
            return Array[(int) ( n% (i - 1))];
        }

        public static string ProcessFibonacci_Mod(string inStr) =>
            Process(inStr, Fibonacci_Mod);

        /////////////////////////////////////////////////////////////////////////////////////////////

        public static long Fibonacci_Sum(long n)
        {

            if (n == 0)
                return 0;
            if (Fibonacci_Mod(n + 2, 10) == 0)
                return 9;
            long a = Fibonacci_Mod(n + 2, 10) - 1;
            return (Fibonacci_Mod(n+2,10) -1);
        }

        public static string ProcessFibonacci_Sum(string inStr) =>
            Process(inStr, Fibonacci_Sum);

        /////////////////////////////////////////////////////////////////////////////////////////////

        public static long Fibonacci_Partial_Sum(long n,long m)
        {
            if(n<m)
            {
                long c = m;
                m = n;
                n = c;
            }

            long k = (Fibonacci_Sum(n) - Fibonacci_Sum(m - 1)) % 10;
            if (k < 0)
                k += 10;
            return k;
        }

        public static string ProcessFibonacci_Partial_Sum(string inStr) =>
            Process(inStr, Fibonacci_Partial_Sum);

        ////////////////////////////////////////////////////////////////////////////////////////////////

        public static long Fibonacci_Sum_Squares(long n)
        {
            long a = Fibonacci_Mod(n,10);
            return (a*(a + Fibonacci_Mod(n - 1,10)))%10;
        }

        public static string ProcessFibonacci_Sum_Squares(string inStr) =>
            Process(inStr, Fibonacci_Sum_Squares);
    }
}