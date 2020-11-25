// <copyright file="Form1.cs" company="PlaceholderCompany">
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
    /// This is the class for the form
    /// </summary>
    public partial class Form1 : Form
    {
        private OpenFileDialog ofd = new OpenFileDialog();
        private SaveFileDialog sfd = new SaveFileDialog();

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// This initilazies the form component
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
        }

        private void LoadFile(object sender, System.EventArgs e)
        {
        }

        /// <summary>
        /// This opens the file dialog and makes sure that it matches
        /// </summary>
        /// <param name="sender">the object</param>
        /// <param name="e">event arg</param>
        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            var fdlg = new OpenFileDialog();
            if (fdlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }
        }

        /// <summary>
        /// This reads the text from the text file and outputs it to the text box.
        /// </summary>
        /// <param name="sr">the stream reader for the text reader</param>
        public void LoadText(TextReader sr)
        {
            if (sr != null)
            {
                this.textBox1.Text = sr.ReadToEnd();
            }
            else if (sr == null)
            {
                this.textBox1.Text += "The file was empty!";
            }
        }

        /// <summary>
        /// Loads the strip menu
        /// </summary>
        /// <param name="sender">The object sender</param>
        /// <param name="e">parameter for the eventargs</param>
        private void LoadFormFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Loads the strip menu
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event args</param>
        private void LoadFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ofd.Filter = ".txt|*.txt*";
            if (this.ofd.ShowDialog() == DialogResult.OK)
            {
            }

            this.LoadText(File.OpenText(this.ofd.FileName));
        }

        /// <summary>
        /// Saving to the file button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">eventags e</param>
        private void SaveToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.sfd.Filter = "txt files (*.txt)|*.txt";
            if (this.sfd.ShowDialog() == DialogResult.OK)
            {
                string filename = this.sfd.FileName;
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(filename))
                {
                    foreach (char line in this.textBox1.Text)
                    {
                        file.Write(line);
                    }
                }
            }
        }

        /// <summary>
        /// Calls the generator
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event args</param>
        private void LoadFibonacciNumbersfirst50ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FibonacciTextReader generator = new FibonacciTextReader(50);
            this.LoadText(generator);
        }

        /// <summary>
        /// The generator for the fibonacci numbers
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">eventarga e</param>
        private void LoadFibonacciNumbersfirst100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FibonacciTextReader generator = new FibonacciTextReader(100);
            this.LoadText(generator);
        }
    }
}
