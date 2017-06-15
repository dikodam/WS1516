using System;
using System.Collections.Generic;

namespace WS1516
{
    class Program
    {
        public static void Main(string[] args)
        {
            StackAndOrderdList<string> list = new StackAndOrderdList<string>();

            list.Add("obst");
            list.Add("birne");
            list.Add("apfel");
            list.Add("ananas");

            Console.WriteLine("Stack:");
            foreach (string number in list.GetStackEnumerator())
            {
                Console.WriteLine(number);
            }
            Console.WriteLine("");

            Console.WriteLine("Ordered:");
            foreach (string number in list.GetSortedEnumerator())
            {
                Console.WriteLine(number);
            }
            Console.WriteLine("");
        }
    }
}