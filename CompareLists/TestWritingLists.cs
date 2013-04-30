using CustomLinearList;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareLists
{
    public static class TestWritingLists
    {
        public static void WriteListItems(List<int> list, int numberOfArguments)
        {
            Stopwatch sw = new Stopwatch();
            Console.WriteLine("Writing contents of List<T> in file...");

            try
            {
                using (StreamWriter writer = new StreamWriter("List.txt", false))
                {
                    sw.Start();
                    foreach (var item in list)
                    {
                        writer.Write("{0} ",item);
                    }
                    sw.Stop();
                    Console.WriteLine("Time to write {0} elements: {1} ", numberOfArguments, sw.Elapsed);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();
        }
    }
}
