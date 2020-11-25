using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_File
{
    class Algorithms
    {
        public int Check_Hash(List<int> myList) // Creates a HashSet to find all of the duplicates
        {
            int duplicates = 0;
            var hs = new HashSet<int>();
            for (int i = 0; i < myList.Count; ++i)
            {
                if (!hs.Add(myList[i]))
                {
                    duplicates += 1;
                }
            }
            return duplicates;
        }

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
            return duplicates = myList.Count - duplicates - 1;
        }

        public int sort(List<int> myList) // Sorts the list and then has one index infront to see if they indexes are a match
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
            return duplicate;
        }
    }
}
