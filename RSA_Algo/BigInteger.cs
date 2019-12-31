using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Ahmed Morgan
//Islame Nasser
//Amir Tateq
//Ahmed Saeed
//Zead Mmdoah
namespace RSA_Algo
{
    #region pair
    public class Pair<T, U>
    {
        public Pair()
        {
        }

        public Pair(T first, U second)
        {
            this.First = first;
            this.Second = second;
        }

        public T First { get; set; }
        public U Second { get; set; }
    };
    #endregion

    class BigInteger
    {
           // to convert to its ascci code
        //char ch = '5';
        //int i = (int)ch ;

            // to convert char number  to int number
        // int s = (int)s1[0] - '0';

        //:public
        public string text;   //O(1)
        public int[] pub_arr;  //O(1)
            //:private
            public static int[] ADD(int[] arr1, int[] arr2)   //O(N)
            {
            Make_Equle(ref arr1, ref arr2);   //O(N)
                int[] R, R_NoCarry;        // O(1)
                int size = arr1.Length;   //O(1)
            int result = 0;    // O(1)
                bool carry_flag = false;  // O(1)

                R = new int[size + 1];  // O(1)
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
                else
                {
                    R_NoCarry = new int[size];  //O(1)
                for (int i = size - 1; i >= 0; i--)  //O(N)
                {
                        R_NoCarry[i] = R[i + 1];  //O(1)
                }
                    return R_NoCarry;  //O(1)
            }
                return R;   // O(1)
            }

            // arr1 -arr2 only???
            public static int[] SUB(int[] arr1, int[] arr2)   //O(N)
            {
            Make_Equle(ref arr1, ref arr2);    //O(N)
                int[] R;   //O(1)
                int size = arr1.Length;   //O(1)
            int result = 0;  //O(1)
                int carry_Amout = 0;    //O(1)
                R = new int[size];    //O(1)
                for (int i = size - 1; i >= 0; i--)  //O(N * {O(1)})
                {
                    result = arr1[i] - arr2[i] - carry_Amout;  //O(1)
                    if (result < 0) { result += 10; carry_Amout = 1; }   //O(1)
                    else carry_Amout = 0;   //O(1)
                                            // r = r % 10;
                    R[i] = result;   //O(1)
                    result = 0;   //O(1)
                }
                Remove_Zeros_FromLeft(ref R);   //O(1)
            return R;  //O(1)
            }

         public static int[] Multiply(int[] X, int[] Y)    //T(N)=3T(N/2)+O(N)    Master Method  case 1     F(n)=O(N)    g(x)=N^log3 base(2)
                                                          //Complexity  ==  O(N^1.59)
        {
            // 10^n[X1Y1]+[X2Y2]+([X1+X2][Y1+Y2])10^n/2
            int[] Failed = { 0 }; //O(1)
            int size_of_sub_prob, N; //O(1)
                                     // 10^n[A]+[C]+[B]10^n/2                              // Karatsuba Multiplication
            int[] A // [X1Y1]
                , C // [X2Y2]
                , B // Z-(A+C)
                , Z, Zx, Zy// [X1+X2][Y1+Y2]
                , AC
                , Result;  //O(1)
            int a, c, b, z, result_baseCase;    //O(1)
            int[] x1, x2      //O(1)
                , y1, y2;      //O(1)
            Make_Equle(ref X, ref Y);  // make Equle length         O(N)
            int x_size = Even_Length(ref X); // check if has even length of Divide equal      //O(N)
            int y_size = Even_Length(ref Y); // ~      //O(N)
            N = X.Length; // set N    O(1)

            if (x_size == y_size) size_of_sub_prob = x_size; //O(1)
            else { return Failed; }   //O(1)

            x1 = new int[size_of_sub_prob];    //O(1)
            x2 = new int[size_of_sub_prob];    //O(1)
            y1 = new int[size_of_sub_prob];   //O(N)
            y2 = new int[size_of_sub_prob];    //O(N)

            Divide_into2Array(ref x1, ref x2, ref X, size_of_sub_prob);   //O(N)
            Divide_into2Array(ref y1, ref y2, ref Y, size_of_sub_prob);    //O(N)
            if (N == 2)  //Base Case     //O()
            {
                a = x1[0] * y1[0];   //O(1)
                c = x2[0] * y2[0];   //O(1)
                z = (x1[0] + x2[0]) * (y1[0] + y2[0]);   //O(1)
                b = z - (a + c);   //O(1)

                result_baseCase = (a * Ten_power(2)) + c + (b * Ten_power(1));  //O(N)
                string Res = result_baseCase.ToString();  //O(1)
                return convert_CharArr_IntArr(Res.ToCharArray());   //O(N)*O(1) =O(N)

            }  // Divide And Conqure

            A = Multiply(x1, y1);    //O(N^1.5)
            C = Multiply(x2, y2);   //O(N^1.5)
            Zx = ADD(x1, x2);  //O(N)
            Zy = ADD(y1, y2);  //O(N)
            Z = Multiply(Zx, Zy);    //O(N^1.5)
                                     // B = SUB(Z, ADD(A, C));
            AC = ADD(A, C);   //O(N)
            B = SUB(Z, AC);  //O(N)

            //Zx = Multiply_Morgan(x1, y2);  // X1*Y2  + X2*Y1
            //Zy = Multiply_Morgan(x2, y1);
            //Make_Equle(ref Zx, ref Zy);
            //Z = ADD(Zx, Zy);

            // return ADD(ADD(Append_Zeros(ref A,A.Length+N),C),Append_Zeros(ref Z,Z.Length+N/2));  //  combine

            Append_Zeros(ref A, N);  // A 10^N          //O(N)
            Append_Zeros(ref B, N / 2); // B 10^N/2       //O(N)

            AC = ADD(A, C);       //O(N)
            Result = ADD(AC, B);       //O(N)
            Remove_Zeros_FromLeft(ref Result);   //O(N)
            return Result;  //O(1)
                            //return Failed;
        }
       
