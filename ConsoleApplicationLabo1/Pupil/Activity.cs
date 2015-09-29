using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo1
{
   public class Activity
    {
        //profull
        private string title;
        public String Title
        {
            get { return title; }
            set { title = value; }
        }

        private bool isCompulsory;

        public bool IsCompulsory
        {
            get { return isCompulsory; }
            set { isCompulsory = value; } 
        }

        public Activity(String title, bool isCompulsory )
        {
            if (String.IsNullOrEmpty(title))
                throw new ArgumentNullException("title");
            Title = title;
            IsCompulsory = isCompulsory;
        }

        public override string ToString()
        {
           /* if (IsCompulsory)
                return Title + "(obligatoire)";
            else
                return Title;*/

            return (IsCompulsory) ? Title + " (obligatoire)" : Title; 
        }
    }
}
