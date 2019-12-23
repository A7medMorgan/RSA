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
            test_String_Bouns1();
            //MileStone1();
        }
        static void test_String_Bouns1()
        {
            string e = "17", d = "281393";
            // int[] m = BigInteger.Convert_string_To_intArr("33");
            string m = "Iu";
            // BigInteger.Display(m);
            Console.WriteLine("m\t" + m);

            int[] a = BigInteger.AsciiCode(m);
            string result = string.Join(string.Empty, a);
            int[] arr = SimpleTest(result, e);

            Console.WriteLine("Decrypte");
            result = string.Join(string.Empty, arr);

            arr = SimpleTest(result, d);

            result = BigInteger.convert_Ascii_To_String(arr);
            Console.WriteLine(result);

        }
        #region MileStone1
        static void MileStone1()
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
                        sw.Start();
                        int[] arr = BigInteger.ADD(arr1, arr2);
                        sw.Stop();
                        string result = string.Join(string.Empty, arr);
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
                        str1[y] = " ";
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
                        sw.Start();
                        int[] arr = BigInteger.SUB(arr1, arr2);
                        sw.Stop();
                        string result = string.Join(string.Empty, arr);
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
                        str1[y] = " ";
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
                        sw.Start();
                        int[] arr = BigInteger.Multiply(arr1, arr2);
                        sw.Stop();
                        string result = string.Join(string.Empty, arr);
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
                        str1[y] = " ";
                        j1 += 2;
                        y += 2;
                    }
                    File.writeToFile(File.file_mul_output, str1);
                    Console.WriteLine("Save Success");
                }




                Console.WriteLine("To Try another choise Press: (Y)");
                string q;
                q = Console.ReadLine();
                if (q == "y")
                {
                    Main(null);
                }
                else
                {
                    return;
                }
            }
        #endregion
        #region Test
        static int[] SimpleTest(string _M , string _e_d)
        {
            string m = _M;
            
            string n = "300217";
            Console.WriteLine("Massage \t"+m);
            int[] M = BigInteger.convert_CharArr_IntArr(m.ToCharArray());
            int[] E_D = BigInteger.convert_CharArr_IntArr(_e_d.ToCharArray());
            int[] N = BigInteger.convert_CharArr_IntArr(n.ToCharArray());

            int[] E_M = BigInteger.RSA(M, E_D, N);

            Console.Write("Eencryption(M)\t");
            foreach (int i in E_M)
            {

                Console.Write(i);
            }
            Console.WriteLine();
            return E_M;
        }
        #endregion
    }
}
