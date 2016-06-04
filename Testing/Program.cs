using System;
using Com.Github.Zachdeibert.Algebra;
using Com.Github.Zachdeibert.Algebra.Primitives;

namespace Testing {
    class MainClass {
        public static void IgnoreResult(params object[] objs) {
        }

        public static void Main(string[] args) {
            DependentVariable<AlgebrableInt> x = new DependentVariable<AlgebrableInt>();
            IgnoreResult((x + 1 * 2) * 4 == (2 ^ (AlgebrableInt) 5));
            Console.WriteLine(x.Value);
        }
    }
}
