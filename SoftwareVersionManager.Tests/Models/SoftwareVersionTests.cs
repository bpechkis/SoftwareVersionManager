using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SoftwareVersionManager.Models.Tests
{
    public class SoftwareVersionTests
    {
        [Fact]
        public void Constructor_MajorVersion_CorrectlySetsMajorVersion()
        {
            var sbjUnderTst = new SoftwareVersion("2");

            Assert.Equal(2, sbjUnderTst.MajorVersion);
            Assert.Equal(0, sbjUnderTst.MinorVersion);
            Assert.Equal(0, sbjUnderTst.PatchVersion);
        }

        [Fact]
        public void Constructor_MinorVersion_CorrectlySetsMajorAndMinorVersion()
        {
            var sbjUnderTst = new SoftwareVersion("2.1");

            Assert.Equal(2, sbjUnderTst.MajorVersion);
            Assert.Equal(1, sbjUnderTst.MinorVersion);
            Assert.Equal(0, sbjUnderTst.PatchVersion);
        }

        [Fact]
        public void Constructor_PatchVersion_CorrectlySetsMajorMinorAndPatchVersion()
        {
            var sbjUnderTst = new SoftwareVersion("3.2.1");

            Assert.Equal(3, sbjUnderTst.MajorVersion);
            Assert.Equal(2, sbjUnderTst.MinorVersion);
            Assert.Equal(1, sbjUnderTst.PatchVersion);
        }

        [Fact]
        public void Constructor_EmptyComponent_DefaultsComponentToZero()
        {
            var sbjUnderTst = new SoftwareVersion("3.2.");

            Assert.Equal(3, sbjUnderTst.MajorVersion);
            Assert.Equal(2, sbjUnderTst.MinorVersion);
            Assert.Equal(0, sbjUnderTst.PatchVersion);
        }

        [Fact]
        public void Constructor_NullVersion_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new SoftwareVersion(null));
        }

        [Fact]
        public void Constructor_NonIntegerComponent_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new SoftwareVersion("2.B.3"));
        }

        [Theory]
        [InlineData(2, 0, 0, 2, 0, 0, 0)]
        [InlineData(2, 0, 0, 2, 0, 1, -1)]
        [InlineData(2, 0, 0, 2, 1, 0, -1)]
        [InlineData(2, 0, 1, 2, 1, 0, -1)]
        public void CompareTo_PassesReadmeTestCases(int leftOpMaj, int leftOpMin, int leftOpPatch, int rightOpMaj, int rightOpMin, int rightOpPatch, int expectedResult)
        {
            var leftOp = new SoftwareVersion(leftOpMaj, leftOpMin, leftOpPatch);
            var rightOp = new SoftwareVersion(rightOpMaj, rightOpMin, rightOpPatch);

            if (expectedResult == 0)
            {
                // Result should be the same regardless of the operands
                Assert.Equal(0, leftOp.CompareTo(rightOp));
                Assert.Equal(0, rightOp.CompareTo(leftOp));
            }
            else
            {   // Check that we get the inverse result if we flip the operands 
                Assert.Equal(Math.Sign(expectedResult), Math.Sign(leftOp.CompareTo(rightOp)));
                Assert.Equal(-Math.Sign(expectedResult), Math.Sign(rightOp.CompareTo(leftOp)));
            }
        }
    }
}
