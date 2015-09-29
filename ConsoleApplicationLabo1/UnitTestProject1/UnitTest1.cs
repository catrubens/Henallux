using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Labo1;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {//AAA
            //1. Arrange => on instancie
            Pupil p = new Pupil("Toto", 10);
            //2. Act =W on utilise le system
            p.AddEvaluation("env dev", 'd');
            //3. Assert => on compare résultat obtenu et attendu
            var evaluation = p.GetEvatuation("env dev");
            Assert.AreEqual('d', evaluation);
        }
     
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TestMethod2()
        {           
            Pupil p = new Pupil("Toto", 10);
            
            var evaluation = p.GetEvatuation("env dev");
            Assert.AreEqual('d', evaluation);
        }
    }
}
