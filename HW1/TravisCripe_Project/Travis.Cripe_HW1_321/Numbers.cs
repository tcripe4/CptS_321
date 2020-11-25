//-----------------------------------------------------------------------
// <copyright file="Numbers.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace User_Input
{
    using System;

    /// <summary>
    /// This class is all for the numbers that the user enters
    /// </summary>
    public class Numbers
    {
        /// <summary>
        /// The current number of nodes
        /// </summary>
        private int index = 0;

        /// <summary>
        /// The input of the user string
        /// </summary>
        private string userNumbers;

        /// <summary>
        /// The user String but sparse
        /// </summary>
        private string[] sparseNumbers;

        /// <summary>
        /// Initializes a new instance of the <see cref="Numbers"/> class.
        /// This is the constructor for the user numbers
        /// </summary>
        public Numbers()
        {
            this.userNumbers = " ";
        }

        /// <summary>
        /// Gets or sets the number index for what number is to be read
        /// </summary>
        public int GetSetIndex
        {
            get { return this.index; }
            set { this.index = value; }
        }

        /// <summary>
        /// Gets or sets the string of the numbers the user has inputted
        /// </summary>
        public string GetSetUserNumbers
        {
            get { return this.userNumbers; }
            set { this.userNumbers = value; }
        }

        /// <summary>
        /// Gets or sets the index of the array for the number
        /// </summary>
        public string[] GetSetSparsedNumbers
        {
            get { return this.sparseNumbers; }
            set { this.sparseNumbers = value; }
        }

        /// <summary>
        /// Sets the new string from the user to the private string variable
        /// </summary>
        /// <param name="newMessage"> a String newMessage </param>
        public void NumbersSet(ref string newMessage) // Constructor
        {
            this.userNumbers = newMessage;
        }

        /// <summary>Increments the index.</summary>
        public void Increment_Index()
        {
            this.GetSetIndex += 1;
        }

        /// <summary>Reads the index.</summary>
        /// <returns>The index of the current sparse string</returns>
        public string Read_Index()
        {
            return this.sparseNumbers[this.GetSetIndex];
        }
    }
}