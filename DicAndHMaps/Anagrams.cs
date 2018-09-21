using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DicAndHMaps
{
    class Anagrams
    {
        public static int sherlockAndAnagrams(string s)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            int count = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (!dict.ContainsKey(s.Substring(i, 1)))
                {
                    dict.Add(s.Substring(i, 1), 1);
                }
                else
                {
                    dict[s.Substring(i, 1)] += 1;                    
                }

                for (int j = i + 1; j < s.Length; j++)
                {
                    var temp = s.Substring(i, j + 1 - i);

                    if (temp != s)
                    {
                        temp = Sort(temp);
                        if (!dict.ContainsKey(temp))
                        {
                            dict.Add(temp, 1);
                        }
                        else
                        {
                            dict[temp] += 1;                           
                        }
                    }
                }
            }

            foreach (var item in dict)
            {
                var j = item.Value;
                count += j * (j - 1) / 2;
            }

            return count;
        }

        private static string Sort(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Sort(charArray);
            return new string(charArray);
        }
    }
}
