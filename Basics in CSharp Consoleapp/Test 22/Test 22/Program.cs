using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_22
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList();
            list.Add("a");
            list.Add("b");
            list.Add("c");
            list.Add("d");
            list.Add("e");

            //ArrayList FUnctions
            Console.WriteLine("Array Elements");
            foreach (var i in list)
                Console.WriteLine(i);
            Console.WriteLine();
            Console.WriteLine("Index of b is "+list.IndexOf("b"));
            Console.WriteLine();
            Console.WriteLine("Remove element using removeat function");
            list.RemoveAt(2);
            foreach (var i in list)
                Console.WriteLine(i);
            Console.WriteLine();
            Console.WriteLine("add element to 2nd position");
            list.Insert(2,"f");
            foreach (var i in list)
                Console.WriteLine(i);
            Console.WriteLine();
            Console.WriteLine("To check list contain the element j");
            Console.WriteLine(list.Contains("j"));
            Console.WriteLine();
            Console.WriteLine("Reverse a list");
            list.Reverse();
            foreach (var i in list)
                Console.WriteLine(i);
            Console.WriteLine();
            Console.WriteLine("Sorted list");
            list.Sort();
            foreach (var i in list)
                Console.WriteLine(i);
            Console.WriteLine();
            Console.WriteLine("Insert element at the 2nd position");
            list.Insert(2, "c");
            foreach (var i in list)
                Console.WriteLine(i);
        }
    }
}