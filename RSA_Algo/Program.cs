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

            //string s1 = "377773935827991229645029714898969028";
            //string s2 = "301174256660595384532197942652815288956047581636";
            //int[] arr1 = BigInteger.convert_CharArr_IntArr(s1.ToCharArray());
            //int[] arr2 = BigInteger.convert_CharArr_IntArr(s2.ToCharArray());
            //BigInteger.Make_Equle(ref arr1,ref arr2);
            //int res1,res2 = 0;

            //res1 =System.Environment.TickCount &Int32.MaxValue ;
            //int[] arr = BigInteger.Multiply(arr1, arr2);
            //res2 = System.Environment.TickCount &Int32.MaxValue;
            //int[] v = BigInteger.convert(arr);
            //for(int i=0;i<v.Length;i++)
            //{
            //    Console.Write(v[i]);
            //}
            //Console.WriteLine();
            ////int c = 0;
            ////for(int i=0;i<arr.Length;i++)
            ////{
            ////    if (arr[i] == 0)
            ////    {
            ////        c++;
            ////        continue;

            ////    }
            ////    else
            ////    {
            ////        break;
            ////    }
            ////}
            ////int[] v = new int[arr.Length - c];
            ////int t = 0;
            ////for (int i = c; i < arr.Length; i++)
            ////{
            ////    v[t] = arr[i];
            ////    t++;
            ////}
            ////Console.WriteLine();
            ////for (int i = 0; i < v.Length; i++)
            ////{
            ////    Console.Write(v[i]);
            ////}
            ////Console.WriteLine();
            //int result = res2 - res1;
            //string r = result.ToString();
            //Console.WriteLine(r);

            //foreach (int i in arr)
            //{
            //    Console.Write(i);
            //}
            //Console.WriteLine("\n" + arr.Length);
            Console.WriteLine("please enter the number of operation do you want to check : ");
            Console.WriteLine("to add press (1) ");
            Console.WriteLine("to subtract press (2) ");
            Console.WriteLine("to multiply press (3) ");
            int x = Convert.ToInt32(Console.ReadLine());
            if (x == 1)
            {
                string[] lines = File.readFromFile(File.file_add_input);

                //// Display the file contents by using a foreach loop.
                //Console.WriteLine("Contents of WriteLines2.txt = ");
                //foreach (string line in lines)
                //{
                //    // Use a tab to indent each line of the file.
                //    Console.WriteLine("\t" + line);
                //}
                // File.writeToFile(File.file1, lines);

                int num = Convert.ToInt32(lines[0]);
                string[] str = new string[num];
                int j = 2, k = 3;
                Stopwatch sw = new Stopwatch();
                sw.Start();
                for (int i = 0; i < num; i++)
                {
                    string s1 = lines[j];
                    string s2 = lines[k];
                    int[] arr1 = BigInteger.convert_CharArr_IntArr(s1.ToCharArray());
                    int[] arr2 = BigInteger.convert_CharArr_IntArr(s2.ToCharArray());
                    BigInteger.Make_Equle(ref arr1, ref arr2);
                    int[] arr = BigInteger.ADD(arr1, arr2);
                    int[] v = BigInteger.convert(arr);
                    string result = string.Join(string.Empty, v);
                    str[i] = result;
                    j += 3;
                    k += 3;
                }
                sw.Stop();
                Console.WriteLine("TickTime : " + sw.Elapsed);
                string[] str1 = new string[num * 2];
                int j1 = 0; int y = 1;
                for (int i = 0; i < num; i++)
                {
                    str1[j1] = str[i];
                    str1[y] = "    ";
                    j1 += 2;
                    y += 2;
                }
                File.writeToFile(File.file_add_output, str1);
                Console.WriteLine("Congratulations");
            }
            else if (x == 2)
            {
                string[] lines = File.readFromFile(File.file_sub_input);

                //// Display the file contents by using a foreach loop.
                //Console.WriteLine("Contents of WriteLines2.txt = ");
                //foreach (string line in lines)
                //{
                //    // Use a tab to indent each line of the file.
                //    Console.WriteLine("\t" + line);
                //}
                // File.writeToFile(File.file1, lines);

                int num = Convert.ToInt32(lines[0]);
                string[] str = new string[num];
                int j = 2, k = 3;
                Stopwatch sw = new Stopwatch();
                sw.Start();
                for (int i = 0; i < num; i++)
                {
                    string s1 = lines[j];
                    string s2 = lines[k];
                    int[] arr1 = BigInteger.convert_CharArr_IntArr(s1.ToCharArray());
                    int[] arr2 = BigInteger.convert_CharArr_IntArr(s2.ToCharArray());
                    BigInteger.Make_Equle(ref arr1, ref arr2);
                    int[] arr = BigInteger.SUB(arr1, arr2);
                    int[] v = BigInteger.convert(arr);
                    string result = string.Join(string.Empty, v);
                    str[i] = result;
                    j += 3;
                    k += 3;
                }
                sw.Stop();
                Console.WriteLine("TickTime : " + sw.Elapsed);
                string[] str1 = new string[num * 2];
                int j1 = 0; int y = 1;
                for (int i = 0; i < num; i++)
                {
                    str1[j1] = str[i];
                    str1[y] = "    ";
                    j1 += 2;
                    y += 2;
                }
                File.writeToFile(File.file_sub_output, str1);
                Console.WriteLine("Congratulations");
            }
            else
            {
                string[] lines = File.readFromFile(File.file_mul_input);

                //// Display the file contents by using a foreach loop.
                //Console.WriteLine("Contents of WriteLines2.txt = ");
                //foreach (string line in lines)
                //{
                //    // Use a tab to indent each line of the file.
                //    Console.WriteLine("\t" + line);
                //}
                // File.writeToFile(File.file1, lines);

                int num = Convert.ToInt32(lines[0]);
                string[] str = new string[num];
                int j = 2, k = 3;
                Stopwatch sw = new Stopwatch();
                sw.Start();
                for (int i = 0; i < num; i++)
                {
                    string s1 = lines[j];
                    string s2 = lines[k];
                    int[] arr1 = BigInteger.convert_CharArr_IntArr(s1.ToCharArray());
                    int[] arr2 = BigInteger.convert_CharArr_IntArr(s2.ToCharArray());
                    BigInteger.Make_Equle(ref arr1, ref arr2);
                    int[] arr = BigInteger.Multiply(arr1, arr2);
                    int[] v = BigInteger.convert(arr);
                    string result = string.Join(string.Empty, v);
                    str[i] = result;
                    j += 3;
                    k += 3;
                }
                sw.Stop();
                Console.WriteLine("TickTime : " + sw.Elapsed);
                string[] str1 = new string[num * 2];
                int j1 = 0; int y = 1;
                for (int i = 0; i < num; i++)
                {
                    str1[j1] = str[i];
                    str1[y] = "    ";
                    j1 += 2;
                    y += 2;
                }
                File.writeToFile(File.file_mul_output, str1);
                Console.WriteLine("Congratulations");
            }

        }

    }
}
