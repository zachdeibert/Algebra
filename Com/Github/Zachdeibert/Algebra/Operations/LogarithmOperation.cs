//
// LogarithmOperation.cs
//
// Author:
//       zach <${AuthorEmail}>
//
// Copyright (c) 2016 zach
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

namespace Com.Github.Zachdeibert.Algebra.Operations {
    /// <summary>
    /// An algebraic operation that is the inverse of exponentiation.
    /// </summary>
    public class LogarithmOperation : AlgebraOperation {
        /// <summary>
        /// Gets the equivalent operation where the left and right operands are flipped.
        /// </summary>
        /// <value>The flipped operation.</value>
        public override AlgebraOperation Flip {
            get {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets the inverse <see cref="Com.Github.Zachdeibert.Algebra.AlgebraOperation"/> with the specified left operand.
        /// </summary>
        /// <returns>The inverse operation.</returns>
        /// <param name="left">The left operand.</param>
        protected override AlgebraOperation GetInverse(Algebrable left) {
            return new ExponentiationOperation(Right, left);
        }

        /// <summary>
        /// Evaluates this expression into a single algebrable object.
        /// </summary>
        public override Algebrable Evaluate() {
            return ((object) Left) == null ? null : Left.Exponentiate(Right);
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="Com.Github.Zachdeibert.Algebra.Operations.LogarithmOperation"/> class.
        /// </summary>
        public LogarithmOperation() {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="Com.Github.Zachdeibert.Algebra.Operations.LogarithmOperation"/> class.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        public LogarithmOperation(Algebrable left, Algebrable right) {
            Left = left;
            Right = right;
        }
    }
}

