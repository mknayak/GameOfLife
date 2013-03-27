using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace manas.git.gol.tests
{
    [TestClass]
    public class PositionTest
    {
        [TestMethod]
        public void SimpleClass_Test()
        {
            Position pos = new Position(2, 3);

            Assert.AreEqual(pos.row, 2);
            Assert.AreEqual(pos.column, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Position_with_Less_then_zero_rows_throws_exeption()
        {
            Position pos = new Position(-1, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Position_with_Less_then_zero_column_throws_exeption()
        {
            Position pos = new Position(2, -1);
        }
    }
}
