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


        private Dictionary<String, char> pupilActivities = new Dictionary<String, char>();

        public Dictionary<String,char> PupilActivites
        {
            get { return pupilActivities; }
            set { pupilActivities = value; }
        }


      /*  private List<Activity> lstActivities;

        public List<Activity> LstActivities
        {
            get { return lstActivities; }
            set { lstActivities = value; }    
        }
        */

        //private char[] tabEval;
        
        /*public char[] TabEval
        {
            get { return tabEval; }
            set { tabEval = value; } 
        }*/

       /* private char[] pupilsEvaluations;
        public char[] PupilsEvaluations
        {
            get { return pupilsEvaluations; }
            set { pupilsEvaluations = value; }
        }
        */
//constructeur
        public Pupil(String name, int age, int grade) : base(name,age)
        {
            Grade = grade;
         //   LstActivities = new List<Activity>();
            //TabEval = new char[10];
         //   PupilsEvaluations = new char[10];
        }

        public Pupil(String name, int age ) : this(name,age,1)
        {  }
        
//Méthode
        //liste
       /* public void addActivity( Activity activity)
        {
            if (LstActivities.Count < Parameter.maximum)
                LstActivities.Add(activity);
            else
                 throw new Exception("Le tableau est rempli");
           // System.Console.Write("\nLe tableau est rempli\n");

        }*/

        public void AddActivity(String activityTitle)
        {
            PupilActivites.Add(activityTitle, '0');
        }

        public override string ToString()
        {
            string ch = Header();
            // string ch = base.ToString() + ((LstActivities.Count() != 0) ? " a choisi les activités suivantes : " : " n'a pas encore choisi d'activité");
            ch = PrintActivities(ch); 
            /*int i;
             for (i = 0; i < LstActivities.Count(); i++)
                 ch += "\n" + LstActivities[i].ToString() + " " + PupilsEvaluations[i]; //]TabEval[i];*/
           /* foreach (Activity activity in LstActivities)
            {
                ch += "\n" + activity.ToString() ;
            }*/

            return ch;
        }
//liste
    /*    public string Header()
        {
            return base.ToString() + ((LstActivities.Count() != 0) ? " a choisi les activités suivantes : " : " n'a pas encore choisi d'activité"); 
        }*/

//dictionnaire
        public string Header()
        {
            return base.ToString() + ((PupilActivites.Count() != 0) ? " a choisi les activités suivantes : " : " n'a pas encore choisi d'activité");
        }
//liste
        /*public string PrintActivities(string ch)
        {
            int i;
            for (i = 0; i < LstActivities.Count(); i++)
                ch += "\n" + LstActivities[i].ToString() + " " + PupilsEvaluations[i];

            return ch;
        }*/

//dictionnaire
        public string PrintActivities(string ch)
        {
            int i;
            for (i = 0; i < PupilActivites.Count(); i++)
                ch += "\n" + PupilActivites.ElementAt(i).Key.ToString() + " " + PupilActivites.ElementAt(i).Value;

            return ch;
        }

//liste
       /* public void AddEvaluation(String titre = null, char evaluation = Parameter.s)
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
                    PupilsEvaluations[i] = Parameter.r;
                    //TabEval[i] = Parameter.r;
                if (evaluation == 'S') //mauvais
                    PupilsEvaluations[i] = Parameter.s;
                    //TabEval[i] = Parameter.r;
                if (evaluation == 'T') //tres bon
                    PupilsEvaluations[i]  = Parameter.t;
                 //TabEval[i] = Parameter.r;
            }
        }*/

//dictionnaire
        public void AddEvaluation(String titre = null, char evaluation = Parameter.s)
        {
            if (titre != null)
                PupilActivites[titre] = evaluation;
        }

//liste
       /* public char GetEvatuation(string titre)
        {
            int i = 0;
            if (titre != null)
            {
                foreach (Activity activity in LstActivities)
                {
                    if (activity.Title.Equals(titre))
                        return PupilsEvaluations[i] 
                        // return TabEval[i] ;
                    i++;
                }
            }
            throw new KeyNotFoundException("activité");
           
        }*/
//disctionnaire
        public char GetEvatuation(string titre)
        {
            int i = 0;
            if (titre != null)
            {
                foreach (KeyValuePair < string, char >  dict in PupilActivites)
                {
                    if (dict.Key.Equals(titre))
                        return dict.Value;
                }
            }
            throw new KeyNotFoundException("activité");
           
        }

    }
}
