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
    public abstract class AlgebraOperation : Algebrable {
        public class Inverser {
            private readonly AlgebraOperation Op;

            public AlgebraOperation this[Algebrable left] {
                get {
                    return Op.GetInverse(left);
                }
            }

            internal Inverser(AlgebraOperation op) {
                Op = op;
            }
        }

        public readonly Inverser Inverse;

        public Algebrable Left {
            get;
            set;
        }

        public Algebrable Right {
            get;
            set;
        }

        protected abstract AlgebraOperation GetInverse(Algebrable left);

        public override Algebrable Add(Algebrable second) {
            return Evaluate().Add(second);
        }

        public override Algebrable Subtract(Algebrable second) {
            return Evaluate().Subtract(second);
        }

        public override Algebrable Multiply(Algebrable second) {
            return Evaluate().Multiply(second);
        }

        public override Algebrable Divide(Algebrable second) {
            return Evaluate().Divide(second);
        }

        public override Algebrable Exponentiate(Algebrable second) {
            return Evaluate().Exponentiate(second);
        }

        protected AlgebraOperation() {
            Inverse = new Inverser(this);
        }
    }
}

