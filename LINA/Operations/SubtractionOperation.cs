//
// SubtractionOperation.cs
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

namespace LINA.Operations {
    /// <summary>
    /// An algebraic operation for subtracting two numbers
    /// </summary>
    public class SubtractionOperation : AlgebraOperation {
        /// <summary>
        /// Gets the equivalent operation where the left and right operands are flipped.
        /// </summary>
        /// <value>The flipped operation.</value>
        public override AlgebraOperation Flip {
            get {
                return new AdditionOperation(new MultiplicationOperation(-1, Right), Left);
            }
        }

        /// <summary>
        /// Gets the inverse <see cref="LINA.AlgebraOperation"/> with the specified left operand.
        /// </summary>
        /// <returns>The inverse operation.</returns>
        /// <param name="left">The left operand.</param>
        protected override AlgebraOperation GetInverse(Algebrable left) {
            return new AdditionOperation(left, Right);
        }

        /// <summary>
        /// Evaluates this expression into a single algebrable object.
        /// </summary>
        public override Algebrable Evaluate() {
            return ((object) Left) == null ? null : Left.Subtract(Right);
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="LINA.Operations.SubtractionOperation"/> class.
        /// </summary>
        public SubtractionOperation() {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="LINA.Operations.SubtractionOperation"/> class.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        public SubtractionOperation(Algebrable left, Algebrable right) {
            Left = left;
            Right = right;
        }
    }
}

