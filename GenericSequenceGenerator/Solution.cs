// GenericSequenceGenerator/Solution.cs
// Purpose: Provides generic and specialized sequence generators for various types (char, int, double, etc.)
// Each generator produces a sequence based on its own logic or a user-supplied delegate.

#region Interfaces

/// <summary>
/// Defines the contract for a sequence generator.
/// </summary>
public interface ISequenceGenerator<T>
{
    T Previous { get; }
    T Current { get; }
    T Next { get; }
}

#endregion

#region Abstract Base

/// <summary>
/// Abstract base class for sequence generators. Handles state and advancing logic.
/// </summary>
public abstract class SequenceGenerator<T> : ISequenceGenerator<T>
{
    private T _previous;
    private T _current;

    public T Previous => _previous;
    public T Current => _current;

    // Tracks how many elements have been generated (optional)
    public int Count { get; private set; }

    protected SequenceGenerator(T previous, T current)
    {
        _previous = previous;
        _current = current;
        Count = 2;
    }

    /// <summary>
    /// Advances the sequence and returns the next value.
    /// </summary>
    public T Next
    {
        get
        {
            T next = GetNext();
            _previous = _current;
            _current = next;
            Count++;
            return next;
        }
    }

    /// <summary>
    /// Subclasses define how to calculate the next value.
    /// </summary>
    protected abstract T GetNext();
}

#endregion

#region Concrete Generators

/// <summary>
/// Generates a sequence of uppercase letters where each next letter is the sum of the previous two (modulo 26).
/// Example: A, B, C, D, F, H, M, T, H, A, ...
/// </summary>
/// <example>
/// var gen = new CharSequenceGenerator('A', 'B');
/// gen.Next; // 'C'
/// </example>
public class CharSequenceGenerator : SequenceGenerator<char>
{
    public CharSequenceGenerator(char previous, char current) : base(previous, current) { }

    protected override char GetNext()
    {
        // Convert chars to 0-based index (A=0, B=1, ..., Z=25)
        int prevPos = Previous - 'A';
        int currPos = Current - 'A';
        int nextPos = (prevPos + currPos) % 26;
        return (char)('A' + nextPos);
    }
}

/// <summary>
/// Generates a sequence where each next integer is double the current value.
/// Example: 2, 4, 8, 16, ...
/// </summary>
public class IntegerSequenceGenerator : SequenceGenerator<int>
{
    public IntegerSequenceGenerator(int previous, int current) : base(previous, current) { }

    protected override int GetNext()
    {
        return Current * 2;
    }
}

/// <summary>
/// Generates a sequence using a user-supplied delegate to determine the next value.
/// </summary>
/// <typeparam name="T">Type of sequence element.</typeparam>
/// <example>
/// var gen = new DelegateSequenceGenerator<int>(1, 1, (a, b) => a + b); // Fibonacci
/// </example>
public class DelegateSequenceGenerator<T> : SequenceGenerator<T>
{
    private readonly Func<T, T, T> _nextFunc;

    public DelegateSequenceGenerator(T previous, T current, Func<T, T, T> nextFunc) : base(previous, current)
    {
        _nextFunc = nextFunc ?? throw new ArgumentNullException(nameof(nextFunc));
    }

    protected override T GetNext()
    {
        return _nextFunc(Previous, Current);
    }
}

/// <summary>
/// Generates a sequence of doubles where each next value is current + (previous / current).
/// </summary>
public class DoubleSequenceGenerator : SequenceGenerator<double>
{
    public DoubleSequenceGenerator(double previous, double current) : base(previous, current) { }

    protected override double GetNext()
    {
        return Current + (Previous / Current);
    }
}

/// <summary>
/// Generates a Fibonacci sequence (each next value is the sum of the previous two).
/// </summary>
public class FibonacciSequenceGenerator : SequenceGenerator<int>
{
    public FibonacciSequenceGenerator(int previous, int current) : base(previous, current) { }

    protected override int GetNext()
    {
        return Previous + Current;
    }
}

#endregion

#region Solution Methods

public static class Solution
{
    /// <summary>
    /// Generates a sequence of characters using the specified count, previous character, and current character.
    /// </summary>
    public static IList<char> HowToUseCharSequenceGenerator(int count, char previous, char current)
    {
        ISequenceGenerator<char> generator = new CharSequenceGenerator(previous, current);
        var sequence = new List<char> { generator.Previous, generator.Current };
        for (int i = 1; i <= count; i++)
        {
            sequence.Add(generator.Next);
        }
        return sequence;
    }

    /// <summary>
    /// Generates a sequence of integers using the specified count, previous integer, and current integer.
    /// </summary>
    public static IList<int> HowToUseIntegerSequenceGenerator(int count, int previous, int current)
    {
        ISequenceGenerator<int> generator = new IntegerSequenceGenerator(previous, current);
        var sequence = new List<int> { generator.Previous, generator.Current };
        for (int i = 1; i <= count; i++)
        {
            sequence.Add(generator.Next);
        }
        return sequence;
    }

    /// <summary>
    /// Generates a Fibonacci sequence using the specified count, previous integer, and current integer.
    /// </summary>
    public static IList<int> HowToUseFibonacciSequenceGenerator(int count, int previous, int current)
    {
        ISequenceGenerator<int> generator = new FibonacciSequenceGenerator(previous, current);
        var sequence = new List<int> { generator.Previous, generator.Current };
        for (int i = 1; i <= count; i++)
        {
            sequence.Add(generator.Next);
        }
        return sequence;
    }

    /// <summary>
    /// Generates a sequence of doubles using the specified count, previous double, and current double.
    /// </summary>
    public static IList<double> HowToUseDoubleSequenceGenerator(int count, double previous, double current)
    {
        ISequenceGenerator<double> generator = new DoubleSequenceGenerator(previous, current);
        var sequence = new List<double> { generator.Previous, generator.Current };
        for (int i = 1; i <= count; i++)
        {
            sequence.Add(generator.Next);
        }
        return sequence;
    }

    /// <summary>
    /// Generates a sequence of elements using the specified count, previous element, current element, and a delegate function.
    /// </summary>
    public static IList<T> HowToUseDelegateSequenceGenerator<T>(int count, T previous, T current, Func<T, T, T> nextFunc)
    {
        ISequenceGenerator<T> generator = new DelegateSequenceGenerator<T>(previous, current, nextFunc);
        var sequence = new List<T> { generator.Previous, generator.Current };
        for (int i = 1; i <= count; i++)
        {
            sequence.Add(generator.Next);
        }
        return sequence;
    }
}

#endregion
