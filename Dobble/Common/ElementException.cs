using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class ElementException : Exception
    {
        public ElementException(string message): base(message)
        {}
    }
}
