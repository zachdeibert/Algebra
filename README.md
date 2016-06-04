# C# Algebra Library
This library allows you to do algebra in your code without having to evaluate it manually.

For example,
```c#
using System;
using Com.Github.Zachdeibert.Algebra;
using Com.Github.Zachdeibert.Primitives;

namespace AlgebraTest {
    class MainClass {
        public static void IgnoreResult(params object[] o) {
        }
        
        public static void Main(string[] args) {
            DependentVariable<AlgebrableInt> x = new DependentVariable<AlgebrableInt>();
            IgnoreResult(x + 2 == 4);
            Console.WriteLine(x.Value); // Prints 2
        }
    }
}
```
