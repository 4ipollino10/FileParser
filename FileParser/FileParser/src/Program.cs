using FileParser.src.contexts;
using FileParser.src.exceptions;
using FileParser.src.fileWorkers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser.src
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Usage: enter an input file name here.\n");

            string fileName;

            FileReader fileReader;

            ParsedFileContext parsedFileContext = new ParsedFileContext();

            while (true)
            {
                fileName = Console.ReadLine();
                try
                {
                    fileReader = new FileReader(fileName, parsedFileContext);
                    break;
                }
                catch (BadInputFileNameException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            fileReader.ReadFile();

            Console.WriteLine("Usage: enter an output file name here.\n");

            CSVMaker csvMaker;

            while (true)
            {
                fileName = Console.ReadLine();
                try
                {
                    csvMaker = new CSVMaker(fileName, parsedFileContext);
                    break;
                }
                catch (BadOutputFileNameException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            csvMaker.MakeCSV();
        }
    }
}
