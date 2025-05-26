using System;
using System.Collections.Generic;
using static SequenceApp.ArrayManipulator;


namespace SequenceApp;


public class Program
{
    public static void Main()
    {
        //ExampleMoveXToCenter();

        ExampleSequenceGenerators();
    }

    private static void ExampleSequenceGenerators()
    {
        // Test CharSequenceGenerator
        var charSeq = Solution.HowToUseCharSequenceGenerator(5, 'A', 'B');
        Console.WriteLine("CharSequenceGenerator: " + string.Join(", ", charSeq));

        // Test IntegerSequenceGenerator
        var intSeq = Solution.HowToUseIntegerSequenceGenerator(5, 1, 2);
        Console.WriteLine("IntegerSequenceGenerator: " + string.Join(", ", intSeq));

        // Test FibonacciSequenceGenerator
        var fibSeq = Solution.HowToUseFibonacciSequenceGenerator(5, 0, 1);
        Console.WriteLine("FibonacciSequenceGenerator: " + string.Join(", ", fibSeq));

        // Test DoubleSequenceGenerator
        var doubleSeq = Solution.HowToUseDoubleSequenceGenerator(5, 1.0, 2.0);
        Console.WriteLine("DoubleSequenceGenerator: " + string.Join(", ", doubleSeq));

        // Test DelegateSequenceGenerator
        Func<int, int, int> customFunc = (prev, curr) => prev + curr + 1;
        var delegateSeq = Solution.HowToUseDelegateSequenceGenerator(5, 1, 2, customFunc);
        Console.WriteLine("DelegateSequenceGenerator: " + string.Join(", ", delegateSeq));
    }

    private static void ExampleMoveXToCenter()
    {
        int[] arr = { 1, 2, 3,6, 2, 4, 5, 6, 5 };
        int x = 6;
        Console.WriteLine($"Original: ");
        PrintArray(arr);
        int[] res = MoveXToCenter(arr, x);
        Console.WriteLine($"Modified: ");
        PrintArray(res);

        Console.WriteLine("\n---");

        int[] arr2 = { 1, 3,6,6, 3, 2, 4, 2 };
        int x2 = 6;
        Console.WriteLine($"Original: ");
        PrintArray(arr2);
        int[] res2 = MoveXToCenter(arr2, x2);
        Console.WriteLine($"Modified: ");
        PrintArray(res2);
    }
}
