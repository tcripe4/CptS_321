using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_File;
namespace HW2_Tests
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestMethod()
        {
            List<int> intList = new List<int>();
            Random rand = new Random();
            for (int i = 1; i <= 10000; i++)
            {
                intList.Add(rand.Next(0, 20000));
            }
            Algorithms check = new Algorithms();
            Assert.AreEqual(check.Check_Hash(intList), check.O1(intList));
            Assert.AreEqual(check.Check_Hash(intList), check.sort(intList));
        }
    }
}
