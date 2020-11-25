// <copyright file="FibonacciTextReader.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace HW3_Project
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using HW3_Project;

    /// <summary>
    /// hbjjnkkl
    /// </summary>
    public class FibonacciTextReader : System.IO.TextReader
    {
        private int maxnum;

        /// <summary>
        /// Initializes a new instance of the <see cref="FibonacciTextReader"/> class.
        /// The constructor for the fibonacci
        /// </summary>
        /// <param name="max">the max nummber for the fibonacci numbers</param>
        public FibonacciTextReader(int max)
        {
            this.maxnum = max;
        }

        /// <summary>
        /// This generates the fibonacci numbers and then converts them to a string
        /// </summary>
        /// <param name="num">the num of the amount of fibonnaci sequences</param>
        /// <returns> the string of the number</returns>
        public string FibonacciGenerator(int num)
        {
            System.Numerics.BigInteger a = 0, b = 1, temp = 0;
            for (int i = 0; i < num; i++)
            {
                temp = a;
                a = b;
                b = temp + a;
            }

            return a.ToString();
        }

        /// <summary>
        /// This gets the fibonacci to be outputted to the textbox
        /// </summary>
        /// <returns>the string of the number</returns>
        public override string ReadToEnd()
        {
            StringBuilder fibonacci = new StringBuilder();
            for (int i = 1; i <= this.maxnum; i++)
            {
                fibonacci.Append(i + ": " + this.FibonacciGenerator(i) + Environment.NewLine);
            }

            return fibonacci.ToString();
        }
    }
}
