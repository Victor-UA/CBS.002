using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBS._002.Task00._01
{
    class Program
    {
        //Task00-01
        //Create MyLinkedList
        static void Main(string[] args)
        {
            IMyLinkedList<int> myLList = new MyLinkedList<int>
            {
                1,2,3,4,5
            };

            Console.WriteLine("\n   After Create\n");
            Console.WriteLine(myLList);

            myLList.Add(6);
            myLList.AddAfter(myLList.First, 7);
            myLList.AddBefore(myLList.Last, 8);

            Console.WriteLine("\n   After Add\n");
            Console.WriteLine(myLList);

            myLList.Remove(1);
            myLList.Remove(myLList.First.Next);

            Console.WriteLine("\n   After Remove\n");
            Console.WriteLine(myLList);

            myLList.Clear();
            Console.WriteLine("\n   After Clear()\n");

            Console.WriteLine(myLList);

            Console.ReadKey();
        }
    }
}
