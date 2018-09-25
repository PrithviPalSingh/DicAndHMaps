using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DicAndHMaps
{
    class FrequencyQueries
    {
        public static List<int> freqQuery(List<int[]> queries)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            Dictionary<int, int> freqCounter = new Dictionary<int, int>();
            List<int> finalList = new List<int>();
            foreach (var outerItem in queries)
            {
                switch (outerItem[0])
                {
                    case 1:
                        insertIntoMap(dict, outerItem[1], freqCounter);
                        break;
                    case 2:
                        decrementCountInMap(dict, outerItem[1], freqCounter);
                        break;
                    case 3:
                        IsFrequenyMatching(dict, outerItem[1], finalList, freqCounter);
                        break;
                }
            }

            return finalList;
        }

        private static void insertIntoMap(Dictionary<int, int> occurenceMap, int val, Dictionary<int, int> freqCounter)
        {
            if (occurenceMap.ContainsKey(val))
            {
                if (freqCounter.ContainsKey(occurenceMap[val]))
                {
                    if (freqCounter[occurenceMap[val]] > 1)
                        freqCounter[occurenceMap[val]] -= 1;
                    else
                        freqCounter.Remove(occurenceMap[val]);
                }

                occurenceMap[val] += 1;
            }
            else
            {
                occurenceMap.Add(val, 1);
            }            

            if (!freqCounter.ContainsKey(occurenceMap[val]))
            {
                freqCounter.Add(occurenceMap[val], 1);
            }
            else
            {
                freqCounter[occurenceMap[val]] += 1;
            }
            
        }

        private static void decrementCountInMap(Dictionary<int, int> occurenceMap, int val, 
            Dictionary<int, int> freqCounter)
        {
            if (occurenceMap.ContainsKey(val))
            {
                if (freqCounter.ContainsKey(occurenceMap[val]))
                {
                    if (freqCounter[occurenceMap[val]] > 1)
                        freqCounter[occurenceMap[val]] -= 1;
                    else
                        freqCounter.Remove(occurenceMap[val]);
                }

                if (occurenceMap[val] > 1)
                    occurenceMap[val] -= 1;
                else
                    occurenceMap.Remove(val);
            }

            if (occurenceMap.ContainsKey(val))
            {
                if (!freqCounter.ContainsKey(occurenceMap[val]))
                {
                    freqCounter.Add(occurenceMap[val], 1);
                }
                else
                {
                    freqCounter[occurenceMap[val]] += 1;
                }
            }
        }

        private static void IsFrequenyMatching(Dictionary<int, int> occurenceMap, int freq, 
            List<int> finalList, Dictionary<int,int> freqCounter)
        {
            if (!freqCounter.ContainsKey(freq))
            {
                finalList.Add(0);
            }
            else
            {
                finalList.Add(1);
            }
        }
    }
}
