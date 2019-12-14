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
            Console.WriteLine("please enter the number of operation do you want to check : ");
            Console.WriteLine("to add press (1) ");
            Console.WriteLine("to subtract press (2) ");
            Console.WriteLine("to multiply press (3) ");
            int x = Convert.ToInt32(Console.ReadLine());
            if (x == 1)
            {
                string[] lines = File.readFromFile(File.file_add_input);

                int num = Convert.ToInt32(lines[0]);
                string[] str = new string[num];
                int j = 2, k = 3;
                Stopwatch sw = new Stopwatch();
                
                for (int i = 0; i < num; i++)
                {
                    string s1 = lines[j];
                    string s2 = lines[k];
                    int[] arr1 = BigInteger.convert_CharArr_IntArr(s1.ToCharArray());
                    int[] arr2 = BigInteger.convert_CharArr_IntArr(s2.ToCharArray());
                    BigInteger.Make_Equle(ref arr1, ref arr2);
                    sw.Start();
                    int[] arr = BigInteger.ADD(arr1, arr2);
                    sw.Stop();
                    int[] v = BigInteger.convert(arr);
                    string result = string.Join(string.Empty, v);
                    str[i] = result;
                    j += 3;
                    k += 3;
                }
                
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
                Console.WriteLine("Save Success");
            }
            else if (x == 2)
            {
                string[] lines = File.readFromFile(File.file_sub_input);


                int num = Convert.ToInt32(lines[0]);
                string[] str = new string[num];
                int j = 2, k = 3;
                Stopwatch sw = new Stopwatch();
                
                for (int i = 0; i < num; i++)
                {
                    string s1 = lines[j];
                    string s2 = lines[k];
                    int[] arr1 = BigInteger.convert_CharArr_IntArr(s1.ToCharArray());
                    int[] arr2 = BigInteger.convert_CharArr_IntArr(s2.ToCharArray());
                    BigInteger.Make_Equle(ref arr1, ref arr2);
                    sw.Start();
                    int[] arr = BigInteger.SUB(arr1, arr2);
                    sw.Stop();
                    int[] v = BigInteger.convert(arr);
                    string result = string.Join(string.Empty, v);
                    str[i] = result;
                    j += 3;
                    k += 3;
                }
                
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
                Console.WriteLine("Save Success");
            }
            else
            {
                string[] lines = File.readFromFile(File.file_mul_input);

                int num = Convert.ToInt32(lines[0]);
                string[] str = new string[num];
                int j = 2, k = 3;
                Stopwatch sw = new Stopwatch();
                for (int i = 0; i < num; i++)
                {
                    string s1 = lines[j];
                    string s2 = lines[k];
                    int[] arr1 = BigInteger.convert_CharArr_IntArr(s1.ToCharArray());
                    int[] arr2 = BigInteger.convert_CharArr_IntArr(s2.ToCharArray());
                    BigInteger.Make_Equle(ref arr1, ref arr2);
                    sw.Start();
                    int[] arr = BigInteger.Multiply(arr1, arr2);
                    sw.Stop();
                    int[] v = BigInteger.convert(arr);
                    string result = string.Join(string.Empty, v);
                    str[i] = result;
                    j += 3;
                    k += 3;
                }
                
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
                Console.WriteLine("Save Success");
            }




            Console.WriteLine("To Try another choise Press: (Y)");
            string q;
            q=Console.ReadLine();
            if (q == "y")
            {
                Main(null);
            }
            else {
                return;
            }

        }

    }
}
