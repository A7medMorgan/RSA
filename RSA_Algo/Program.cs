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
            Console.WriteLine("Choose test to Start (simple 1 , complete 2,Enter special Massage 3)");
            int x = Convert.ToInt32(Console.ReadLine());
            if (x == 1)
            {
              string[] result=  File_RSA(File.file_simple_rsa);
              File.writeToFile(File.file_simple_rsa_output, result);
              Console.WriteLine("save success");
            }
            else if (x == 2)
            {
                string[] result = File_RSA(File.file_complete_rsa);
                File.writeToFile(File.file_complete_rsa_output, result);
                Console.WriteLine("save success");
            }
            else
            {
                string _n = "3658315382137043";
                string e = "17";
                string d = "3012726845747393";

            Replay_Massage: Console.WriteLine("Choose 1 to encrypte massage  2 for decrypte");
                x = Convert.ToInt32(Console.ReadLine());
                if (x == 1)
                {
                    Console.WriteLine("Enter the Massage Less than 4 character");
                    string M = Console.ReadLine();
                    int[] Massage = BigInteger.AsciiCode(M);
                    Console.WriteLine("N =" + _n + " || " + "E =" + e);
                    E_Massage(Massage, e, _n, 1);
                }
                else if (x == 2)
                {
                    Console.WriteLine("Enter the Encrypted Massage ");
                    string M = Console.ReadLine();
                    int[] M_arr = BigInteger.convert_CharArr_IntArr(M.ToCharArray());
                    Console.WriteLine("N =" + _n + " || " + "D =" + d);
                    E_Massage(M_arr, d, _n, 0);
                }
                else
                    goto Replay_Massage;
            }
            Retry();
            ////MileStone1();
        }
        public static string[] File_RSA(string FileName)
        {
            Stopwatch sw,Alltest;
            string N,M,EM,E,D;
                string[] lines = File.readFromFile(FileName);
                int num = Convert.ToInt32(lines[0]);
            string[] time = new string[(num / 2)+1];
            string _time;
                int n1 = 1, e = 2, m = 3, type1 = 4,n2=5,d=6,Em=7,type2=8;
            //start test
            Alltest=new Stopwatch();
            Alltest.Start();
            int w=0,z=1;
            string[] output = new string[num];
                for (int i = 0; i < num/2; i++)
                {
                    N = lines[n1];
                    E = lines[e];
                    M = lines[m];
                    D = lines[d];
                    EM = lines[Em];
                    int[] _M = BigInteger.convert_CharArr_IntArr(M.ToCharArray());
                    int[] _E = BigInteger.convert_CharArr_IntArr(E.ToCharArray());
                    int[] _N = BigInteger.convert_CharArr_IntArr(N.ToCharArray());
                    int[] _EM = BigInteger.convert_CharArr_IntArr(EM.ToCharArray());
                    int[] _D = BigInteger.convert_CharArr_IntArr(D.ToCharArray());
                sw = new Stopwatch();
                //start time
                sw.Start();
                    int[] Encrypted_m = BigInteger.RSA(_M, _E, _N);
                    // convert array of integer to string to save in file
                    string result = string.Join(string.Empty, Encrypted_m);
                    output[w] = result;
                //Encrypte
                    int[] Decrypted_m = BigInteger.RSA(_EM, _D, _N);
                    // convert array of integer to string to save in file
                    string result1 = string.Join(string.Empty, Decrypted_m);
                    output[z] = result1;
                //Decrypte
                sw.Stop();
                //stop time
                w+=2;
                z+=2;
                Console.WriteLine("TickTime Test: "+ type2 / 8+"  " + sw.Elapsed);
                _time = sw.Elapsed.ToString();
                time[i] = ("TickTime Test: " + type2 / 8 + "  " + _time).ToString();
                n1 += 8; e += 8;m += 8;n2 += 8;d += 8;Em += 8;type1 += 8;type2 += 8;
                }
            //Stop test
            Alltest.Stop();
            Console.WriteLine("TickTime Test of : " + FileName +"  "+ Alltest.Elapsed);
            time[num / 2] = ("TickTime Test of : " + FileName + "  " + Alltest.Elapsed).ToString();

            if (FileName.Equals(File.file_simple_rsa))
                File.writeToFile(File.file_simple_rsa_output_time, time);
            else
                File.writeToFile(File.file_complete_rsa_output_time,time);
            //array of string 
            return output;
        }
        public static void E_Massage(int[] Massage, string E_D, string N,int type)
        {
            //int[] Massage = BigInteger.convert_CharArr_IntArr(massage.ToCharArray());
            int[] _E_D = BigInteger.convert_CharArr_IntArr(E_D.ToCharArray());
            int[] _N = BigInteger.convert_CharArr_IntArr(N.ToCharArray());
            int[] E_M = BigInteger.RSA(Massage, _E_D, _N);
            if (type == 1)
            {
                Console.Write("\nE(M) :=  ");
                BigInteger.Display(E_M);
            }
            else
            {
               string result = BigInteger.convert_Ascii_To_String(E_M);
                Console.Write("\nM :=  ");
                Console.WriteLine(result);
            }
        }
        static void test_String_Bouns1(string m)
        {
            string e = "17", d = "3012726845747393";
            // int[] m = BigInteger.Convert_string_To_intArr("33");
            //string m = "L";
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
            Retry();
            }
        static void Retry()
        {
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
            
            string n = "3658315382137043";
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
