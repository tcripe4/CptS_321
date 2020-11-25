// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using System.Text;
using System;

namespace HW11_TravisCripe_11519554
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestMethod()
        {
            Tree NoRecNoStack = new Tree();
            Tree NoRec = new Tree();
            Tree Normal = new Tree();

            List<int> rands = new List<int>();

            Random random = new Random();

            int between = random.Next(20, 30);

            for (int i = 0; i < between; i++)
            {
                rands.Add(random.Next(100));
            }

            for (int x = 0; x < rands.Count; x++)
            {
                NoRecNoStack.constructTree(rands[x]);
                NoRec.constructTree(rands[x]);
                Normal.constructTree(rands[x]);
            }

            NoRecNoStack.InOrderNoRecNoStack(NoRecNoStack.root);
            NoRec.InOrderNoRec(NoRec.root);
            Normal.Inorder(Normal.root);
            Assert.AreEqual(NoRecNoStack.root.GetSetNumber, NoRec.root.GetSetNumber);
            Assert.AreEqual(NoRecNoStack.root.right.GetSetNumber, NoRec.root.right.GetSetNumber);
            Assert.AreEqual(NoRecNoStack.root.left.GetSetNumber, NoRec.root.left.GetSetNumber);
        }
    }
}
