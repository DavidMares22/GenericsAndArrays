using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceApp;
 

public static class ArrayManipulator
{
    public static int[] MoveXToCenter(int[] sourceArray, int targetValue)
    {
        var nonTargetValues = sourceArray.Where(item => item != targetValue).ToList();
        var targetValues = sourceArray.Where(item => item == targetValue).ToList();

        int leftNonTargetCount = (sourceArray.Length - targetValues.Count) / 2;

        // Take the first half of non-target values
        var reorderedSequence = nonTargetValues.Take(leftNonTargetCount);

        // Concatenate all the target values
        reorderedSequence = reorderedSequence.Concat(targetValues);

        // Concatenate the remaining non-target values (the right side)
        reorderedSequence = reorderedSequence.Concat(nonTargetValues.Skip(leftNonTargetCount));

        // Convert the final sequence to an array
        var resultArray = reorderedSequence.ToArray();

        return resultArray;
    }

    // Optional: For testing
    public static void PrintArray(int[] arr)
    {
        Console.WriteLine("[" + string.Join(", ", arr) + "]");
    }

}
