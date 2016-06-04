//
// AlgebraOperation.cs
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
    /// Represents a binary operation between two algebrable objects.
    /// </summary>
    public abstract class AlgebraOperation : Algebrable {
        /// <summary>
        /// Helper class for syntax of inverting an operation.
        /// </summary>
        public class Inverser {
            private readonly AlgebraOperation Op;

            /// <summary>
            /// Gets the inverse <see cref="Com.Github.Zachdeibert.Algebra.AlgebraOperation"/> with the specified left operand.
            /// </summary>
            /// <param name="left">The left operand.</param>
            public AlgebraOperation this[Algebrable left] {
                get {
                    return Op.GetInverse(left);
                }
            }

            internal Inverser(AlgebraOperation op) {
                Op = op;
            }
        }

        /// <summary>
        /// Gets the inverse <see cref="Com.Github.Zachdeibert.Algebra.AlgebraOperation"/> with the specified left operand.
        /// </summary>
        public readonly Inverser Inverse;

        /// <summary>
        /// Gets or sets the left operand.
        /// </summary>
        /// <value>The left operand.</value>
        public Algebrable Left {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the right operand.
        /// </summary>
        /// <value>The right operand.</value>
        public Algebrable Right {
            get;
            set;
        }

        /// <summary>
        /// Gets the equivalent operation where the left and right operands are flipped.
        /// </summary>
        /// <value>The flipped operation.</value>
        public abstract AlgebraOperation Flip {
            get;
        }

        /// <summary>
        /// Gets the inverse <see cref="Com.Github.Zachdeibert.Algebra.AlgebraOperation"/> with the specified left operand.
        /// </summary>
        /// <returns>The inverse operation.</returns>
        /// <param name="left">The left operand.</param>
        protected abstract AlgebraOperation GetInverse(Algebrable left);

        /// <summary>
        /// Adds another algebrable object to this object.
        /// </summary>
        /// <param name="second">The other object.</param>
        public override Algebrable Add(Algebrable second) {
            return Evaluate().Add(second);
        }

        /// <summary>
        /// Subtracts another algebrable object from this object.
        /// </summary>
        /// <param name="second">The other object.</param>
        public override Algebrable Subtract(Algebrable second) {
            return Evaluate().Subtract(second);
        }

        /// <summary>
        /// Multiplies another algebrable object by this object.
        /// </summary>
        /// <param name="second">The other object.</param>
        public override Algebrable Multiply(Algebrable second) {
            return Evaluate().Multiply(second);
        }

        /// <summary>
        /// Divides this object by another algebrable object.
        /// </summary>
        /// <param name="second">The other object.</param>
        public override Algebrable Divide(Algebrable second) {
            return Evaluate().Divide(second);
        }

        /// <summary>
        /// Exponentiates this object by another algebrable object.
        /// </summary>
        /// <param name="second">The other object.</param>
        public override Algebrable Exponentiate(Algebrable second) {
            return Evaluate().Exponentiate(second);
        }

        /// <summary>
        /// Takes the logarithm of this object in the base of another algebrable object.
        /// </summary>
        /// <param name="second">The other object.</param>
        public override Algebrable Logarithm(Algebrable second) {
            return Evaluate().Logarithm(second);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Com.Github.Zachdeibert.Algebra.AlgebraOperation"/> class.
        /// </summary>
        protected AlgebraOperation() {
            Inverse = new Inverser(this);
        }
    }
}

