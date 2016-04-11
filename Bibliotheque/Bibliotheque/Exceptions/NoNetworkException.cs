using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheque.Exceptions
{
    class NoNetworkException : Exception
    {
        public string ErrorMessage { get; set; }

        public NoNetworkException(string errorMessage)
        {
            this.ErrorMessage = errorMessage;
        }
    }
}
