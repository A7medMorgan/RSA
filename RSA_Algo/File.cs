using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA_Algo
{
    class File
    {
        public static string file_add_input = "./../../../AddTestCases.txt";
        public static string file_sub_input = "./../../../SubtractTestCases.txt";
        public static string file_mul_input = "./../../../MultiplyTestCases.txt";
        public static string file_add_output = "Result/AddTestCases_Result.txt";
        public static string file_sub_output = "Result/SubtractTestCases_Result.txt";
        public static string file_mul_output = "Result/MultiplyTestCases_Result.txt";
        public static string file_simple_rsa = "./../../../SampleRSA_II/SampleRSA.txt";
        public static string file_complete_rsa = "./../../../Complete Test/TestRSA.txt";
        public static string file_simple_rsa_output = "./../../../SampleRSA_II/SampleRSA_output.txt";
        public static string file_complete_rsa_output = "./../../../Complete Test/TestRSA_output.txt";

        // These examples assume a "C:\Users\Public\TestFolder" folder on your machine.
        // You can modify the path if necessary.


        // Example #1: Write an array of strings to a file.
        // Create a string array that consists of three lines.
        //string[] lines = { "First line", "Second line", "Third line" };
        // WriteAllLines creates a file, writes a collection of strings to the file,
        // and then closes the file.  You do NOT need to call Flush() or Close().
        //System.IO.File.WriteAllLines(@"C:\Users\Public\TestFolder\WriteLines.txt", lines);


        // Example #2: Write one string to a text file.
        //string text = "A class is the most powerful data type in C#. Like a structure, " +
        //               "a class defines the data and behavior of the data type. ";
        //// WriteAllText creates a file, writes the specified string to the file,
        // and then closes the file.    You do NOT need to call Flush() or Close().
        //System.IO.File.WriteAllText(@"C:\Users\Public\TestFolder\WriteText.txt", text);

        // Example #3: Write only some strings in an array to a file.
        // The using statement automatically flushes AND CLOSES the stream and calls 
        // IDisposable.Dispose on the stream object.
        // NOTE: do not use FileStream for text files because it writes bytes, but StreamWriter
        // encodes the output as text.
        //using (System.IO.StreamWriter file =
        //    new System.IO.StreamWriter(@"C:\Users\Public\TestFolder\WriteLines2.txt"))
        //{
        //    foreach (string line in lines)
        //    {
        //        // If the line doesn't contain the word 'Second', write the line to the file.
        //        if (!line.Contains("Second"))
        //        {
        //            file.WriteLine(line);
        //        }
        //    }
        //}

        // Example #4: Append new text to an existing file.
        // The using statement automatically flushes AND CLOSES the stream and calls 
        // IDisposable.Dispose on the stream object.
        //string[] arr = new string[3];
        //arr[0] = "Amir";
        //arr[1] = "7att";
        //arr[2] = "Ahmed";
        //using (System.IO.StreamWriter file =
        //    new System.IO.StreamWriter(@"C:\Users\amir\OneDrive\المستندات\Visual Studio 2015\Projects\amir tareq  elsayed section (4)\ConsoleApplication5\bin\Debug\Data1.txt", true))
        //{
        //    for(int i=0;i<arr.Length;i++)
        //    {
        //        file.WriteLine(arr[i]);

        //    }

        //}
        public static string[] writeToFile(string filename, string[] line)
        {


            using (System.IO.StreamWriter file1 = new System.IO.StreamWriter(filename, true)) ;

            for (int i = 0; i < line.Length; i++)
            {
                System.IO.File.WriteAllLines(filename, line);

            }

            return line;
        }

        // Example #5: Read from an existing file.
        public static string[] readFromFile(string filename)
        {
            string[] lines = System.IO.File.ReadAllLines(filename);
            return lines;
        }
    }

}
