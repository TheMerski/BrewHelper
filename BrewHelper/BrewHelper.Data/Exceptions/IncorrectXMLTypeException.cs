using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewHelper.Data.Exceptions;

public class IncorrectXMLTypeException : Exception
{
    public IncorrectXMLTypeException(string? message)
        : base(message)
    {
    }
}