        //Tuble.item1=Divide   | Tuble.item2=Reminder
        public static Tuple<int[], int[]> div_mod(int[] arrA, int[] arrB)  //O(N^1.5)Optimized to //O(N)
        {
                                                                     //T(N)=T(N)+O(N) 
            int[] zero = { 0 }, one = { 1 }, mul_By2 = { 2 };  //O(1)
            int[] _result, _reminder,sumB,sumR;   //O(1)
            Tuple<int[], int[]> Q_R;  //O(1)

            if (Compare(ref arrA, ref arrB))  //O(N)
                return new Tuple<int[], int[]>(zero, arrA);  //O(1)
            
            sumB = ADD(arrB, arrB);  //O(N)
            Q_R = div_mod(arrA, sumB);   //Recursive
                                    // Q_R = div_mod(arrA, Multiply(arrB, mul_By2));  //O(N^1.5)  // Recursive
            
            _result = Q_R.Item1;  //O(1)
                                   //_result = Multiply(_result, mul_By2);   //O(N^1.5)

            sumR = ADD(_result, _result); //O(N)
            _result = sumR; //O(1)

            _reminder = Q_R.Item2;  //O(1)
            if (Compare(ref _reminder, ref arrB))    //O(N)
            {
                return new Tuple<int[], int[]>(_result, _reminder);  //O(1)
            }
            else
            {
                return new Tuple<int[], int[]>(ADD(_result, one), SUB(_reminder, arrB));   //O(N)
            }
        }
        public static void Display(int[] Num) //O(N)
            {
                foreach (int n in Num) //O(N)
                {
                    Console.Write(n);  //O(1)
            }
                Console.WriteLine();  //O(1)
        }
            public void Display()  //O(N)
            {
                foreach (int n in pub_arr)  //O(N)
                {
                    Console.Write(n);  //O(1)
            }
                Console.WriteLine(); //O(1)
            }

            
            public static void Make_Equle(ref int[] X, ref int[] Y)    //O(N)
            {
                if (X.Length != Y.Length)  //O(1)
                {
                    if (X.Length > Y.Length)  //O(1)
                    {
                        Add_Zero_onLeft(ref Y, X.Length - Y.Length);    //O(N)
                    }
                    else
                    {
                        Add_Zero_onLeft(ref X, Y.Length - X.Length);     //O(N)
                    }
                }
            }
            public static int Even_Length(ref int[] X)  //O(N)
            {
                int size;   //O(1)
                if (X.Length % 2 == 0)   { }   //O(1)
                else { Add_Zero_onLeft(ref X, 1); }   //O(N)
                size = X.Length / 2;   //O(1)
                return size;  //O(1)
            }
            public static void Divide_into2Array(ref int[] X1, ref int[] X2, ref int[] X, int size)   //O(N)
            {
                for (int i = 0; i < X.Length; i++)  //O(N)
                {
                    if (i < size)   //O(1)
                    {
                        X1[i] = X[i];  //O(1)
                    }
                    else
                    {
                        X2[i - size] = X[i];    //O(1)
                }
                }
            }
            public static void Append_Zeros(ref int[] arr, int size)   //10^n   //O(N)
            {
                int[] R = new int[arr.Length + size];   //O(1)
            for (int i = 0; i < arr.Length; i++)   //O(N)
            {
                    R[i] = arr[i];    //O(1)
            }
                //  return R;
                arr = R;   //O(1)
        }

