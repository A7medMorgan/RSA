using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA_Algo
{
    class BigInteger
    {
        //:public
        public string text;
        public int[] pub_arr;
        //:private
        

        public static int[] convert(char [] ch_arr)
        {
           int [] int_arr = new int[ch_arr.Length]; // O(1)
            for (int i = 0; i < int_arr.Length; i++) // O(N)
            {
                int_arr[i] = Convert.ToInt32(ch_arr[i]);
            }
            return int_arr;
        }
        // must arr1 be >= arr2
        public static int[] Add(int[] arr1, int[] arr2)  
        {
            int[] result = new int[arr1.Length];
            for (int i = 0; i < arr1.Length; i++) // O(N)
            {
                if (arr2.Length > i)
                {
                    result[i] = arr1[i] + arr2[i];

                }
                else {
                    result[i] = arr1[i];
                }
            }
            return result;
        }

        public static void Display(int[] Num)
        {
            foreach (int n in Num)
            {
                Console.Write(n + "\t");
            }
            Console.WriteLine();
        }
        public void Display()
        {
            foreach (int n in pub_arr)
            {
                Console.Write(n + "\t");
            }
            Console.WriteLine();
        }


    }
}
