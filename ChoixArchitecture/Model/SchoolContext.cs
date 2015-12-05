using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SchoolContext : DbContext
    {

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        static SchoolContext()
        {
            Database.SetInitializer(new ModelInitializer());
        }

        public SchoolContext()
            : base(@"Data Source=vm-sql.iesn.be\Stu3IG;Initial Catalog=ChoixArchitecturexxxxxxxxxxxxx;User ID=xxxxxxxxxxxxxx;Password=xxxxxxxxxxxxxxxx;")
        {

        }
    }
}
