using Labo1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Pupil eleve1 = new Pupil("Toto", 10);
            Pupil eleve2 = new Pupil("Paul", 15);
            Pupil eleve3 = new Pupil("Messi", 18);
            Activity activity1 = new Activity("vélo",false);
            Activity activity2 = new Activity("piscine", true);
            Activity activity3 = new Activity("marche", true);
            Activity activity4 = new Activity("Ping pong", false);
            Activity activity5 = new Activity("Tir", false);
            Activity activity6 = new Activity("Foot", true);
            Activity activity7 = new Activity("coloriage", true);
            Activity activity8 = new Activity("cuisine", false);
            Activity activity9 = new Activity("bricolage", false);
            Activity activity10 = new Activity("musique", true);
            Activity activity11 = new Activity("basket", true);

          
             eleve1.AddActivity(activity1.Title);
             eleve1.AddActivity(activity2.Title);
             eleve1.AddEvaluation(evaluation: 'T', titre: "vélo");

             eleve2.AddActivity(activity3.Title);
             eleve2.AddActivity(activity2.Title);

             eleve2.AddEvaluation("piscine", 'R');
             eleve2.AddEvaluation("marche", 'T');
             eleve2.AddEvaluation("vélo");

    //         System.Console.Write(eleve1);
             System.Console.Write("\n\n");
             System.Console.Write(eleve2);
             System.Console.ReadKey();
             System.Console.Write("\n\n");
             System.Console.Write(eleve2.GetEvatuation("vélo"));
             System.Console.ReadKey();
             System.Console.Write("\n\n");
             /* 
 //Variable anonyme
             System.Console.Write("Variable anonyme \n");
             List<Pupil> listePupil = new List<Pupil>()
             {
                 new Pupil("Laura",13,3),
                 new Pupil("Schumi",11,2),
                 new Pupil("Tomi",9),
                 new Pupil("Sacha",5),
                 new Pupil("Samy",4),
                 new Pupil("Fred",6,1),
                 new Pupil("Valérie",5),
                 new Pupil("Alonso",3),
             };

             var pupilGrade1Plus6 = from eleve in listePupil
                                    where eleve.Grade == 1 && eleve.Age > 6
                                    select eleve;

             if(pupilGrade1Plus6 != null)
                 foreach (var eleves in pupilGrade1Plus6)
                 {
                     System.Console.Write(eleves.ToString() + "\n");
                 }

             System.Console.ReadKey();
             System.Console.Write("\n\n");

// Classe statique
             System.Console.Write("Classe statique \n");
             eleve3.addActivity(activity1);
             eleve3.addActivity(activity2);
             eleve3.addActivity(activity3);
             eleve3.addActivity(activity4);
             eleve3.addActivity(activity5);
             eleve3.addActivity(activity6);
             eleve3.addActivity(activity7);
             //eleve3.addActivity(activity8);
             eleve3.addActivity(activity9);
             eleve3.addActivity(activity10);
             eleve3.addActivity(activity11);
             System.Console.Write(eleve3);
             System.Console.ReadKey();

//Lambda*/
            /*System.Console.Write("Lambda \n");
            List<Pupil> listePupil = new List<Pupil>()
            {
                new Pupil("Laura",13,3),
                new Pupil("Schumi",11,2),
                new Pupil("Tomi",9),
                new Pupil("Sacha",5),
                new Pupil("Samy",4),
                new Pupil("Fred",6,1),
                new Pupil("Valérie",5),
                new Pupil("Alonso",3),
            };

            var pupilGrade1Plus6 = listePupil.Where(pupil => (pupil.Age > 6 && pupil.Grade == 1));
            if (pupilGrade1Plus6 != null)
                foreach (var eleves in pupilGrade1Plus6)
                {
                    System.Console.Write(eleves.ToString() + "\n");
                }
            */

//Cavariance
            /*
            System.Console.Write("Cavariance \n");
            List<Pupil> listPupils = new List<Pupil>() { 
                new Pupil("Léo",18,4),
                new Pupil("Bernie",12,2),
                new Pupil("Celine",15,3),
                new Pupil("Homer",5),
            };

            List<Person> listPerson = new List<Person>() { 
                new Pupil("Bart",18),
                new Pupil("Lisa",12),
                new Pupil("Marge",15),
                new Pupil("Magie",12),
            };

            var listFusion = listPerson.Union(listPupils);
            foreach (var pers in listFusion)
            {
                System.Console.Write(pers.ToString() + "\n");
            }

            List<Pupil> listPupilsDuplicated = new List<Pupil>() { 
                new Pupil("Jules",18),
                new Pupil("Nico",15),
                new Pupil("Jules",18),                
                new Pupil("Nico",15),
            };
            System.Console.ReadKey();
            System.Console.Write("Doublon \n");
            IEnumerable<Pupil> listPupilsNoDuplicated = listPupilsDuplicated.Distinct<Pupil>(new PersonComparer());

            foreach (var pers in listPupilsNoDuplicated)
            {
                System.Console.Write(pers.ToString() + "\n");
            }
            */
            System.Console.ReadKey();


           
        }
    }
}
