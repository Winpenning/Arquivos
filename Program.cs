using System;
using System.IO;
using Arquivos.Entities;

namespace Arquivos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the full path: ");
            string fullpath = Console.ReadLine();

            try
            {
                string[] line = File.ReadAllLines(fullpath);

                string sourcefolder = Path.GetDirectoryName(fullpath);
                string targetfolder = sourcefolder + @"\out";
                string targetfile = targetfolder + @"\cart.csv";

                Directory.CreateDirectory(targetfolder);

                using(StreamWriter sw = File.AppendText(targetfile))
                {
                    foreach(string lines in line)
                    {
                        string[] fields = lines.Split(',');
                        string name = fields[0];
                        double price = double.Parse(fields[1]);
                        int quantity = int.Parse(fields[2]);

                        Product p = new Product(name, price, quantity);

                        sw.WriteLine(p.Name+","+p.Total());
                        
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}