# C# Algebra Library
[![Build Status](https://travis-ci.org/zachdeibert/Algebra.svg?branch=master)](https://travis-ci.org/zachdeibert/Algebra)

This library allows you to do algebra in your code without having to evaluate it manually.

For example,
```c#
using System;
using LINA;
using LINA.Primitives;

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
