using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A5
{
    public class Program
    {
        static void Main(string[] args)
        {
            //long a= MajorityElement2(5, new long[] { 7, 3, 1, 2, 2 });
        }

        public static long[] BinarySearch1(long[] a, long[] b)
        {
            List<long> returnNumbers = new List<long>();
            foreach (var number in b)
            {
                returnNumbers.Add(Search(number, a, 0, a.Length - 1));
            }
            return returnNumbers.ToArray();
        }

        private static long Search(long key, long[] a, long low, long high)
        {

            if (low > high)
                return -1;
            int mid = (int)(low + ((high - low) / 2));
            if (key == a[mid])
                return mid;
            else
            {
                if (key < a[mid])
                    return Search(key, a, low, mid - 1);
                else
                    return Search(key, a, mid + 1, high);
            }
        }

        public static string ProcessBinarySearch1(string inStr) =>
            TestCommon.TestTools.Process(inStr,
                (Func<long[], long[], long[]>)BinarySearch1);


        //2...............................................................................

        public static long MajorityElement2(long n, long[] a)
        {
            if (GetMajority(a.ToList<long>()) < 0)
                return 0;
            else
                return 1;
        }

        private static long GetMajority(List<long> array)
        {
            if (array.Count == 1)
                return array[0];
            if (array.Count == 2)
            {
                if (array[0] == array[1])
                    return array[0];
                else
                    return -1;
            }
            int mid = array.Count() / 2;
            long rightMajority = GetMajority(array.GetRange(0, mid));
            long leftMajority = GetMajority(array.GetRange(mid, array.Count - mid));
            if (rightMajority == leftMajority)
            {
                return rightMajority;
            }
            if (rightMajority >= 0 && leftMajority == -1)
            {
                return rightMajority;
            }
            if (leftMajority >= 0 && rightMajority == -1)
            {
                return leftMajority;
            }
            else
            {
                if (rightMajority >= 0 && leftMajority >= 0)
                {
                    int leftMajorityCount = 0;
                    int rightMajorityCount = 0;
                    foreach (var a in array)
                    {
                        if (a == rightMajority)
                            rightMajorityCount++;
                        else
                            if (a == leftMajority)
                            leftMajorityCount++;
                    }
                    if (rightMajorityCount > array.Count / 2)
                        return rightMajority;
                    if (leftMajorityCount > array.Count / 2)
                        return leftMajority;
                    else
                        return -1;
                }
                return -1;
            }
        }

        public static string ProcessMajorityElement2(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)MajorityElement2);

        //3............................................................................

        public static long[] ImprovingQuickSort3(long n, long[] a)
        {
            QuickSort3(a, 0, (int)n - 1);
            return a;
        }

        private static void QuickSort3(long[] a, int low, int high)
        {
            int i = low;
            int j = high;
            long pivot = a[(low + high) / 2];
            while (i <= j)
            {
                while (a[i] < pivot)
                {
                    i++;
                }
                while (a[j] > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    long c = a[i];
                    a[i] = a[j];
                    a[j] = c;
                    j--;
                    i++;
                }
            }

            if (low < j)
            {
                QuickSort3(a, low, j);
            }
            if (i < high)
            {
                QuickSort3(a, i, high);
            }
        }

        public static string ProcessImprovingQuickSort3(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[]>)ImprovingQuickSort3);

        //4............................................................................

        public static long NumberofInversions4(long n, long[] a)
        {
            long[] Temporary = new long[n];
            return MergeSort(a, Temporary, 0, (int)n - 1);
        }

        private static long MergeSort(long[] Array, long[] Temporary, int low, int high)
        {
            int Middle;
            long Count = 0;
            if (high > low)
            {
                Middle = (high + low) / 2;

                Count = MergeSort(Array, Temporary, low, Middle);
                Count += MergeSort(Array, Temporary, Middle + 1, high);

                Count += Merge(Array, Temporary, low, Middle + 1, high);
            }
            return Count;
        }
        private static long Merge(long[] Array, long[] Temporary, int left, int Middle, int right)
        {
            int i, j, k;
            long Count = 0;
            i = left;
            j = Middle;
            k = left;
            while ((i <= Middle - 1) && (j <= right))
            {
                if (Array[i] <= Array[j])
                {
                    Temporary[k++] = Array[i++];
                }
                else
                {
                    Temporary[k++] = Array[j++];

                    Count = Count + (Middle - i);
                }
            }

            while (i <= Middle - 1)
                Temporary[k++] = Array[i++];

            while (j <= right)
                Temporary[k++] = Array[j++];

            for (i = left; i <= right; i++)
                Array[i] = Temporary[i];
            return Count;
        }

        public static string ProcessNumberofInversions4(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)NumberofInversions4);

        //5.........................................................................

        public static long[] OrganizingLottery5(long[] points, long[] startSegments,
            long[] endSegment)
        {
            const long start = 0, point = 1, end = 2;

            List<long> temporary = new List<long>();
            temporary.AddRange(points);
            temporary.AddRange(startSegments);
            temporary.AddRange(endSegment);
            long[] AllNumbers = temporary.ToArray();

            List<long> temporary2 = new List<long>();
            temporary2.AddRange(points.Select(x => point));
            temporary2.AddRange(startSegments.Select(x => start));
            temporary2.AddRange(endSegment.Select(x => end));
            long[] types = temporary2.ToArray();

            Order(AllNumbers, types, 0, AllNumbers.Length - 1);

            for (int i = 0, j = 1; j < AllNumbers.Length; j++)
            {
                if (AllNumbers[i] != AllNumbers[j])
                {
                    if (j != i)
                    {
                        Order(types, AllNumbers, i, j - 1);
                    }
                    i++;
                    i = j;
                }
            }
            long inSegment = 0;
            Dictionary<long, long> scores = new Dictionary<long, long>();
            for (int i = 0; i < AllNumbers.Length; i++)
            {
                long test = AllNumbers[i];
                if (types[i] == start)
                    inSegment++;
                else if (types[i] == end)
                    inSegment--;
                else if (!scores.ContainsKey(AllNumbers[i]))
                    scores.Add(AllNumbers[i], inSegment);
            }
            long[] result = new long[points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                result[i] = scores[points[i]];
            }
            return result;

        }

        private static double Dis(long x1, long x2, long y1, long y2)
        {
            return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
        }
        private static void Order(long[] X, long[] Y, int low, int high)
        {
            int i = low, j = high;
            long pivot = X[(low + high) / 2];
            while (i <= j)
            {
                while (X[i] < pivot)
                {
                    i++;
                }
                while (X[j] > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    long temp = X[i];
                    X[i] = X[j];
                    X[j] = temp;
                    temp = Y[i];
                    Y[i] = Y[j];
                    Y[j] = temp;
                    i++;
                    j--;
                }

            }
            if (low < j)
            {
                Order(X, Y, low, j);
            }
            if (i < high)
            {
                Order(X, Y, i, high);
            }
        }

        public static string ProcessOrganizingLottery5(string inStr)
            => TestCommon.TestTools.Process(inStr, 
                (Func<long[], long[], long[], long[]>) OrganizingLottery5);

        //6...........................................................................

        public static double ClosestPoints6(long n, long[] xPoints, long[] yPoints)
        {
            double Distance = double.MaxValue;
            Order6(xPoints, yPoints, 0, (int)n - 1);
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n && xPoints[j] - xPoints[i] < Distance; j++)
                {
                    var example = formula(xPoints[i], xPoints[j], yPoints[i], yPoints[j]);
                    if (example < Distance)
                        Distance = example;
                }
            }
            return Math.Round(Distance, 4);
        }

        private static double formula(long x1, long x2, long y1, long y2)
        {
            return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
        }
        private static void Order6(long[] X, long[] Y, int low, int high)
        {
            int i = low, j = high;
            long pivot = X[(low + high) / 2];
            while (i <= j)
            {
                while (X[i] < pivot)
                {
                    i++;
                }
                while (X[j] > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    long c = X[i];
                    X[i] = X[j];
                    X[j] = c;
                    c = Y[i];
                    Y[i] = Y[j];
                    Y[j] = c;
                    i++;
                    j--;
                }

            }
            if (low < j)
            {
                Order6(X, Y, low, j);
            }
            if (i < high)
            {
                Order6(X, Y, i, high);
            }
        }

        public static string ProcessClosestPoints6(string inStr) =>
           TestTools.Process(inStr, (Func<long, long[], long[], double>)
               ClosestPoints6);

    }
}
