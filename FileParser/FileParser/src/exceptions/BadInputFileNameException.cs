using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser.src.exceptions
{
    public class BadInputFileNameException : Exception
    {
        public BadInputFileNameException(string errorMessage) : base(errorMessage) { }
        
    }
}
