using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using Concurent;
using System.Linq;
using System.Data.Entity.Infrastructure;

namespace TestUnitaire
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InsertionFonctionnelle()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<CompanyContext>());

            CompanyContext company = new CompanyContext(); ;
            Customer cust = new Customer();
            cust.AccountBalance=12.5;
            cust.AddressLine1 = "Rue d'Albert, 65";
            cust.AddressLine2 = "Namur 5058";
            cust.City = "Namur";
            cust.Country = "Belgique";
            cust.EMail = "test@test.be";
            cust.Id = 102030405060;
            cust.Name = "Leo";
            cust.PostCode = "5050";
            cust.Remark="No remark";
            company.Customers.Add(cust);
            company.SaveChanges();
            AssertCustomerExists();
        }

       
        public void AssertCustomerExists()
        {
            CompanyContext company = new CompanyContext();
            Assert.AreNotEqual(0, company.Customers.Count());
            Assert.IsTrue(company.Customers.Count()>0);
        }

        [TestMethod]
        [ExpectedException(typeof(DbUpdateConcurrencyException))]
        public void DetecteLesEditionsConcurrentes()
        {
            var contextDeJohn = new CompanyContext();
            var clientDeJohn = contextDeJohn.Customers.First();

            var contextDeSarah = new CompanyContext();
            var clientDeSarah = contextDeJohn.Customers.First();

            clientDeJohn.AccountBalance += 1000;
            contextDeJohn.SaveChanges();

            clientDeSarah.AccountBalance += 1000;
            contextDeSarah.SaveChanges();
           
        }
    }
}
