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

            BigInteger big1 = new BigInteger();
           // BigInteger big2 = new BigInteger();

            big1.text= Console.ReadLine();
           // big2.text = Console.ReadLine();

            big1.pub_arr = BigInteger.convert(big1.text.ToCharArray());
         //   big2.pub_arr = BigInteger.convert(big2.text.ToCharArray());

            big1.Display();
          //  big2.Display();

          //  BigInteger.Display(BigInteger.Add(big1.pub_arr, big2.pub_arr));
        }
    }
}
