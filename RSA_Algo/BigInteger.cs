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
        

        public static int[] convert_CharArr_IntArr(char [] ch_arr) //O(N)
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
                for (int i = 0; i < len2 - len1; i++) //O(N)
                    str1 = '0' + str1;
                return len2;
            }
            else if (len1 > len2)   
            {
                for (int i = 0; i < len1 - len2; i++)   //O(N)
                    str2 = '0' + str2;
            }
            return len1; // If len1 >= len2 
        }

        public static int[] ADD(int[] arr1, int[] arr2,int size)   //O(N)
        {
            int[] R;        // O(1)
            int result = 0;    // O(1)
            bool carry_flag = false;  // O(1)

            R = new int[size+ 1];  // O(1)
            for (int i = size - 1; i >= 0; i--)   //O(N * {O(1)})
            {
                if (carry_flag) { result += 1; carry_flag = false; }  // O(1)
                result += arr1[i] + arr2[i];  // O(1)
                if (result > 9) carry_flag = true;  // O(1)
                result = result % 10;      // O(1)
                R[i + 1] = result;   // O(1)
                result = 0;   // O(1)
            }
            if (carry_flag) R[0] = 1;   // O(1)
            return R;   // O(1)
        }

        // arr1 -arr2 only???
        public static int[] SUB(int[] arr1, int[] arr2,int size)   //O(N)
        {
            int[] R;   //O(1)
            int result = 0;  //O(1)
            int carry_Amout = 0;    //O(1)
            R = new int[size];    //O(1)
            for (int i = size - 1; i >= 0; i--)  //O(N * {O(1)})
            {
                    result = arr1[i] - arr2[i] -carry_Amout;  //O(1)
                if (result < 0) { result += 10; carry_Amout = 1; }   //O(1)
                else carry_Amout = 0;   //O(1)
                // r = r % 10;
                R[i] = result;   //O(1)
                result = 0;   //O(1)
            }
            return R;   //O(1)
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

        public static int [] MUL(int [] arr1,int [] arr2,int size)
        {
            int[] R, A, B, C, X1, X2, Y1, Y2, Sum_X, Sum_Y, Z, M, Dif, New_A, New_B, R1, R2;
            R = new int[2 * size]; A = new int[ size]; C = new int[ size];
            X1 = new int[size / 2]; X2 = new int[size / 2]; Y1 = new int[size / 2]; Y2 = new int[size / 2]; M = new int[size / 2]; Dif = new int[size / 2];
            Sum_X = new int[size]; Sum_Y = new int[size];
            if (size == 1) 
            {
                R = new int[size];
                int result= arr1[0] * arr2[0];
                if (result > 9)
                {
                    R = new int[size + 1];
                    R[1] = result % 10;
                    R[0] = result / 10;
                }
                else {
                    R = new int[size];
                    R[0] = result;

                }
                return R;
            
            }
            
            for(int i=0;i<size;i++)
            {
                if(i<size/2)
                {
                    X1[i]=arr1[i];
                    Y1[i] = arr2[i];
                }
                else
                {
                    X2[i-1]=arr2[i];
                    Y2[i-1] = arr2[i];
                }
            }
            
            A = MUL(X1,Y1,size/2);
            C = MUL(X2, Y2, size / 2);
            Sum_X = ADD(X1, X2,size/2);
            Sum_Y = ADD(Y1, Y2, size / 2);
            Z = MUL(Sum_X, Sum_Y, size);
            M = ADD(A, C, size / 2);
           B = SUB(Z, M, size / 2);
           New_A = Append_Zeros(ref A, A.Length + size);
           New_B = Append_Zeros(ref B, B.Length + (size/2));
           R1 = ADD(New_A, New_B, size);
           R = ADD(R1, C,size);
            return R;
        }

        public static int[] Append_Zeros(ref int [] arr,int size)
    {
            int []R=new int [size];
            for (int i = 0; i < arr.Length; i++)
            {
                R[i] = arr[i];
            }
            return R;
    }

}
}
