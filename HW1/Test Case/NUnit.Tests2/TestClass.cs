using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinarySearchTree;
using ClassNode;
namespace NUnit.Tests2
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestMethod()
        {
            BST tree = new BST();
            Assert.Null(tree.GetSetHeadNode);
            tree.GetSetHeadNode = tree.Insert(tree.GetSetHeadNode, 7);
            tree.NodeCount();
            tree.GetSetHeadNode = tree.Insert(tree.GetSetHeadNode, 9);
            tree.NodeCount();
            tree.GetSetHeadNode = tree.Insert(tree.GetSetHeadNode, 4);
            tree.NodeCount();
            Assert.NotNull(tree.GetSetHeadNode);
            Assert.Greater(tree.GetSetHeadNode.GetSetnum, tree.GetSetHeadNode.GetSetLeftNode.GetSetnum);
            Assert.AreEqual(tree.GetSetNumberNodes, 3);
        }
    }
}
