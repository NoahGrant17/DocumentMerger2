using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DocumentMerger2
{
    class Program
    {
        static void Main(string[] args)
        {
            string content1 ="";
            if (args.Length < 3)
            {
                Console.WriteLine("DocumentMerger2 <input_file_1> <input_file_2> ... <input_file_n> <output_file > ");
                Console.WriteLine("Supply a list of text files to merge followed by the name of the resulting merged text file as command line arguments.");
            }

            else
            {
                for (int i = 0; i < args.Length - 1; i++)
                {

                    string fileName1 = args[i];
                    try
                    {
                        if (File.Exists(fileName1 + ".txt") == false)
                        {
                            Console.WriteLine("exiting");
                            break;
                        }

                        StreamReader sr = new StreamReader($"{fileName1}.txt");

                        string line = sr.ReadLine();
                        content1 = content1 + line;
                        while (line != null)
                        {
                            content1 = content1 + Environment.NewLine;
                            line = sr.ReadLine();
                            content1 = content1 + line;
                        }
                        sr.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("File error!");
                    }
                }

                try
                {
                    using (StreamWriter write = new StreamWriter(args[args.Length - 1] + ".txt"))
                    {
                        write.Write(content1);
                    }
                    Console.WriteLine($"{(args[args.Length - 1])} is saved");
                }

                catch (Exception ex)
                {
                    using (StreamWriter write = new StreamWriter("exception.txt"))
                    {
                        write.Write(content1);
                    }
                    Console.WriteLine("Your file name does not work! The file is now called excepion.txt");
                }
            }
            Console.ReadLine();
        }
    }  
}
