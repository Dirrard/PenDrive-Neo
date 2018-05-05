using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Teste;
namespace Test
{
    [TestClass]
    public class UnitTest2
    {
      
        [TestMethod]
        public void TestMethod1()
        {
            Pessoa p1 = new Pessoa();
            p1.datansc = new DateTime(1999,1,12); 

               Assert.IsTrue(p1.EhMaior());


        }
    }
}