            public static void Add_Zero_onLeft(ref int[] arr, int N_Zeros)   //O(N)
            {
                int[] R = new int[arr.Length + N_Zeros];  // arr.Length + 1  Default
                for (int i = 0; i < arr.Length; i++)   //O(N)
            {
                    R[i + N_Zeros] = arr[i];  // shift number of zeros    //O(1)
            }
                arr = R;  //O(1)
        }
            public static int makeEqualLength(ref string str1, ref string str2)
            {
                int len1 = str1.Length;   //O(1)
            int len2 = str2.Length;    //O(1)

            if (len1 < len2)    //O(1)
            {
                    for (int i = 0; i < len2 - len1; i++) //O(N)
                        str1 = '0' + str1;    //O(1)
                return len2;   //O(1)
            }
                else if (len1 > len2)   //O(1)
            {
                    for (int i = 0; i < len1 - len2; i++)   //O(N)
                        str2 = '0' + str2;   //O(1)
            }
                return len1; // If len1 >= len2     //O(1)
        }
           
            public static int Ten_power(int N)   //T(N)=T(N-1)+O(1)     // O(N)
            {
                if (N == 0) return 1;    //O(1)
            else
                    return 10 * Ten_power(N - 1);    //O(N)

        }
            public static void Remove_Zeros_FromLeft(ref int[] int_arr) //O(N)
            {
                int c = 0;   //O(1)
            for (int i = 0; i < int_arr.Length; i++)   //O(N)
            {
                    if (int_arr[i] == 0)    //O(1)
                {
                        c++;   //O(1)
                    continue;  //O(1)
                }
                    else
                    {
                        break;   //O(1)
                }
                }
            int[] v;   //O(1)
            if (int_arr.Length == c)      //O(1)
            {
                v = new int[1];    //O(1)
                int_arr = v;  //O(1)
                return ;   //O(1)
            }
             v= new int[int_arr.Length - c];    //O(1)
            int t = 0;       //O(1)
            for (int i = c; i < int_arr.Length; i++)     //O(N)
            {
                    v[t] = int_arr[i];    //O(1)
                t++;    //O(1)
            }
            int_arr = v;   //O(1)
                return;    //O(1)
        }
        public static bool Compare(ref int[] arr1, ref int[] arr2)//retun true when arr1<arr2   //O(N)
        {
            int size=arr1.Length;   //O(1)
            if (arr1.Length < arr2.Length) //O(1)
                return true;  //O(1)
            else if (arr2.Length < arr1.Length)  //O(1)
                return false;  //O(1)
            else
            {
                for (int i = 0; i < size; i++)   //O(N)
                {
                    if (arr1[i] == arr2[i])  //O(1)
                        continue;   //O(1)
                    else {
                        if (arr1[i] < arr2[i])  //O(1)
                            return true;   //O(1)
                        else
                            return false;   //O(1)
                    }
                }
            }
            return false;  //O(1)
        }

        //Convert_string_To_intArr
        public static int[] AsciiCode(string Message)  // N * O(1) = O(N)
        {
            //string s;
            int j = 0,ascii,mod1,mod2;    //O(1)
            char[] _m = Message.ToCharArray();   //O(N)
            int[] arr = new int[_m.Length * 3];   //O(1)

            for (int i = 0; i < arr.Length; i+=3)   //O(N)
            {
                //s= _m[j].ToString();
                ascii = (int)_m[j];   //O(1)
                //ascii = int.Parse(s);
                if (ascii < 100)    //O(1)
                {
                    mod1 = ascii % 10;      //O(1)
                    ascii = ascii / 10;    //O(1)
                    arr[i] = 0;    //O(1)
                    arr[i + 1] = ascii;    //O(1)
                    arr[i + 2] = mod1;     //O(1)
                }
                //O(1)
                else
                {
                    mod1 = ascii % 10;   //O(1)
                    ascii = ascii / 10;   //O(1)
                    mod2 =ascii% 10;     //O(1)
                    ascii = ascii / 10;    //O(1)
                    arr[i] = ascii;    //O(1)
                    arr[i + 1] = mod2;    //O(1)
                    arr[i + 2] = mod1;    //O(1)
                }
                j++;    //O(1)
            }
            return arr;   //O(1)
        }

