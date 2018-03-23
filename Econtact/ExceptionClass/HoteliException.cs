using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Econtact.ExceptionClass
{
    class HoteliException : Exception
    {
        public HoteliException(String message) : base(message)
        {

        }
    }
}
