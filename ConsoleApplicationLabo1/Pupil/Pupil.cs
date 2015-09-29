using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo1
{
    public class Pupil : Person
    {

        private int grade;

        public int Grade
        {
            get { return grade; }
            set { grade = value; }
        }

        private List<Activity> lstActivities;

        public List<Activity> LstActivities
        {
            get { return lstActivities; }
            set { lstActivities = value; }    
        }


        private char[] tabEval;

        public char[] TabEval
        {
            get { return tabEval; }
            set { tabEval = value; } 
        }

//constructeur
        public Pupil(String name, int age, int grade) : base(name,age)
        {
            Grade = grade;
            LstActivities = new List<Activity>();
            TabEval = new char[10];
        }

        public Pupil(String name, int age ) : this(name,age,1)
        {  }
        
//Méthode
        public void addActivity( Activity activity)
        {
            if (LstActivities.Count < Parameter.maximum)
                LstActivities.Add(activity);
            else
                 throw new Exception("Le tableau est rempli");
           // System.Console.Write("\nLe tableau est rempli\n");

        }

        public override string ToString()
        {
            string ch = base.ToString() + ((LstActivities.Count() != 0) ? " a choisi les activités suivantes : ": " n'a pas encore choisi d'activité");
             int i;
             for (i = 0; i < LstActivities.Count(); i++)
                 ch += "\n" + LstActivities[i].ToString() + " " + TabEval[i];
           /* foreach (Activity activity in LstActivities)
            {
                ch += "\n" + activity.ToString() ;
            }*/

            return ch;
        }

        public void AddEvaluation(String titre = null, char evaluation = Parameter.s)
        {
            //LstActivities.IndexOf();

            int i = 0;
            if ( titre != null)
            {
                foreach (Activity activity in LstActivities)
                {
                    if (activity.Title.Equals(titre)) break;
                    i++;
                }
                LstActivities.Add(new Activity(titre, true));
                if (evaluation == 'R') //bon
                    TabEval[i] = Parameter.r;
                if (evaluation == 'S') //mauvais
                    TabEval[i] = Parameter.s;
                if (evaluation == 'T') //tres bon
                    TabEval[i] = Parameter.t;
            }
        }

        public char GetEvatuation(string titre)
        {
            int i = 0;
            if (titre != null)
            {
                foreach (Activity activity in LstActivities)
                {
                    if (activity.Title.Equals(titre)) 
                      return TabEval[i];
                    i++;
                }
            }
            throw new KeyNotFoundException("activité");
           
        }

    }
}
