using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLinearList
{
    public class ListNode
    {
        private int data;
        private ListNode next;

        public ListNode Next
        {
            get { return next; }
            set { next = value; }
        }

        public int Data
        {
            get { return data; }
            set { data = value; }
        }

        public ListNode(int number)
        {
            data = number;
        }
    }


    public class LinkedLinearList
    {
        private ListNode headNode;
        private ListNode currentNode;

        public ListNode CurrentNode
        {
            get { return currentNode; }
        }

        public ListNode HeadNode
        {
            get { return headNode; }
        }

        public void Add(ListNode passedNode)
        {
            if (headNode == null)
            {
                headNode = passedNode;
                currentNode = headNode;
            }
            else
            {
                currentNode.Next = passedNode;
                currentNode = currentNode.Next;
            }
        }

        public void PrintNodes()
        {
            Console.WriteLine("Printing items in LinkedLinearList: ");
            ListNode pointer = headNode;

            while (pointer != null)
            {
                Console.WriteLine(pointer.Data);
                pointer = pointer.Next;
            }
            Console.WriteLine();
        }

        public void WriteNodes(int numberOfArguments)
        {
            Stopwatch sw = new Stopwatch();
            Console.WriteLine("Writing contents of LinkedLinearList in file...");
            try
            {
                using (StreamWriter writer = new StreamWriter("List.txt", false))
                {
                    sw.Start();

                    ListNode pointer = headNode;
                    while (pointer != null)
                    {
                        writer.WriteLine(pointer.Data);
                        pointer = pointer.Next;
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

        public void fillWithRandomData(int numberOfNodes, Random rand)
        {
            if (numberOfNodes <= 0)
            {
                throw new ArgumentOutOfRangeException("Cannot add zero or less items");
            }
            for (int nodeNumber = 0; nodeNumber < numberOfNodes; nodeNumber++)
            {
                Add(new ListNode(rand.Next()));
            }
        }

    }
}
