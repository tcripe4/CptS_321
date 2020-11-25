// <copyright file="BST.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// change
namespace BinarySearchTree
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using ClassNode;

    /// <summary>
    /// Header test
    /// </summary>
    public class BST
    {
        /// <summary>
        /// The head node
        /// </summary>
        private Node head;

        /// <summary>
        /// The total number of nodes inserted
        /// </summary>
        private int numberNodes;

        /// <summary>
        /// Gets or sets the number of total nodes
        /// </summary>
        public int GetSetNumberNodes
        {
            get { return this.numberNodes; }
            set { this.numberNodes = value; }
        }

        /// <summary>
        /// Gets or sets the head node
        /// </summary>
        public Node GetSetHeadNode
        {
            get { return this.head; }
            set { this.head = value; }
        }

        /// <summary>Inserts the specified head.</summary>
        /// <param name="head">The head node of the BST</param>
        /// <param name="data">The int data that will be in the node</param>
        /// <returns>Returns the node that was inserted</returns>
        public Node Insert(Node head, int data) // Inserts the node into the BST
        {
            if (head == null)
            {
                head = new Node();
                head.GetSetnum = data;
            }
            else if (data < head.GetSetnum)
            {
                head.GetSetLeftNode = this.Insert(head.GetSetLeftNode, data);
            }
            else if (data > head.GetSetnum)
            {
                head.GetSetRightNode = this.Insert(head.GetSetRightNode, data);
            }

            return head;
        }

        /// <summary>Prints the BST in order.</summary>
        /// <param name="root">The root node</param>
        public void PrintInOrder(Node root) // Prints the BST In Order recursively
        {
            if (root == null)
            {
                return;
            }
            else if (root.GetSetLeftNode != null)
            {
                this.PrintInOrder(root.GetSetLeftNode);
            }

            Console.WriteLine(root.GetSetnum + " ");
            if (root.GetSetRightNode != null)
            {
                this.PrintInOrder(root.GetSetRightNode);
            }
        }

        /// <summary>Checks the duplicates.</summary>
        /// <param name="root">The root is a parameter.</param>
        /// <param name="data">The integer that is going to be in the node.</param>
        /// <returns>Returns whether the integer is a duplicate or not</returns>
        public int CheckDuplicates(Node root, int data)
        {
            if (root == null)
            {
                return 5;
            }
            else if (root.GetSetLeftNode != null)
            {
                if (root.GetSetnum == data)
                {
                    return 1;
                }

                this.CheckDuplicates(root.GetSetLeftNode, data);
            }

            if (root.GetSetRightNode != null)
            {
                if (root.GetSetnum == data)
                {
                    return 1;
                }

                this.CheckDuplicates(root.GetSetRightNode, data);
            }

            return 0;
        }

        /// <summary>
        /// Counts the nodes that are inserted
        /// </summary>
        public void NodeCount() // Keeps count of the nodes inserted
        {
            this.numberNodes += 1;
        }
    }
}