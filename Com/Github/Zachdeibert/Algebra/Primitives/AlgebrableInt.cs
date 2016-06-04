//
// AlgebrableInt.cs
//
// Author:
//       Zach Deibert <zachdeibert@gmail.com>
//
// Copyright (c) 2016 Zach Deibert
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;

namespace Com.Github.Zachdeibert.Algebra.Primitives {
    /// <summary>
    /// An Algebrable class representing a primitive int.
    /// </summary>
    public class AlgebrableInt : Algebrable {
        private readonly int Value;

        /// <summary>
        /// Adds another algebrable object to this object.
        /// </summary>
        /// <param name="second">The other object.</param>
        public override Algebrable Add(Algebrable second) {
            return second is AlgebrableInt ? Value + ((AlgebrableInt) second).Value : Add(second.Evaluate());
        }

        /// <summary>
        /// Subtracts another algebrable object from this object.
        /// </summary>
        /// <param name="second">The other object.</param>
        public override Algebrable Subtract(Algebrable second) {
            return second is AlgebrableInt ? Value - ((AlgebrableInt) second).Value : Subtract(second.Evaluate());
        }

        /// <summary>
        /// Multiplies another algebrable object by this object.
        /// </summary>
        /// <param name="second">The other object.</param>
        public override Algebrable Multiply(Algebrable second) {
            return second is AlgebrableInt ? Value * ((AlgebrableInt) second).Value : Multiply(second.Evaluate());
        }

        /// <summary>
        /// Divides this object by another algebrable object.
        /// </summary>
        /// <param name="second">The other object.</param>
        public override Algebrable Divide(Algebrable second) {
            return second is AlgebrableInt ? Value / ((AlgebrableInt) second).Value : Divide(second.Evaluate());
        }

        /// <summary>
        /// Exponentiates this object by another algebrable object.
        /// </summary>
        /// <param name="second">The other object.</param>
        public override Algebrable Exponentiate(Algebrable second) {
            return second is AlgebrableInt ? (int) Math.Pow(Value, ((AlgebrableInt) second).Value) : Exponentiate(second.Evaluate());
        }

        /// <summary>
        /// Evaluates this expression into a single algebrable object.
        /// </summary>
        public override Algebrable Evaluate() {
            return this;
        }

        /// Converts an int to an <see cref="Com.Github.Zachdeibert.Algebra.Primitives.AlgebrableInt"/>
        /// <param name="value">The primitivie value.</param>
        public static implicit operator AlgebrableInt(int value) {
            return new AlgebrableInt(value);
        }

        /// Converts an <see cref="Com.Github.Zachdeibert.Algebra.Primitives.AlgebrableInt"/> to an int
        /// <param name="value">The algebrable value.</param>
        public static implicit operator int(AlgebrableInt value) {
            return value.Value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Com.Github.Zachdeibert.Algebra.Primitives.AlgebrableInt"/> class.
        /// </summary>
        /// <param name="value">The primitive value.</param>
        public AlgebrableInt(int value) {
            Value = value;
        }
    }
}

