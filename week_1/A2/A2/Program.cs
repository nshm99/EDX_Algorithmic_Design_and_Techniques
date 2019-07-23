using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2
{
    public class Program
    {
        static void Main(string[] args)
        {
        }

        public static string Process(string input)
        {
            var inData = input.Split(new char[] { '\n', '\r', ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(s => int.Parse(s))
                .ToList();
            return FastMaxPairwiseProduct(inData).ToString();
        }



        public static int NaiveMaxPairwiseProduct(List<int> numbers)
        {
            int product = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = 0; j < numbers.Count; j++)
                {
                    if (i != j)
                    {
                        if (product < numbers[i] * numbers[j])
                            product = numbers[i] * numbers[j];
                    }
                }
            }
            return product;
        }

        public static int FastMaxPairwiseProduct(List<int> numbers)
        {
            int index = 0;
            for(int i=1;i<numbers.Count;i++)
            {
                if (numbers[i] > numbers[index])
                    index = i;
            }
            int s = numbers[index];
            numbers[index] = numbers[numbers.Count - 1];
            numbers[numbers.Count - 1] = s;
            index = 0;
            for(int i=1; i<numbers.Count-1; i++)
            {
                if (numbers[i] > numbers[index])
                    index = i;
            }
            s = numbers[index];
            numbers[index] = numbers[numbers.Count - 2];
            numbers[numbers.Count - 2] = s;
            return numbers[numbers.Count -1] * numbers[numbers.Count-2];
        }


    }
}
