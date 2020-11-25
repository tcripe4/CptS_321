// <copyright file="Form1.cs" company="Travis Cripe 11519554">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WindowsFormsApp2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Text_File;

    /// <summary>
    /// This is the class for the form
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// This is the function that runs the algorithms and outputs the text to the textbox
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
            List<int> intList = new List<int>();
            Random rand = new Random();
            for (int i = 1; i <= 10000; i++)
            {
                intList.Add(rand.Next(0, 20000));
            }

            Algorithms check = new Algorithms();
            this.textBox1.Text += "1: Hashset has : " + check.Check_Hash(intList) + " Unique numbers" + Environment.NewLine +
                "My Hashset complexity is O(N). It only has one for loop and runs through every number once so it has n complexity" + Environment.NewLine +
                "2: The O(1) has " + check.O1(intList) + " unique numbers" + Environment.NewLine +
                "My O(1) space complexity algorithm has a O(N^2) complexity because it has 2 for loops. It checks a number with the first for loop" +
                " and then with the second for loop it then checks through the array to see if any other number matches it" + Environment.NewLine +
                "3: Sort has : " + check.Sort(intList) + " unique numbers" + Environment.NewLine +
                "My sorting algorithm has a O(N^2) complexity because it sorts the numbers which is O(N) itself and then it runs through the list with one for loop which is another O(N) so it is O(N^2)";
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
