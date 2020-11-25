// <copyright file="Program.cs" company="Travis Cripe 11519554">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace WindowsFormsApp2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Text_File;

    /// <summary>
    /// This class just contains the main which runs the form
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
    }
}
