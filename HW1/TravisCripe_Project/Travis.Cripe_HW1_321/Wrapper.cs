// <copyright file="Wrapper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using BinarySearchTree;
using User_Input;

/// <summary>
/// This class is the wrapper class which bring it all together
/// </summary>
public class Wrapper
{
    /// <summary>
    /// Runs the program
    /// </summary>
    private static void Main()
    {
        Numbers input = new Numbers();
        Console.WriteLine("Please input a string of numbers!");
        input.GetSetUserNumbers = Console.ReadLine(); // Gets the numbers
        input.GetSetSparsedNumbers = input.GetSetUserNumbers.Split(null); // Splits the numbers based on null space
        BST tree = new BST();
        int index = input.GetSetSparsedNumbers.Length;  // gets length of the sparsed numbers
        for (int i = 1; i <= index; i++)
        {
            int stoi = Convert.ToInt32(input.Read_Index());
            if (stoi >= 0 && stoi <= 100)
            {
                if (tree.GetSetHeadNode == null)
                {
                    tree.GetSetHeadNode = tree.Insert(tree.GetSetHeadNode, stoi);
                    input.Increment_Index();
                }
                else if (tree.CheckDuplicates(tree.GetSetHeadNode, stoi) == 0)
                {
                    tree.GetSetHeadNode = tree.Insert(tree.GetSetHeadNode, stoi);
                    tree.NodeCount();
                    input.Increment_Index();
                }
                else if (tree.CheckDuplicates(tree.GetSetHeadNode, stoi) == 1)
                {
                    Console.WriteLine("Sorry! " + stoi + " Is a duplicate number!");
                }
            }
            else
            {
                Console.WriteLine("Sorry! The number " + stoi + " is not within 0-100!");
            }
        }

        int levels = Convert.ToInt32(Math.Log(tree.GetSetNumberNodes)) + 1; // Formula for finding theoretical levell
        Console.WriteLine("The In Order traversal of the BST is: ");
        tree.PrintInOrder(tree.GetSetHeadNode);
        Console.WriteLine("The theoretical minumum number of levels in the BST is: " + levels);
    }
}