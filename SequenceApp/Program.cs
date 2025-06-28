
namespace SequenceApp;


public class Program
{
    public static void Main()
    {

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

}
