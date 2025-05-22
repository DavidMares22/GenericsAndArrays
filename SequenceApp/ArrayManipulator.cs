using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceApp;
 

public static class ArrayManipulator
{
    public static int[] MoveXToCenter(int[] arr, int x)
    {
      

        var nonXElements = arr.Where(item => item != x).ToList();
        var xElements = arr.Where(item => item == x).ToList();

        int leftNonXCount = (arr.Length - xElements.Count) / 2;

        // Start with the left non-X elements
        var resultSequence = nonXElements.Take(leftNonXCount);

        // Concatenate all the X elements
        resultSequence = resultSequence.Concat(xElements);

        // Concatenate the remaining non-X elements (the right side)
        resultSequence = resultSequence.Concat(nonXElements.Skip(leftNonXCount));

        // Convert the final sequence to an array
        var result = resultSequence.ToArray();

        return result;

        //Array.Copy(result, arr, arr.Length);
    }

    // Optional: For testing
    public static void PrintArray(int[] arr)
    {
        Console.WriteLine("[" + string.Join(", ", arr) + "]");
    }

}
