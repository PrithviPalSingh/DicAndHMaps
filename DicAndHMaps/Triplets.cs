using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DicAndHMaps
{
    class Triplets
    {
        public static long countTriplets1(List<long> arr, long r)
        {
            long count = 0;
            Dictionary<long, long> dict = new Dictionary<long, long>();

            foreach (var item in arr)
            {
                if (!dict.ContainsKey(item))
                {
                    dict.Add(item, 1);
                }
                else
                {
                    dict[item] += 1;
                }

                if (r == 1)
                    continue;

                var key1 = item;
                var key2 = key1 / r;
                var key3 = key2 / r;

                if (dict.ContainsKey(key1) && dict.ContainsKey(key2) && dict.ContainsKey(key3))
                {
                    count += (dict[key2] * dict[key3]) - 1;
                }
            }

            foreach (var item in dict)
            {

                if (r == 1)
                {
                    count += Combination(item.Value, 3);
                    continue;
                }
            }

            return count;
        }

        private static long Combination(long n, long r)
        {
            long sum = 1;
            long diff = (r > (n - r)) ? r : n - r;
            for (long i = n; i > diff; i--)
            {
                sum *= i;
            }

            for (long j = (n - diff); j > 0; j--)
            {
                sum /= j;
            }
            return sum;
        }

        public static long countTriplets(List<long> arr, long r)
        {

            Dictionary<long, long> rightMap = getOccurenceMap(arr);
            Dictionary<long, long> leftMap = new Dictionary<long, long>();
            long numberOfGeometricPairs = 0;

            foreach (long val in arr)
            {
                long countLeft = 0;
                long countRight = 0;
                long lhs = 0;
                long rhs = val * r;
                if (val % r == 0)
                {
                    lhs = val / r;
                }

                long occurence = rightMap[val];
                rightMap[val] = occurence - 1L;

                if (rightMap.ContainsKey(rhs))
                {
                    countRight = rightMap[rhs];
                }
                if (leftMap.ContainsKey(lhs))
                {
                    countLeft = leftMap[lhs];
                }
                numberOfGeometricPairs += countLeft * countRight;
                insertIntoMap(leftMap, val);
            }

            return numberOfGeometricPairs;
        }

        private static Dictionary<long, long> getOccurenceMap(List<long> test)
        {
            Dictionary<long, long> occurenceMap = new Dictionary<long, long>();
            foreach (long val in test)
            {
                insertIntoMap(occurenceMap, val);
            }
            return occurenceMap;
        }

        private static void insertIntoMap(Dictionary<long, long> occurenceMap, long val)
        {
            if (!occurenceMap.ContainsKey(val))
            {
                occurenceMap.Add(val, 1L);
            }
            else
            {
                long occurence = occurenceMap[val];
                occurenceMap[val] = occurence + 1L;
            }
        }

    }
}
