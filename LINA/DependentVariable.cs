//
// DependentVariable.cs
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
using System.Collections.Generic;

namespace LINA {
    /// <summary>
    /// An algebrable variable that changes as a result of another independent
    /// variable changing. This is generally what is being solved for in an equation.
    /// </summary>
    public class DependentVariable<T> : Variable<T>, IDependentVariable<T> where T : Algebrable {
        private readonly List<Equation> Equations;

        /// <summary>
        /// Gets the value of this variable.
        /// </summary>
        /// <value>The value.</value>
        public override T Value {
            get {
                foreach ( Equation eq in Equations ) {
                    try {
                        return eq.Solve(this);
                    } catch ( UnsolvableException ) {
                    } catch ( NotImplementedException ex ) {
                        Console.Error.WriteLine(ex);
                    }
                }
                throw new UnsolvableException("None of the equations were able to be solved");
            }
        }

        /// <summary>
        /// Adds an equation to the list of equations this dependent variable is
        /// in. This equation can then be used for solving for the value of the
        /// dependent variable.
        /// </summary>
        /// <param name="eq">The equation.</param>
        public void AddEquation(Equation eq) {
            if ( eq != null && !Equations.Contains(eq) ) {
                Equations.Add(eq);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LINA.DependentVariable{T}"/> class.
        /// </summary>
        public DependentVariable() {
            Equations = new List<Equation>();
        }
    }
}

