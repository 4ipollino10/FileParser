using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileParser.src.contexts;
using FileParser.src.exceptions;
using Microsoft.SqlServer.Server;

namespace FileParser.src.fileWorkers
{
    public class FileReader 
    {
        private readonly StreamReader streamReader;

        private readonly StringParser stringParser;
        public FileReader(string fileName, ParsedFileContext parsedFileContext) 
        {
            try
            {
                streamReader = new StreamReader(fileName);
            }catch (IOException e)
            {
                throw new BadInputFileNameException("Bad file name... Try again:\n" + e.Message);
            }

            stringParser = new StringParser(parsedFileContext);
        }

        public void ReadFile() 
        {   
            
            string line;

            line = streamReader.ReadLine();

            while (line != null)
            {
                stringParser.ParseString(line + " ");
                line = streamReader.ReadLine();
            }

        }

    }
}
