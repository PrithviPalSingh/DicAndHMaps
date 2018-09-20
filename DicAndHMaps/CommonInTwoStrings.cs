using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DicAndHMaps
{
    class CommonInTwoStrings
    {
        static string twoStrings(string s1, string s2)
        {
            var magazine = s1.ToCharArray();
            var note = s2.ToCharArray();

            var dictMagazine = new Dictionary<char, int>();
            var dictNote = new Dictionary<char, int>();

            foreach (var item in magazine)
            {
                if (!dictMagazine.ContainsKey(item))
                {
                    dictMagazine.Add(item, 1);
                }
                else
                {
                    dictMagazine[item] += 1;
                }
            }

            foreach (var item in note)
            {
                if (!dictNote.ContainsKey(item))
                {
                    dictNote.Add(item, 1);
                }
                else
                {
                    dictNote[item] += 1;
                }
            }

            foreach (var item in dictNote)
            {
                if (dictMagazine.ContainsKey(item.Key))
                {
                    return "YES";
                }
            }

            return "NO";
        }
    }
}
