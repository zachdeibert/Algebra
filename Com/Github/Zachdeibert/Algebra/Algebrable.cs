//
// Algebrable.cs
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
using Com.Github.Zachdeibert.Algebra.Operations;
using Com.Github.Zachdeibert.Algebra.Primitives;

namespace Com.Github.Zachdeibert.Algebra {
    /// <summary>
    /// A base class for all classes representing something one can do algebra on.
    /// </summary>
    public abstract class Algebrable {
        /// <summary>
        /// Adds another algebrable object to this object.
        /// </summary>
        /// <param name="second">The other object.</param>
        public abstract Algebrable Add(Algebrable second);

        /// <summary>
        /// Subtracts another algebrable object from this object.
        /// </summary>
        /// <param name="second">The other object.</param>
        public abstract Algebrable Subtract(Algebrable second);

        /// <summary>
        /// Multiplies another algebrable object by this object.
        /// </summary>
        /// <param name="second">The other object.</param>
        public abstract Algebrable Multiply(Algebrable second);

        /// <summary>
        /// Divides this object by another algebrable object.
        /// </summary>
        /// <param name="second">The other object.</param>
        public abstract Algebrable Divide(Algebrable second);

        /// <summary>
        /// Exponentiates this object by another algebrable object.
        /// </summary>
        /// <param name="second">The other object.</param>
        public abstract Algebrable Exponentiate(Algebrable second);

        /// <summary>
        /// Evaluates this expression into a single algebrable object.
        /// </summary>
        public abstract Algebrable Evaluate();

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to the current <see cref="Com.Github.Zachdeibert.Algebra.Algebrable"/>.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with the current <see cref="Com.Github.Zachdeibert.Algebra.Algebrable"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to the current
        /// <see cref="Com.Github.Zachdeibert.Algebra.Algebrable"/>; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj) {
            return base.Equals(obj);
        }

        /// <summary>
        /// Serves as a hash function for a <see cref="Com.Github.Zachdeibert.Algebra.Algebrable"/> object.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a
        /// hash table.</returns>
        public override int GetHashCode() {
            return base.GetHashCode();
        }

        /// Adds two algebrable objects together.
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        public static Algebrable operator +(Algebrable left, Algebrable right) {
            return new AdditionOperation(left, right);
        }

        /// Subtracts two algebrable objects from each other.
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        public static Algebrable operator -(Algebrable left, Algebrable right) {
            return new SubtractionOperation(left, right);
        }

        /// Multiplies two algebrable objects together.
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        public static Algebrable operator *(Algebrable left, Algebrable right) {
            return new MultiplicationOperation(left, right);
        }

        /// Divides two algebrable objects from each other.
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        public static Algebrable operator /(Algebrable left, Algebrable right) {
            return new DivisionOperation(left, right);
        }

        /// Exponentiates an algebrable object by another algebrable object.
        /// <param name="left">The base operand.</param>
        /// <param name="right">The power operand.</param>
        public static Algebrable operator ^(Algebrable left, Algebrable right) {
            return new ExponentiationOperation(left, right);
        }

        /// Specifies that two algebrable objects are equal
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        public static Equation operator ==(Algebrable left, Algebrable right) {
            return new Equation(left, right);
        }

        /// Unused
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        public static Equation operator !=(Algebrable left, Algebrable right) {
            throw new NotImplementedException();
        }

        /// Converts an int to an algebrable object
        /// <param name="value">The primitive int value.</param>
        public static implicit operator Algebrable(int value) {
            return (AlgebrableInt) value;
        }
    }
}

