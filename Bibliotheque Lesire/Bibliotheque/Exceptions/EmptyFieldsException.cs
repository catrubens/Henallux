using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheque.Exceptions
{
    class EmptyFieldsException : Exception
    {
        public string ErrorMessage { get; set; }

        public EmptyFieldsException(string errorMessage)
        {
            this.ErrorMessage = errorMessage;
        }
    }
}