        public static string convert_Ascii_To_String(int[] Arr) //O(N)
        {
            string Massage = "";  //O(1)
            char ch;  //O(1)
            int ch_ascii,rem;   //O(1)
            //int[] three = { 3 }, rem;
            rem = (Arr.Length % 3);   //O(1)
            if (rem != 0)   //O(1)
            {
                Add_Zero_onLeft(ref Arr,3-rem);  //O(N)
            }
                for (int i = 0; i < Arr.Length; i += 3)   //O(N)
                {
                    ch_ascii = (Arr[i] * 100) + (Arr[i + 1] * 10) + Arr[i + 2]; //O(1)
                ch = (char)ch_ascii;   //O(1)
                Massage += ch;   //O(1)
            }
            return Massage;  //O(1)
        }
        public static int[] convert_CharArr_IntArr(char[] ch_arr) //O(N)
        {
            int[] int_arr = new int[ch_arr.Length]; // O(1)
            for (int i = 0; i < int_arr.Length; i++) // O(N)
            {
                //int_arr[i] = Convert.ToInt32(ch_arr[i]);
                string s = ch_arr[i].ToString();    //O(1)
                int_arr[i] = Int32.Parse(s);    //O(1)

            }
            return int_arr;   //O(1)
        }
        #region Morgan_RSA(M_RSA)
        public static int[] RSA(int[] _base, int[] pow, int[] mod) //T(N)=T(N/2)+O(N^1.5)   //O(N^1.5)
                                                                   //Master Method Case 3    f(x)=O(N^1.5)  g(x)=N^(log 1 base 2) 
        {
            //int count = 0;    //O(1)
            //Console.Write(count++);   //O(1)
            //Console.Clear();  //O(1)
            Tuple<int[], int[]> tuple_pow, tuple_mod, tuple_res,tuple_mod_opt;    //O(1)
            int[] zero = { 0 }, one = { 1 }, two = { 2 };     //O(1)
            int[] Result, div_by2, remind;    //O(1)

            tuple_mod = div_mod(_base, mod);  // Double used    //O(N)

            if (pow.Length == 1 && pow[0] == 0)    //O(1)
            {
                return one;  //O(1)
            }
            else if (_base.Length == 1 && _base[0] == 0)   //O(1)
            {
                return zero;   //O(1)
            }
            else if (pow.Length == 1 && pow[0] == 1)   //O(1)
            {
                //  tuble = div_mod(_base, mod);
                return tuple_mod.Item2;    //O(1)
            }
            else
            {
                tuple_pow = div_mod(pow, two);  //O(N)
                div_by2 = tuple_pow.Item1;   //O(1)
                remind = tuple_pow.Item2;   //O(1)
                if (remind.Length == 1 && remind[0] == 0)   //O(1)
                {
                    Result = RSA(_base, div_by2, mod);
                    tuple_mod_opt = div_mod(Result, mod);
                    Result = Multiply(tuple_mod_opt.Item2,tuple_mod_opt.Item2);   //O(N^1.5)
                }
                else
                {
                    Result = RSA(_base, div_by2, mod);
                    tuple_mod_opt = div_mod(Result, mod);

                    Result = Multiply(tuple_mod_opt.Item2, tuple_mod_opt.Item2);  //O(N^1.5)
                    remind = tuple_mod.Item2;   //O(1)
                    Result = Multiply(Result, remind);   //O(N^1.5)
                }
            }
            tuple_res = div_mod(Result, mod); //O(N)
            return tuple_res.Item2;   //O(1)
        }
        #endregion
        public static Tuple<int, int> div_mod(int A, int B)  //O(N)
        {

            int q, r;   //O(1)

            Tuple<int, int> Q_R; //O(1)
            if (A < B)  //O(1)
                return new Tuple<int, int>(0, A); //O(1)

            Q_R = div_mod(A, B * 2);  //O(N)
            q = Q_R.Item1; //O(1)
            q = q * 2;  //O(1)
            r = Q_R.Item2;  //O(1)
            if (r < B)  //O(1)
                return new Tuple<int, int>(q, r);   //O(1)
            else
                return new Tuple<int, int>(q + 1, r - B);   //O(1)

        }
        public static int Modular_Division(int _base, int pow, int mod)   //O(logN)
        {        //T(N)=T(N/2)+O(1)     Master Method case 2  F(n)=O(1)  g(x)=N^(log 1 base 2)  =  O(1*log(N))
            int Result;  //O(1)
            if (pow == 0)    //O(1)
                return 1;     //O(1)
            else if (_base == 0)      //O(1)
            {
                return 0;     //O(1)
            }
            else if (pow == 1)     //O(1)
            {
                return _base % mod;   //O(1)
            }
            else
            {
                if (pow % 2 == 0)   //O(1)
                {
                    Result = Modular_Division(_base, pow / 2, mod);  //T(N/2)
                    Result = (Result * Result);    //O(1)
                }
                else
                {
                    Result = Modular_Division(_base, pow / 2, mod);   //T(N/2)
                    Result = (Result * Result * (_base % mod));      //O(1)
                }
            }
            return Result % mod;   //O(1)
        }
    }
}