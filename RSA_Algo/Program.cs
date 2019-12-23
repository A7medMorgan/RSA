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
            //Console.WriteLine("Choose test to Start (simple 1 , complete 2)");
            //int x = Convert.ToInt32(Console.ReadLine());
            //if (x == 1)
            //    File_RSA(File.file_simple_rsa);
            //else
            //    File_RSA(File.file_complete_rsa);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string M = "41766942386500566296578237070670959299719447915305139877556131342637463900048558377157395064819754504877734317556821079";
            string E = "22397637870882549517368596622641300924171095020557753582603446902846197377658196974714575577237681892436409853219169457";
            string N = "47594980475625417724408267823112764463863576918685226363032787239910118740004860624166859668486833021538759738968887527";
            int[] _M = BigInteger.convert_CharArr_IntArr(M.ToCharArray());
            int[] _E = BigInteger.convert_CharArr_IntArr(E.ToCharArray());
            int[] _N = BigInteger.convert_CharArr_IntArr(N.ToCharArray());

            BigInteger.Display(BigInteger.RSA(_M, _E, _N));
            sw.Stop();
            // test_String_Bouns1();
            //MileStone1();
            Console.WriteLine("TickTime : " + sw.Elapsed);
        }
        public static void File_RSA(string FileName)
        {
            Stopwatch sw,Alltest;
            string N,M,EM,E,D;
                string[] lines = File.readFromFile(FileName);
                int num = Convert.ToInt32(lines[0]);
                
                int n1 = 1, e = 2, m = 3, type1 = 4,n2=5,d=6,Em=7,type2=8;
            //start test
            Alltest=new Stopwatch();
            Alltest.Start();
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
                //Encrypte
                    int[] Decrypted_m = BigInteger.RSA(_EM, _D, _N);
                //Decrypte
                sw.Stop();
                //stop time
                Console.WriteLine("TickTime Test%d: " + sw.Elapsed,num/2);
                n1 += 8; e += 8;m += 8;n2 += 8;d += 8;Em += 8;type1 += 8;type2 += 8;
                }
            //Stop test
            Alltest.Stop();
            Console.WriteLine("TickTime Test of %s: " + Alltest.Elapsed,FileName);

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
