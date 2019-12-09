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
            File f1 = new File();


            //string s1 = "1242468682113840180763850624340867898830637122775434796573473991466933960634085363735808574823872230131509619596260435331836866582052453403290874467870290043697815376935298110895904163169442926407335197820883439691250684070655002714487685888";
            //string s2 = "417545487977981564551173186152102228498479694796653351848954185997611243506278579601980980219484255929864359810447039931";
            string s1 = "999", s2 = "899";

            int size=BigInteger.makeEqualLength(ref s1,ref s2);
            Console.WriteLine(s1 +"\n"+s2);
            
            int[] arr1 = BigInteger.convert_CharArr_IntArr(s1.ToCharArray());
            int[] arr2 = BigInteger.convert_CharArr_IntArr(s2.ToCharArray());
            //BigInteger.Display(arr1);
            //BigInteger.Display(arr2);

            big1.pub_arr = BigInteger.ADD(arr1,arr2,size);
            // BigInteger big2 = new BigInteger();

            //   big1.pub_arr = BigInteger.convert(big1.text.ToCharArray());
            //   big2.pub_arr = BigInteger.convert(big2.text.ToCharArray());

             big1.Display();
            //  big2.Display();

            //  BigInteger.Display(BigInteger.Add(big1.pub_arr, big2.pub_arr));

            string[] lines = File.readFromFile(File.file);

            // Display the file contents by using a foreach loop.
            Console.WriteLine("Contents of WriteLines2.txt = ");
            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                Console.WriteLine("\t" + line);
            }

            File.writeToFile(File.file1,lines);
        }
    }
}
