using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA_Algo
{
    class BigInteger
    {
        // int s = (int)s1[0] - '0';
        //:public
        public string text;
        public int[] pub_arr;
        //:private
        

        public static int[] convert_CharArr_IntArr(char [] ch_arr)
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
        public static int makeEqualLength(ref string str1,ref string str2)
        {
            int len1 = str1.Length;
            int len2 = str2.Length;
            if (len1 < len2)
            {
                for (int i = 0; i < len2 - len1; i++)
                    str1 = '0' + str1;
                return len2;
            }
            else if (len1 > len2)
            {
                for (int i = 0; i < len1 - len2; i++)
                    str2 = '0' + str2;
            }
            return len1; // If len1 >= len2 
        }

        public static int[] ADD(int[] arr1, int[] arr2,int size)
        {
            int[] R;
            int result = 0;
            bool carry_flag = false;

            R = new int[size+ 1];
            for (int i = size - 1; i >= 0; i--)
            {
                if (carry_flag) { result += 1; carry_flag = false; }
                result += arr1[i] + arr2[i];
                if (result > 9) carry_flag = true;
            result = result % 10;
            R[i + 1] = result;

            result = 0;
            }
            if (carry_flag) R[0] = 1;
            return R;
        }

        public static int[] SUB(int[] arr1, int[] arr2,int size)// arr1 -arr2 only???
        {
            int[] R;
            int result = 0;
            int carry_Amout = 0;
                R = new int[size];
            for (int i = size - 1; i >= 0; i--)
            {
                    result = arr1[i] - arr2[i] -carry_Amout;
                if (result < 0) { result += 10; carry_Amout = 1; }
                else carry_Amout = 0;
               // r = r % 10;
                R[i] = result;
                result = 0;
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
