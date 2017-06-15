using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TubitetClasses.Models;

namespace TubitetConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Faculty> faculties = new Faculty().getFaculties("");
            foreach(Faculty f in faculties)
            {
                Console.WriteLine(String.Format("Facult ID : {0} - Faculty Name : {1}", f.ID, f.FacultyName));
            }



            /*
            Console.WriteLine("Faculty Name:");
            string facultyName= Console.ReadLine();

            Faculty f = new Faculty() {
                FacultyName=facultyName
            };

            int control=f.Save();
            
            if (control > 0)
            {
                Console.WriteLine("Faculty saved with ID:" + control.ToString());
            }
            else
            {
                Console.WriteLine("Db Error");
            }

             */

            Console.ReadKey();
        }
    }
}
