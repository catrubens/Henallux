using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheque.Exceptions
{
    class ErrorData : Exception
    {
        public string ErrorMessage { get; set; }

        public ErrorData(string errorMessage)
        {
            this.ErrorMessage = errorMessage;
        }
    }
}
