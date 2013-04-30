using CustomLinearList;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace CompareLists
{
    class CompareLists
    {
        private static void FillArray(int[] array, Random rand)
        {
            for (int index = 0; index < array.Length; index++)
            {
                array[index] = rand.Next();
            }
        }

        static void Main(string[] args)
        {
            int[] argumentsToTest = { 1, 200, 500, 1000, 5000, 10000 };
            int numberOflists = argumentsToTest.Length;

            List<int>[] list = new List<int>[numberOflists];
            LinkedLinearList[] linkedList = new LinkedLinearList[numberOflists];
            ArrayLinearList[] arrayList = new ArrayLinearList[numberOflists];

            Random rand = new Random();

            //Взимаме последният елемент от argumentsToTest, така randArray ще може да побере всички данни
            int[] randArray = new int[argumentsToTest[argumentsToTest.Length - 1]]; 

            FillArray(randArray, rand);

            //Тестване на бързината при пълнене с данни
            for (int i = 0; i < numberOflists; i++)
            {
                list[i] = new List<int>();
                TestLists.FillList(list[i], argumentsToTest[i], randArray);

                linkedList[i] = new LinkedLinearList();
                TestLists.FillList(linkedList[i], argumentsToTest[i], randArray);

                arrayList[i] = new ArrayLinearList();
                TestLists.FillList(arrayList[i], argumentsToTest[i], randArray);
                
            }

            //Тестване на бързината при записване на данни във файл
            for (int index = 0; index < numberOflists; index++)
            {
                TestWritingLists.WriteListItems(list[index], argumentsToTest[index]);
                linkedList[index].WriteNodes(argumentsToTest[index]);
                arrayList[index].WriteNodes(argumentsToTest[index]);
            }
        }
    }
}
