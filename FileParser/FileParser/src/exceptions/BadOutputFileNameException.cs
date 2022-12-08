using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser.src.exceptions
{
    public class BadOutputFileNameException : Exception
    {
        public BadOutputFileNameException(string errorMessage) : base(errorMessage) { }
    }
}
