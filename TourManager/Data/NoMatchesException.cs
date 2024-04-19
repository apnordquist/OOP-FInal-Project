using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourManager.Data
{
    internal class NoMatchesException : Exception
    {
        public NoMatchesException() : base() { } //no argument
        public NoMatchesException(string message) : base(message) { } //message from class
        public NoMatchesException(string message, Exception inner) : base(message, inner) { } // message and innerException
    }
}
