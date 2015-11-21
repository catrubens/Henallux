using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concurent
{
    public class CompanyContext : DbContext
    {

        public DbSet<Customer> Customers
        {
            get;
            set;
        }
      
       // public CompanyContext(string ConnectionString)
        //    : base()
        public CompanyContext()
            : base(@"Data Source=vm-sql.iesn.be\Stu3IG;Initial Catalog=DBIG3A2;User ID=IG3A2;Password=***********")
        {

        }

       
    }   
}
