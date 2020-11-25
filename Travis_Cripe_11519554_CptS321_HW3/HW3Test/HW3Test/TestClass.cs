using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW3_Project;

namespace HW3Test
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestMethod()
        {
            FibonacciTextReader generator = new FibonacciTextReader(50);
            for (int i = 0; i > 50; i++)
            {
                Assert.NotZero(generator.FibonacciGenerator(i));
                Assert.Greater(generator.FibonacciGenerator(i), 0);

            }
            // TODO: Add your test code here
            Assert.Pass("Your first passing test");
        }
    }
}
