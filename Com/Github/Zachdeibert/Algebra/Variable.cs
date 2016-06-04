//
// Variable.cs
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

namespace Com.Github.Zachdeibert.Algebra {
    /// <summary>
    /// The base class for algebrable variables.
    /// </summary>
    public abstract class Variable<T> : Algebrable where T : Algebrable {
        /// <summary>
        /// Gets the value of this variable.
        /// </summary>
        /// <value>The value.</value>
        public abstract T Value {
            get;
        }

        /// <summary>
        /// Adds another algebrable object to this object.
        /// </summary>
        /// <param name="second">The other object.</param>
        public override Algebrable Add(Algebrable second) {
            return new AdditionOperation(this, second);
        }

        /// <summary>
        /// Subtracts another algebrable object from this object.
        /// </summary>
        /// <param name="second">The other object.</param>
        public override Algebrable Subtract(Algebrable second) {
            return new SubtractionOperation(this, second);
        }

        /// <summary>
        /// Multiplies another algebrable object by this object.
        /// </summary>
        /// <param name="second">The other object.</param>
        public override Algebrable Multiply(Algebrable second) {
            return new MultiplicationOperation(this, second);
        }

        /// <summary>
        /// Divides this object by another algebrable object.
        /// </summary>
        /// <param name="second">The other object.</param>
        public override Algebrable Divide(Algebrable second) {
            return new DivisionOperation(this, second);
        }

        /// <summary>
        /// Exponentiates this object by another algebrable object.
        /// </summary>
        /// <param name="second">The other object.</param>
        public override Algebrable Exponentiate(Algebrable second) {
            return new ExponentiationOperation(this, second);
        }

        /// <summary>
        /// Takes the logarithm of this object in the base of another algebrable object.
        /// </summary>
        /// <param name="second">The other object.</param>
        public override Algebrable Logarithm(Algebrable second) {
            return new LogarithmOperation(this, second);
        }

        /// <summary>
        /// Evaluates this expression into a single algebrable object.
        /// </summary>
        public override Algebrable Evaluate() {
            return Value;
        }
    }
}

