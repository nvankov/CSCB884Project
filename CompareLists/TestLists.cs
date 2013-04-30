using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomLinearList;

namespace CompareLists
{
    public static class TestLists
    {
        private static void FillWithTestData(List<int> list, int numberOfNodes, int[] array)
        {
            if (numberOfNodes <= 0)
            {
                throw new ArgumentOutOfRangeException("Cannot add zero or less items");
            }

            for (int nodeNumber = 0; nodeNumber < numberOfNodes; nodeNumber++)
            {
                list.Add(array[nodeNumber]);
            }
        }

        private static void FillWithTestData(LinkedLinearList list, int numberOfNodes, int[] array)
        {
            if (numberOfNodes <= 0)
            {
                throw new ArgumentOutOfRangeException("Cannot add zero or less items");
            }

            for (int nodeNumber = 0; nodeNumber < numberOfNodes; nodeNumber++)
            {
                list.Add(new ListNode(array[nodeNumber]));
            }
        }

        private static void FillWithTestData(ArrayLinearList list, int numberOfNodes, int[] array)
        {
            if (numberOfNodes <= 0)
            {
                throw new ArgumentOutOfRangeException("Cannot add zero or less items");
            }

            for (int nodeNumber = 0; nodeNumber < numberOfNodes; nodeNumber++)
            {
                list.Add(array[nodeNumber]);
            }
        }

        public static void FillList(List<int> list, int numberOfArguments, int[] randArray)
        {
            Stopwatch sw = new Stopwatch();
            Console.WriteLine("Filling List<T> with {0} random items...", numberOfArguments);
            sw.Start();
            FillWithTestData(list, numberOfArguments, randArray);
            sw.Stop();
            Console.WriteLine("Finished. Time elapsed: {0}", sw.Elapsed);
            Console.WriteLine();
            sw.Reset();
        }

        public static void FillList(LinkedLinearList list, int numberOfArguments, int[] randArray)
        {
            Stopwatch sw = new Stopwatch();
            Console.WriteLine("Filling LinkedLinearList with {0} random items...", numberOfArguments);
            sw.Start();
            FillWithTestData(list, numberOfArguments, randArray);
            sw.Stop();
            Console.WriteLine("Finished. Time elapsed: {0}", sw.Elapsed);
            Console.WriteLine();
            sw.Reset();
        }

        public static void FillList(ArrayLinearList list, int numberOfArguments, int[] randArray)
        {
            Stopwatch sw = new Stopwatch();
            Console.WriteLine("Filling ArrayLinearList with {0} random items...", numberOfArguments);
            sw.Start();
            FillWithTestData(list, numberOfArguments, randArray);
            sw.Stop();
            Console.WriteLine("Finished. Time elapsed: {0}", sw.Elapsed);
            Console.WriteLine();
            sw.Reset();
        }
    }
}
