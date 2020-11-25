using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// This is the Node class
/// </summary>
namespace HW11_TravisCripe_11519554
{
    class Node
    {
        private int number;
        public Node left;
        public Node right;

        public Node()
        {
        }

        public Node getLeft()
        {
            return this.left;
        }

        public Node getRight()
        {
            return this.right;
        }

        public int GetSetNumber
        {
            get
            {
                return this.number;
            }
            set
            {
                this.number = value;
            }
        }

        public Node GetSetLeft
        {
            get
            {
                return this.left;
            }
            set
            {
                this.left = value;
            }
        }

        public Node GetSetRight
        {
            get
            {
                return this.right;
            }
            set
            {
                this.right = value;
            }
        }
    }

    /// <summary>
    /// The BST class with traversals
    /// </summary>
    class Tree
    {
        public Node root;

        public Node returnRoot()
        {
            return this.root;
        }

        /// <summary>
        /// Constructs the tree
        /// </summary>
        /// <param name="num">The num to be inserted into the tree</param>
        public void constructTree(int num)
        {
            Node t = new Node();
            t.GetSetNumber = num;

            if (root == null)
            {
                root = t;
            }
            else
            {
                Node cur = root;
                Node top;

                while (true)
                {
                    top = cur;
                    if (num < top.GetSetNumber)
                    {
                        cur = cur.GetSetLeft;
                        if (cur == null)
                        {
                            top.GetSetLeft = t;
                            return;
                        }
                    }
                    else
                    {
                        cur = cur.GetSetRight;
                        if (cur == null)
                        {
                            top.GetSetRight = t;
                            return;
                        }
                    }
                }

            }
        }

        /// <summary>
        /// The Inorder recursion way 
        /// </summary>
        /// <param name="Root">The root of the BST</param>
        public void Inorder(Node Root)
        {
            if (Root == null)
            {
                return;
            }
            Inorder(Root.left);
 
            Inorder(Root.right);
        }

        /// <summary>
        /// The InOrder with no recursion and using a stack
        /// </summary>
        /// <param name="Root"><The Root of the tree/param>
        public void InOrderNoRec(Node Root)
        {
            Stack<Node> NodeStack = new Stack<Node>();

            while (Root != null || NodeStack.Count > 0)
            {
                while (Root != null)
                {
                    NodeStack.Push(Root);
                    Root = Root.left;
                }

                Root = NodeStack.Pop();
                Root = Root.right;
            }
        }

        /// <summary>
        /// The InOrder with no recursion and no stack
        /// </summary>
        /// <param name="Root">The root of the tree</param>
        public void InOrderNoRecNoStack(Node Root)
        {
            // The node the helps sort the tree again after changing it
            Node replacement;
            while (Root != null)
            {
                if (Root.left == null)
                {
                    Root = Root.right;
                }
                else
                {
                    replacement = Root.left;

                    while (replacement.right != Root && replacement.right != null)
                    {
                        replacement = replacement.right;
                    }

                    if (replacement.right == null)
                    {
                        replacement.right = Root;
                        Root = Root.left;
                    }
                    else
                    {
                        replacement.right = null;
                        Root = Root.right;
                    }
                }
            }
        }
    }
}
