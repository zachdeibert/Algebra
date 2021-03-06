﻿//
// PrimitiveAlgebrable.cs
//
// Author:
//       Zach Deibert<zachdeibert@gmail.com>
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

namespace LINA.Primitives {
    /// <summary>
    /// Base class for all primitive algebrable objects.
    /// </summary>
    public abstract class PrimitiveAlgebrable<T> : Algebrable, IPrimitiveAlgebrable where T : IConvertible {
        /// <summary>
        /// Converts this instance to a decimal value.
        /// </summary>
        /// <returns>The decimal value.</returns>
        public abstract decimal ToDecimal();

        /// <summary>
        /// Converts a decimal value to an algebrable object
        /// </summary>
        /// <returns>The algebrable object.</returns>
        /// <param name="value">The decimal value.</param>
        public abstract Algebrable ToAlgebrable(decimal value);

        /// <summary>
        /// Adds another algebrable object to this object.
        /// </summary>
        /// <param name="second">The other object.</param>
        public override Algebrable Add(Algebrable second) {
            return second is IPrimitiveAlgebrable ? ToAlgebrable(ToDecimal() + ((IPrimitiveAlgebrable) second).ToDecimal()) : Add(second.Evaluate());
        }

        /// <summary>
        /// Subtracts another algebrable object from this object.
        /// </summary>
        /// <param name="second">The other object.</param>
        public override Algebrable Subtract(Algebrable second) {
            return second is IPrimitiveAlgebrable ? ToAlgebrable(ToDecimal() - ((IPrimitiveAlgebrable) second).ToDecimal()) : Subtract(second.Evaluate());
        }

        /// <summary>
        /// Multiplies another algebrable object by this object.
        /// </summary>
        /// <param name="second">The other object.</param>
        public override Algebrable Multiply(Algebrable second) {
            return second is IPrimitiveAlgebrable ? ToAlgebrable(ToDecimal() * ((IPrimitiveAlgebrable) second).ToDecimal()) : Multiply(second.Evaluate());
        }

        /// <summary>
        /// Divides this object by another algebrable object.
        /// </summary>
        /// <param name="second">The other object.</param>
        public override Algebrable Divide(Algebrable second) {
            return second is IPrimitiveAlgebrable ? ToAlgebrable(ToDecimal() / ((IPrimitiveAlgebrable) second).ToDecimal()) : Divide(second.Evaluate());
        }

        /// <summary>
        /// Exponentiates this object by another algebrable object.
        /// </summary>
        /// <param name="second">The other object.</param>
        public override Algebrable Exponentiate(Algebrable second) {
            return second is IPrimitiveAlgebrable ? ToAlgebrable((decimal) Math.Pow((double) ToDecimal(), (double) ((IPrimitiveAlgebrable) second).ToDecimal())) : Exponentiate(second.Evaluate());
        }

        /// <summary>
        /// Takes the logarithm of this object in the base of another algebrable object.
        /// </summary>
        /// <param name="second">The other object.</param>
        public override Algebrable Logarithm(Algebrable second) {
            return second is IPrimitiveAlgebrable ? ToAlgebrable((decimal) Math.Log((double) ToDecimal(), (double) ((IPrimitiveAlgebrable) second).ToDecimal())) : Logarithm(second.Evaluate());
        }

        /// <summary>
        /// Evaluates this expression into a single algebrable object.
        /// </summary>
        public override Algebrable Evaluate() {
            return this;
        }
    }
}

