using chapter_17_lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace chapter_17_tests
{
   [TestClass]
   public class RectangleDataDrivenTests
   {
      [DataTestMethod]
      [DataRow(true, 3, 4, 5, 6)]
      [DataRow(true, 5, 10, 20, 13)]
      [DataRow(false, 11, 13, 15, 16)]
      public void TestIntersectsWith_DataRows(bool result, int left, int top, int right, int bottom)
      {
         var rectangle = new Rectangle(1, 2, 10, 12);

         Assert.AreEqual(
            result,
            rectangle.IntersectsWith(
               new Rectangle(left, top, right, bottom)));
      }

      public static IEnumerable<object[]> GetData()
      {
         yield return new object[] { true, 3, 4, 5, 6 };
         yield return new object[] { true, 5, 10, 20, 13 };
         yield return new object[] { false, 11, 13, 15, 16 };
      }

      [DataTestMethod]
      [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
      public void TestIntersectsWith_DynamicData(bool result, int left, int top, int right, int bottom)
      {
         var rectangle = new Rectangle(1, 2, 10, 12);

         Assert.AreEqual(
            result,
            rectangle.IntersectsWith(
               new Rectangle(left, top, right, bottom)));
      }     
   }
}
