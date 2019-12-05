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
                //int_arr[i] = Convert.ToInt32(ch_arr[i
                string s= ch_arr[i].ToString();
               int_arr[i] = Int32.Parse(s);

            }
            return int_arr;
        }
        // must arr1 be >= arr2
        //public static int[] Add(int[] arr1, int[] arr2)
        //{
        //    int size;
        //    int[] R;
        //    int r=0;
        //    int sub;
        //    bool carry = false;
        // //   if (arr1.Length > arr2.Length)
        // //   {
        //        R = new int[arr1.Length + 1];
        //        size = arr1.Length;
        //        sub = arr1.Length - arr2.Length;
        //    //   }
        //    //else {
        //    //    R = new int[arr2.Length + 1];
        //    //    size = arr2.Length;
        //    //    sub = arr1.Length - arr2.Length;
        //    //}
        //    for (int i = size - 1; i >= 0; i--)
        //    {

        //        if (carry) { r += 1; carry = false; }
        //        if (i - 1 == -1) { r += arr1[i]; }
        //        else
        //        {
        //            r += arr1[i] + arr2[i - sub];

        //        }
        //        if (r > 9) carry = true;
        //        r = r % 10;
        //        R[i + 1] = r;

        //        r = 0;

        //    }
        //    return R;
        //}

        public static int[] ADD(int[] arr1, int[] arr2)
        {
            int size;
            int[] R, Demo;
            int r = 0;
            int sub;
            bool carry = false;
            if (arr1.Length > arr2.Length)
            {
                size = arr1.Length;
                Demo = new int[size];
                sub = arr1.Length - arr2.Length;
                for (int i = size - 1; i >= 0; i--)
                {
                    if (i - sub != -1)
                        Demo[i] = arr2[i - sub];
                    else break;
                }
                R = new int[arr1.Length + 1];
            }
            else
            {
                size = arr2.Length;
                Demo = new int[size];
                sub = arr2.Length - arr1.Length;
                for (int i = size - 1; i >= 0; i--)
                {
                    if (i - sub != -1)
                        Demo[i] = arr1[i - sub];
                    else break;
                }
                R = new int[arr2.Length + 1];
            }
            for (int i = size - 1; i >= 0; i--)
            {
                if (carry) { r += 1; carry = false; }
                if (arr1.Length > arr2.Length)
                r += arr1[i] + Demo[i];
                else
                    r += Demo[i] +arr2[i];

                if (r > 9) carry = true;
            r = r % 10;
            R[i + 1] = r;

            r = 0;
        }
            if (carry) R[0] = 1;

            return R;
        }

        public static int[] SUB(int[] arr1, int[] arr2)
        {
            int size;
            int[] R, Demo;
            int r = 0;
            int sub;
            int carry = 0;
            if (arr1.Length > arr2.Length)
            {
                size = arr1.Length;
                Demo = new int[size];
                sub = arr1.Length - arr2.Length;
                for (int i = size - 1; i >= 0; i--)
                {
                    if (i - sub != -1)
                        Demo[i] = arr2[i - sub];
                    else break;
                }
                R = new int[arr1.Length + 1];
            }
            else
            {
                size = arr2.Length;
                Demo = new int[size];
                sub = arr2.Length - arr1.Length;
                for (int i = size - 1; i >= 0; i--)
                {
                    if (i - sub != -1)
                        Demo[i] = arr1[i - sub];
                    else break;
                }
                R = new int[arr2.Length + 1];
            }
            BigInteger.Display(Demo);
            for (int i = size - 1; i >= 0; i--)
            {
               // if (carry==1) { r += 1; carry = 0; }
                if (arr1.Length > arr2.Length)
                    r = arr1[i] - Demo[i] -carry;
                else
                    r = Demo[i] - arr2[i] -carry;

                if (r < 0) { r += 10; carry = 1; }
                else carry = 0;
               // r = r % 10;
                R[i + 1] = r;
                r = 0;
            }
            return R;
        }
        public static void Display(int[] Num)
        {
            foreach (int n in Num)
            {
                Console.Write(n);
            }
            Console.WriteLine();
        }
        public void Display()
        {
            foreach (int n in pub_arr)
            {
                Console.Write(n);
            }
            Console.WriteLine();
            Console.WriteLine();
        }


    }
}
