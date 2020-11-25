// <copyright file="Node.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ClassNode
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// This class is the Node class, it has the right, left and the data of the Node
    /// </summary>
    public class Node
    {
        /// <summary>
        /// The right node
        /// </summary>
        private Node right;

        /// <summary>
        /// The left node
        /// </summary>
        private Node left;

        /// <summary>
        /// The data in each node
        /// </summary>
        private int num;

        /// <summary>
        /// Gets or sets the data of each node
        /// </summary>
        public int GetSetnum
        {
            get { return this.num; }
            set { this.num = value; }
        }

        /// <summary>
        /// Gets or sets the right or left node
        /// </summary>
        public Node GetSetRightNode
        {
            get { return this.right; }
            set { this.right = value; }
        }

        /// <summary>
        /// Gets or sets the right or left node
        /// </summary>
        public Node GetSetLeftNode
        {
            get { return this.left; }
            set { this.left = value; }
        }
    }
}