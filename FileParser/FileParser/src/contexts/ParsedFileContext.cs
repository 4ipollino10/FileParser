using FileParser.src.fileWorkers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser.src.contexts
{
    public class ParsedFileContext
    {
        private readonly Dictionary<string, int> wordAmountDict;

        private int wordCounter = 0;

        public ParsedFileContext() 
        { 
            wordAmountDict = new Dictionary<string, int>();
        }

        public void AddWord(string word)
        {
            wordCounter++;

            if(wordAmountDict.ContainsKey(word))
            {
                wordAmountDict[word]++;
            }
            else
            {
                wordAmountDict.Add(word, 1);
            }
        }

        public List<KeyValuePair<string, int>> GetSortedWords()
        {
            List<KeyValuePair<string, int>> sortedWords = new List<KeyValuePair<string, int>>();

            foreach(var pair in wordAmountDict.OrderBy(pair => pair.Value))
            {
                sortedWords.Add(pair);
            }

            return sortedWords;
        }

        public string GetFrequency(int wordFrequency)
        {
            double frequency = (double)wordFrequency / (double)wordCounter;
            NumberFormatInfo nfi = new NumberFormatInfo
            {
                NumberDecimalSeparator = "."
            };
            return frequency.ToString(nfi);
        }
    }
}
