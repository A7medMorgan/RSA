using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA_Algo
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "9000";
            string s2 = "3";
            int[] arr1 = BigInteger.convert_CharArr_IntArr(s1.ToCharArray());
            int[] arr2 = BigInteger.convert_CharArr_IntArr(s2.ToCharArray());
            BigInteger.Make_Equle(ref arr1,ref arr2);
            int []arr= BigInteger.Multiply_Morgan(arr1, arr2);
            foreach (int i in arr)
            {
                Console.Write(i);
            }
            Console.WriteLine("\n" + arr.Length);




            //int size = BigInteger.Even_Length(ref arr);
            //int[] x1, x2;
            //x1 = new int[size];
            //x2 = new int[size];
            //Console.WriteLine(arr.Length);
            //BigInteger.Divide_into2Array(ref x1, ref x2, ref arr, size);
            //// BigInteger.Add_Zero_onLeft(ref arr);
            //Array.Reverse(arr);
            //Console.WriteLine(arr[0] + " " + arr[1] + " " + arr.Length);
            //Console.WriteLine(x1[0] + " " + x2[0] + " " + x1[1] + " " + x2[1]);

            //BigInteger big1 = new BigInteger();
            //File f1 = new File();

           

            ////string s1 = "15", s2 = "15";
            //BigInteger.makeEqualLength(ref s1,ref s2);
            ////Console.WriteLine(s1 +"\n"+s2);
           
            //big1.pub_arr = BigInteger.ADD(arr1,arr2);

            // big1.Display();





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
