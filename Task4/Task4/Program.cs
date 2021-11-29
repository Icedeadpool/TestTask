using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter array file name: ");
            //string fileName = args[0];
            string fileName = Console.ReadLine();
            string[] Content = File.ReadAllLines(fileName);
            /*for (int c = 0; c < Content.Length; c++)
                Console.Write("{0}\t", Content[c]);
            Console.WriteLine();*/

            int[] nums = new int[Content.Length];
            int i, j, a, b, t=0, t1=0, t2=0;
            for (i = 0; i < Content.Length; i++)
                nums[i] = int.Parse(Content[i]);

            for (i = 0; i < nums.Length;)
            {
                for (j = 0; j < nums.Length;)
                {
                    a = nums[i];
                    b = nums[j];
                    if (a < b)
                    {
                        t1 = t1 + (b - a);
                        j++;
                    }
                    else if (a > b)
                    {
                        t1 = t1 + (a - b);
                        j++;
                    }
                    else
                    {
                        j++;
                    }
                    t2 = t1;

                }
                if (t == 0 & t2 != 0)
                {
                    t = t2;
                }
                if (t == t2)
                {
                    i++;
                }
                else if (t < t2)
                {
                    i++;
                }
                else
                {
                    t = t2;
                    i++;
                }
                t1 = 0;
            }
            Console.WriteLine(t);
            Console.ReadKey();
        }
    }
}
