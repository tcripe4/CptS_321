//
//  HW 11
//  Travis Cripe
//  Its actually kind of funny because I thought it said expression tree originally which made me super confused for a while
//  11519554
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11_TravisCripe_11519554
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree();

            List<int> rands = new List<int>();

            Random random = new Random();

            int between = random.Next(20, 30);

            for (int i = 0; i < between; i++)
            {
                rands.Add(random.Next(100));
            }

            for (int x = 0; x < rands.Count; x++)
            {
                tree.constructTree(rands[x]);
            }

            Console.WriteLine("No Stack No Recursion");
            tree.InOrderNoRecNoStack(tree.root);
            Console.WriteLine(" ");
            Console.WriteLine("Traversal with no Recursion and a Stack");
            tree.InOrderNoRec(tree.root);
            Console.WriteLine(" ");
            Console.WriteLine("Normal InOrder");
            tree.Inorder(tree.root);
            Console.WriteLine(" ");
        }

    }
}
