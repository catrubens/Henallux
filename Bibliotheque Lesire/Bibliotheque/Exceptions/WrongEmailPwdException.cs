using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheque.Exceptions
{
    class WrongEmailPwdException : Exception
    {
        public string ErrorMessage { get; set; }

        public WrongEmailPwdException(string errorMessage)
        {
            this.ErrorMessage = errorMessage;
        }
    }
}
