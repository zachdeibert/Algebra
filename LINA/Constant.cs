//
// Constant.cs
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

namespace LINA {
    /// <summary>
    /// A constant value that is algebrable.
    /// </summary>
    public class Constant<T> : ConstantBase<T> where T : Algebrable {
        /// <summary>
        /// Gets the value of the constant.
        /// </summary>
        /// <value>The value.</value>
        public new T Value {
            get {
                return base.Value;
            }
        }

        /// <summary>
        /// Adds another algebrable object to this object.
        /// </summary>
        /// <param name="second">The other object.</param>
        public override Algebrable Add(Algebrable second) {
            return second is Constant<T> ? (((object) Value) == null ? null : Value.Add(second)) : base.Add(second);
        }

        /// <summary>
        /// Subtracts another algebrable object from this object.
        /// </summary>
        /// <param name="second">The other object.</param>
        public override Algebrable Subtract(Algebrable second) {
            return second is Constant<T> ? (((object) Value) == null ? null : Value.Subtract(second)) : base.Subtract(second);
        }

        /// <summary>
        /// Multiplies another algebrable object by this object.
        /// </summary>
        /// <param name="second">The other object.</param>
        public override Algebrable Multiply(Algebrable second) {
            return second is Constant<T> ? (((object) Value) == null ? null : Value.Multiply(second)) : base.Multiply(second);
        }

        /// <summary>
        /// Divides this object by another algebrable object.
        /// </summary>
        /// <param name="second">The other object.</param>
        public override Algebrable Divide(Algebrable second) {
            return second is Constant<T> ? (((object) Value) == null ? null : Value.Divide(second)) : base.Divide(second);
        }

        /// <summary>
        /// Exponentiates this object by another algebrable object.
        /// </summary>
        /// <param name="second">The other object.</param>
        public override Algebrable Exponentiate(Algebrable second) {
            return second is Constant<T> ? (((object) Value) == null ? null : Value.Exponentiate(second)) : base.Exponentiate(second);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LINA.Constant{T}"/> class.
        /// </summary>
        /// <param name="value">The value of the constant.</param>
        public Constant(T value) {
            _Value = value;
        }
    }
}

