using HoneycombWalk;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HoneycombWalkTests
{
   [TestClass]
   public class UnitTest1
   {
      [TestMethod]
      public void TestNumberOfPathsFor2Steps()
      {
         int expected = 6;
         int result = HoneycombWalkProgram.numberOfPaths(2);
         Assert.AreEqual(expected, result, "Wrong output for 2 steps");
      }

      [TestMethod]
      public void TestNumberOfPathsFor4Steps()
      {
         int expected = 90;
         int result = HoneycombWalkProgram.numberOfPaths(4);
         Assert.AreEqual(expected, result, "Wrong output for 4 steps");
      }
   }
}
