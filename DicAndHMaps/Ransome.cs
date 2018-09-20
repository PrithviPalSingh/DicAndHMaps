using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DicAndHMaps
{
    class Ransome
    {
        public static void checkMagazine(string[] magazine, string[] note)
        {
            var dictMagazine = new Dictionary<string, int>();
            var dictNote = new Dictionary<string, int>();

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
                if (!dictMagazine.ContainsKey(item.Key) || dictMagazine[item.Key] < item.Value)
                {
                    Console.WriteLine("No");
                    return;
                }                
            }

            Console.WriteLine("Yes");
        }
    }
}
