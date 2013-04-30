using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLinearList
{
    public class ArrayLinearList
    {
        private int[] items;
        private int capacity;               //Максималният брой елементи, които могат да се запишат в масива
        private int size;                   //Броят записани данни в масива
        private int defaultCapacity = 4;    //Ако не е указан друг размер ще бъде използван defaultCapacity по подразбиране

        public int Capacity
        {
            get { return this.items.Length; }
            set 
            {
                if (value < this.size)
                {
                    throw new ArgumentOutOfRangeException("The capacity cannot be smaller than the current size of the array");
                }

                if (value != this.items.Length)
                {
                    if (value > 0)
                    {
                        int[] array = new int[value];
                        if (this.size > 0)
                        {
                            Array.Copy(this.items, 0, array, 0, this.size);
                        }
                        this.items = array;
                    }
                }
            }
        }

        public int Size
        {
            get { return size; }
        }

        public ArrayLinearList()
        {
            items = new int[defaultCapacity];
        }

        public ArrayLinearList(int size)
        {
            if (size < 0)
            {
                throw new ArgumentOutOfRangeException("The size of the list cannot be a negative number.");
            }
            items = new int[size];
        }

        private void EnsureCapacity(int minimumCapacity)
        {
            if (this.items.Length < minimumCapacity)
            {
                if (minimumCapacity*2 < int.MaxValue)
                {
                    this.Capacity = minimumCapacity * 2;
                }
                else
                {
                    this.Capacity = int.MaxValue;
                }
                
            }
        }

        public void Add(int item)
        {
            if (size == this.items.Length)
            {
                this.EnsureCapacity(size + 1);
            }

            this.items[size] = item;
            size++;

        }

        public void PrintNodes()
        {
            Console.WriteLine("Printing items in ArrayLinearList: ");
            for (int index = 0; index < size; index++)
            {
                Console.WriteLine(items[index]);
            }
            Console.WriteLine();
        }

        public void WriteNodes(int numberOfArguments)
        {
            
            Stopwatch sw = new Stopwatch();
            Console.WriteLine("Writing contents of ArrayLinearList in file...");
            try
            {
                using (StreamWriter writer = new StreamWriter("List.txt", false))
                {
                    sw.Start();
                    for (int index = 0; index < size; index++)
                    {
                        writer.WriteLine(items[index]);
                    }
                    sw.Stop();
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Time to write {0} elements: {1} ", numberOfArguments, sw.Elapsed);
            Console.WriteLine();
        }

        public void FillWithRandomData(int numberOfNodes, Random rand)
        {
            if (numberOfNodes <= 0)
            {
                throw new ArgumentOutOfRangeException("Cannot add zero or less items");
            }
            for (int nodeNumber = 0; nodeNumber < numberOfNodes; nodeNumber++)
            {
                this.Add(rand.Next());
            }
        }
    }
}
