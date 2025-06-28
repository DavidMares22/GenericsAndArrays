# GenericSequenceGenerator

A .NET 8 class library for generating sequences of various types using object-oriented and generic programming principles.

## Overview

This library provides a flexible framework for generating sequences (such as Fibonacci numbers, custom integer/double/char sequences, and more) using a common interface and extensible base class. It supports both built-in and user-defined recurrence relations.

---

## Components

### 1. `ISequenceGenerator<T>`

A generic interface for sequence generators.

**Properties:**
- `T Previous`  
  The previous element in the sequence.
- `T Current`  
  The current element in the sequence.
- `T Next`  
  The next element in the sequence (advances the sequence).

---

### 2. `SequenceGenerator<T>`

An abstract base class implementing `ISequenceGenerator<T>`.  
Provides the core logic for managing sequence state and advancing the sequence.

**Key Features:**
- Constructor initializes the first two values of the sequence.
- Properties:
  - `Previous` (read-only): The previous value.
  - `Current` (read-only): The current value.
  - `Next` (read-only): Advances the sequence and returns the next value.
  - `Count` (public getter, private setter): Number of elements generated so far.
- Abstract method:
  - `T GetNext()`: Computes the next value in the sequence (to be implemented by derived classes).

---

### 3. `FibonacciSequenceGenerator`

Generates the Fibonacci sequence.

- Inherits from `SequenceGenerator<int>`.
- Constructor: Accepts two initial integer values.
- Implements `GetNext()` to return the sum of the previous two values.

---

### 4. `IntegerSequenceGenerator`

Generates a custom integer sequence defined by the recurrence:  
`x₁ = 1, x₂ = 2, xₙ₊₁ = 6 * xₙ - 8 * xₙ₋₁`

- Inherits from `SequenceGenerator<int>`.
- Constructor: Accepts two initial integer values.
- Implements `GetNext()` using the above formula.

---

### 5. `DoubleSequenceGenerator`

Generates a custom double sequence defined by the recurrence:  
`x₁ = 1, x₂ = 2, xₙ₊₁ = xₙ + xₙ₋₁ / xₙ`

- Inherits from `SequenceGenerator<double>`.
- Constructor: Accepts two initial double values.
- Implements `GetNext()` using the above formula.

---

### 6. `CharSequenceGenerator`

Generates a character sequence defined by the recurrence:  
`x₁ = a, x₂ = b, xₙ₊₁ = (xₙ + xₙ₋₁) % 26 + 'A'`

- Inherits from `SequenceGenerator<char>`.
- Constructor: Accepts two initial `char` values.
- Implements `GetNext()` using the above formula, wrapping around the alphabet.

---

### 7. `DelegateSequenceGenerator<T>`

A generic sequence generator that uses a delegate (function) to define the recurrence relation.

- Inherits from `SequenceGenerator<T>`.
- Constructor: Accepts two initial values and a `Func<T, T, T>` delegate representing the recurrence.
- Implements `GetNext()` by invoking the provided delegate.

---

## Usage Example

var fib = new FibonacciSequenceGenerator(0, 1);
Console.WriteLine(fib.Previous); // 0
Console.WriteLine(fib.Current);  // 1
Console.WriteLine(fib.Next);     // 1
Console.WriteLine(fib.Next);     // 2

var custom = new DelegateSequenceGenerator<int>(1, 2, (x, y) => 6 * x - 8 * y);
Console.WriteLine(custom.Next);  // 4

---

## Summary

- **Extensible**: Add new sequence types by inheriting from `SequenceGenerator<T>`.
- **Generic**: Works with any type and recurrence relation.
- **Consistent API**: All generators expose the same interface for easy use and interchangeability.

---