using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewHelper.Data.Exceptions;

public class InvalidBeerXMLException : Exception
{
    public override string Message => "No valid beerXML found!";
}
