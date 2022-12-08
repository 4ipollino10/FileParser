using FileParser.src.contexts;
using FileParser.src.exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser.src.fileWorkers
{
    public class CSVMaker
    {
        private StreamWriter streamWritter;

        private ParsedFileContext parsedFileContext;

        public CSVMaker(string fileName, ParsedFileContext parsedFileContext) 
        {
            try
            {
                streamWritter = new StreamWriter(fileName);
            }
            catch (IOException)
            {
                throw new BadOutputFileNameException("Bad file name... Try again:\n");
            }
            this.parsedFileContext = parsedFileContext;
        }

        public void MakeCSV()
        {
            List<KeyValuePair<string, int>> wordStat = parsedFileContext.GetSortedWords();

            foreach(var pair in wordStat)
            {
                streamWritter.WriteLine(pair.Key + "," + pair.Value + "," + parsedFileContext.GetFrequency(pair.Value));
            }

            streamWritter.Close();
        }
    }
}
