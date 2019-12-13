using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace RSA_Algo
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "37777393582799122964502971489896902666666668223132";
            string s2 = "3032132111742566605953265281528895604758163550161312135546";
            int[] arr1 = BigInteger.convert_CharArr_IntArr(s1.ToCharArray());
            int[] arr2 = BigInteger.convert_CharArr_IntArr(s2.ToCharArray());
            BigInteger.Make_Equle(ref arr1, ref arr2);

            int[] arr;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            //arr = BigInteger.SUB(arr1, arr2);
            arr = BigInteger.Multiply(arr1, arr2);
            sw.Stop();
            int c = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0)
                {
                    c++;
                    continue;

                }
                else
                {
                    break;
                }
            }
            Console.WriteLine("\t\t\t\t\t\tMultiplication\t\t\t\t\t\t");
            Console.WriteLine(s1);
            Console.WriteLine("*");
            Console.WriteLine(s2);
            Console.WriteLine("____________________________________________________");

            for (int i = c; i < arr.Length; i++)
            {
                Console.Write(arr[i]);
            }
            Console.WriteLine();
            Console.WriteLine("\n===================================================");
            Console.WriteLine("\nLength of result array which multiply two big integer numbers is (" + arr.Length + ")");

            Console.WriteLine("TickTime : " + sw.Elapsed);
            //string[] lines = File.readFromFile(File.file);

            //// Display the file contents by using a foreach loop.
            //Console.WriteLine("Contents of WriteLines2.txt = ");
            //foreach (string line in lines)
            //{
            //    // Use a tab to indent each line of the file.
            //    Console.WriteLine("\t" + line);
            //}

            //File.writeToFile(File.file1,lines);
        }

    }
}
