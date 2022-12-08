using FileParser.src.contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser.src.fileWorkers
{
    internal class StringParser
    {
        private ParsedFileContext parsedFileContext;
        public StringParser(ParsedFileContext parsedFileContext) 
        {
            this.parsedFileContext = parsedFileContext;
        }

        public void ParseString(string line)
        {
            StringBuilder word = new StringBuilder();
            
            foreach(var symbol in line)
            {
                if (char.IsLetterOrDigit(symbol))
                {
                    word.Append(symbol);
                }
                else
                {
                    if(word.Length > 0)
                    {
                        parsedFileContext.AddWord(word.ToString());
                        word.Clear();
                    }                
                }
            }

        }
    }
}
