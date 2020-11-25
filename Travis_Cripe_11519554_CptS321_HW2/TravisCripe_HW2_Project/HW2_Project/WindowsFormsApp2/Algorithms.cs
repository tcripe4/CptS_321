// <copyright file="Algorithms.cs" company="Travis Cripe 11519554">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Text_File
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// This is my class for the 3 of my algorithms
    /// </summary>
    public class Algorithms
    {
        /// <summary>
        /// This gets the hash codes of all the numbers and checks for them for duplicates
        /// </summary>
        /// <param name="myList">The list with all the integers</param>
        /// <returns>an integer</returns>
        public int Check_Hash(List<int> myList) // Creates a HashSet to find all of the duplicates
        {
            int duplicates = 0;
            var hs = new HashSet<int>(); // Creats hash table
            for (int i = 0; i < myList.Count; ++i)
            {
                if (!hs.Add(myList[i]))
                {
                    duplicates += 1;
                }
            }

            int unique = myList.Count - duplicates;
            return unique;
        }

        /// <summary>
        /// Checks for all of the non duplicate numbers then subtracts it from the total
        /// </summary>
        /// <param name="myList">List with all the integers</param>
        /// <returns>retuns the amount of dupliates</returns>
        public int O1(List<int> myList) // This algorithm is counting all of the numbers that do not have duplicates and then subtracts it from the amount of indexes in the array
        {
            int duplicates = 0;
            for (int i = 0; i < myList.Count; i++)
            {
                for (int j = i + 1; j < myList.Count; j++)
                {
                    if (myList[i] == myList[j])
                    {
                        break;
                    }
                    else if (j == myList.Count - 1)
                    {
                        duplicates += 1;
                    }
                }
            }

            return duplicates + 1;
        }

        /// <summary>
        /// Sorts all the items then checks for duplicates
        /// </summary>
        /// <param name="myList">Int list will all the integers</param>
        /// <returns>returns the amount of duplicates</returns>
        public int Sort(List<int> myList) // Sorts the list and then has one index infront to see if they indexes are a match
        {
            myList.Sort();
            int duplicate = 0;
            for (int i = 0; i < myList.Count - 1; i++)
            {
                if (myList[i] == myList[i + 1])
                {
                    duplicate += 1;
                }
            }

            return duplicate = myList.Count - duplicate;
        }
    }
}
