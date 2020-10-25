using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foreach_InvalidOperationException
{
    class Program
    {
        internal static List<string> Items = new List<string>();
        
        static void Main(string[] args)
        {
            ListAddDummyValues();
            ListRemoveDummyValues();
        }

        internal static void ListAddDummyValues()
        {
            for (int i = 0; i < 100; i++)
            {
                Items.Add("Dummy_" + i);
            }
        }

        internal static void ListRemoveDummyValues()
        {
            // Items.ForEach(x =>
            Items.ToList().ForEach(x =>
            {
                Items.Remove(x);
            });
        }

        internal static Dictionary<string, string> Items2 = new Dictionary<string, string>();

        internal static void DictionaryAddDummyValues2()
        {
            for (int i = 0; i < 100; i++)
            {
                Items2["Dummy_" + i] = "";
            }
        }

        internal static void DictionaryModifyDummyValues2()
        {
            // foreach (var item2 in Items2)
            foreach (var item2 in Items2.ToList())
            {
                Items2[item2.Key] = "Dummy";
            }
        }
    }
}
