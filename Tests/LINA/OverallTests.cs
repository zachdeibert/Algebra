//
// OverallTests.cs
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
using NUnit.Framework;
using LINA.Primitives;

namespace LINA {
    [TestFixture]
    public class OverallTests {
        private static void _(params object[] o) {
        }

        [Test]
        public void TestXPlus2Equals4() {
            DependentVariable<AlgebrableInt> x = new DependentVariable<AlgebrableInt>();
            _(x + 2 == 4);
            Assert.AreEqual(2, x.Value);
        }

        [Test]
        public void TestMultipleEquations() {
            DependentVariable<AlgebrableInt> x = new DependentVariable<AlgebrableInt>();
            DependentVariable<AlgebrableInt> y = new DependentVariable<AlgebrableInt>();
            _((y + 3) * 6 == 42, x + y == 10);
            Assert.AreEqual(6, x.Value);
        }

        [Test]
        public void TestFlippingExpressions() {
            DependentVariable<AlgebrableInt> x = new DependentVariable<AlgebrableInt>();
            _(x + 2 == 4);
            Assert.AreEqual(2, x.Value);
            DependentVariable<AlgebrableInt> y = new DependentVariable<AlgebrableInt>();
            _(2 + y == 4);
            Assert.AreEqual(2, y.Value);
        }

        [Test]
        public void TestIndependentVariables() {
            IndependentVariable<AlgebrableInt> width = (AlgebrableInt) 0;
            IndependentVariable<AlgebrableInt> height = (AlgebrableInt) 0;
            DependentVariable<AlgebrableInt> area = new DependentVariable<AlgebrableInt>();
            _(area == width * height);
            Assert.AreEqual(0, area.Value);
            width.Value = 42;
            height.Value = 4;
            Assert.AreEqual(168, area.Value);
        }
    }
}

