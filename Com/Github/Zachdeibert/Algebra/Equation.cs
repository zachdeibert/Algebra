//
// Equation.cs
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

namespace Com.Github.Zachdeibert.Algebra {
    public class Equation {
        private Algebrable _Left;
        private Algebrable _Right;

        public Algebrable Left {
            get {
                return _Left;
            }
        }

        public Algebrable Right {
            get {
                return _Right;
            }
        }

        public Equation Inverse {
            get {
                return new Equation(Right, Left, false);
            }
        }

        public static bool HasDV<T>(Algebrable expression, DependentVariable<T> dv) where T : Algebrable {
            if ( expression is AlgebraOperation ) {
                return HasDV((AlgebraOperation) expression, dv);
            } else {
                return ((object) expression) == ((object) dv);
            }
        }

        public static bool HasDV<T>(AlgebraOperation expression, DependentVariable<T> dv) where T : Algebrable {
            return HasDV(expression.Left, dv) || HasDV(expression.Right, dv);
        }

        public T Solve<T>(DependentVariable<T> dv) where T : Algebrable {
            if ( HasDV(Left, dv) ) {
                if ( HasDV(Right, dv) ) {
                    throw new NotImplementedException("A DV on both sides of an equation is not yet supported");
                } else {
                    Algebrable left = Left;
                    Algebrable right = Right;
                    while ( ((object) left) != ((object) dv) ) {
                        if ( left is AlgebraOperation ) {
                            AlgebraOperation op = (AlgebraOperation) left;
                            Algebrable subLeft;
                            Algebrable subRight;
                            if ( HasDV(op.Left, dv) ) {
                                if ( HasDV(op.Right, dv) ) {
                                    throw new NotImplementedException("Only 1 DV is currently supported");
                                } else {
                                    subLeft = op.Left;
                                    subRight = op.Right;
                                }
                            } else if ( HasDV(op.Right, dv) ) {
                                throw new NotImplementedException("This equation is not yet supporetd");
                            } else {
                                throw new InvalidOperationException("Internal error");
                            }
                            left = subLeft;
                            right = op.Inverse[right];
                        } else {
                            throw new NotImplementedException("Unknown equation type");
                        }
                    }
                    return (T) right.Evaluate();
                }
            } else if ( HasDV(Right, dv) ) {
                return Inverse.Solve(dv);
            } else {
                throw new InvalidOperationException("DV does not exist in equation");
            }
        }

        private void AddDependents(Algebrable op) {
            if ( op is AlgebraOperation ) {
                AddDependents((AlgebraOperation) op);
            } else if ( op is IDependentVariable<Algebrable> ) {
                ((IDependentVariable<Algebrable>) op).AddEquation(this);
            }
        }

        private void AddDependents(AlgebraOperation op) {
            AddDependents(op.Left);
            AddDependents(op.Right);
        }

        private Equation(Algebrable left, Algebrable right, bool register) {
            _Left = left;
            _Right = right;
            if ( register ) {
                AddDependents(left);
                AddDependents(right);
            }
        }

        public Equation(Algebrable left, Algebrable right) : this(left, right, true) {
        }
    }
}

