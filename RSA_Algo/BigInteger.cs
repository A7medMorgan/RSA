using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA_Algo
{
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

    class BigInteger
    {
        
            // int s = (int)s1[0] - '0';
            //:public
            public string text;
            public int[] pub_arr;
            //:private
            public static int[] ADD(int[] arr1, int[] arr2)   //O(N)
            {
                int[] R, R_NoCarry;        // O(1)
                int size = arr1.Length;
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
                    R_NoCarry = new int[size];
                    for (int i = size - 1; i >= 0; i--)
                    {
                        R_NoCarry[i] = R[i + 1];
                    }
                    return R_NoCarry;
                }
                return R;   // O(1)
            }

            // arr1 -arr2 only???
            public static int[] SUB(int[] arr1, int[] arr2)   //O(N)
            {
                int[] R;   //O(1)
                int size = arr1.Length;
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
                    , AC;                                   //O(1)
                int a, c, b, z, result;    //O(1)
                int[] x1, x2
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
                    a = x1[0] * y1[0];
                    c = x2[0] * y2[0];
                    z = (x1[0] + x2[0]) * (y1[0] + y2[0]);
                    b = z - (a + c);

                    result = (a * Ten_power(2)) + c + (b * Ten_power(1));  //O(N)
                    string Res = result.ToString();  //O(1)
                    return convert_CharArr_IntArr(Res.ToCharArray());   //O(N)*O(1) =O(N)

                }  // Divide And Conqure

                A = Multiply(x1, y1);
                C = Multiply(x2, y2);
                Make_Equle(ref x1, ref x2);   //O(N)
                Zx = ADD(x1, x2);  //O(N)
                Make_Equle(ref y1, ref y2);  //O(N)
                Zy = ADD(y1, y2);  //O(N)
                Z = Multiply(Zx, Zy);
                // B = SUB(Z, ADD(A, C));
                Make_Equle(ref A, ref C);  //O(N)
                AC = ADD(A, C);   //O(N)
                Make_Equle(ref Z, ref AC);  //O(N)
                B = SUB(Z, AC);  //O(N)

                //Zx = Multiply_Morgan(x1, y2);  // X1*Y2  + X2*Y1
                //Zy = Multiply_Morgan(x2, y1);
                //Make_Equle(ref Zx, ref Zy);
                //Z = ADD(Zx, Zy);

                // return ADD(ADD(Append_Zeros(ref A,A.Length+N),C),Append_Zeros(ref Z,Z.Length+N/2));  //  combine

                Append_Zeros(ref A, N);  // A 10^N          //O(N)
                Append_Zeros(ref B, N / 2); // B 10^N/2       //O(N)

                Make_Equle(ref A, ref C);        //O(N)
                AC = ADD(A, C);       //O(N)
                Make_Equle(ref AC, ref B);       //O(N)
                return ADD(AC, B);       //O(N)

                //return Failed;
            }
            public static void Make_Equle(ref int[] X, ref int[] Y)    //O(N)
            {
                if (X.Length != Y.Length)
                {
                    if (X.Length > Y.Length)
                    {
                        Add_Zero_onLeft(ref Y, X.Length - Y.Length);
                    }
                    else
                    {
                        Add_Zero_onLeft(ref X, Y.Length - X.Length);
                    }
                }
            }
            public static int Even_Length(ref int[] X)  //O(N)
            {
                int size;
                if (X.Length % 2 == 0) { }
                else { Add_Zero_onLeft(ref X, 1); }
                size = X.Length / 2;
                return size;
            }
            public static void Divide_into2Array(ref int[] X1, ref int[] X2, ref int[] X, int size)   //O(N)
            {
                for (int i = 0; i < X.Length; i++)
                {
                    if (i < size)
                    {
                        X1[i] = X[i];
                    }
                    else
                    {
                        X2[i - size] = X[i];
                    }
                }
            }
            public static void Append_Zeros(ref int[] arr, int size)   //10^n   //O(N)
            {
                int[] R = new int[arr.Length + size];
                for (int i = 0; i < arr.Length; i++)
                {
                    R[i] = arr[i];
                }
                //  return R;
                arr = R;
            }

            public static void Add_Zero_onLeft(ref int[] arr, int N_Zeros)   //O(N)
            {
                int[] R = new int[arr.Length + N_Zeros];  // arr.Length + 1  Default
                for (int i = 0; i < arr.Length; i++)
                {
                    R[i + N_Zeros] = arr[i];  // shift number of zeros
                }
                arr = R;
            }
            public static int makeEqualLength(ref string str1, ref string str2)
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
            public static int[] convert_CharArr_IntArr(char[] ch_arr) //O(N)
            {
                int[] int_arr = new int[ch_arr.Length]; // O(1)
                for (int i = 0; i < int_arr.Length; i++) // O(N)
                {
                    //int_arr[i] = Convert.ToInt32(ch_arr[i
                    string s = ch_arr[i].ToString();
                    int_arr[i] = Int32.Parse(s);

                }
                return int_arr;
            }
            public static int Ten_power(int N)   //T(N)=T(N-1)+O(1)     // O(N)
            {
                if (N == 0) return 1;
                else
                    return 10 * Ten_power(N - 1);

            }
            public static int[] convert(int[] int_arr) //O(N)
            {
                int c = 0;
                for (int i = 0; i < int_arr.Length; i++)
                {
                    if (int_arr[i] == 0)
                    {
                        c++;
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
            int[] v;
            if (int_arr.Length == c)
            {
                v = new int[1];
                return v;
            }
             v= new int[int_arr.Length - c];
                int t = 0;
                for (int i = c; i < int_arr.Length; i++)
                {
                    v[t] = int_arr[i];
                    t++;
                }
            
                return v;
            }

        //public static Tuple <int[] ,int[] > div(int [] arrA ,int [] arrB)
        //{
        //    int[] zero = { 0 }, one = { 1 };
        //    int[] q, r;
        //    int[] mul_By2 = { 2 }; 
        //    Tuple <int[], int[]> Q_R;
        //    if (arrA.Length < arrB.Length)
        //        return new Tuple<int[], int[]> (zero, arrA);
        //    arrB = Multiply(arrB, mul_By2);
        //    Q_R = div(arrA, arrB);
        //    q = Q_R.Item1;
        //    q= Multiply(arrB, mul_By2);
        //    r = Q_R.Item2;
        //    if (r.Length < arrB.Length)
        //        return new Tuple<int[], int[]>(q , r);
        //    else
        //        return new Tuple<int[], int[]>(ADD(q,one),SUB(r,arrB));

        //}

        public static Tuple<int, int> div(int arrA, int arrB)  //O(N)
        {
            
            int q, r;   //O(1)
            
            Tuple<int, int> Q_R; //O(N)
            if (arrA< arrB)  //O(1)
                return new Tuple<int, int>(0, arrA); //O(1)

            Q_R = div(arrA, arrB*2);  //O(N)
            q = Q_R.Item1; //O(1)
            q = q*2;  //O(1)
            r = Q_R.Item2;  //O(1)
            if (r< arrB)  //O(1)
                return new Tuple<int, int>(q, r);   //O(1)
            else
                return new Tuple<int, int>(q+1, r- arrB);   //O(1)

        }
    }
    }

        
    

