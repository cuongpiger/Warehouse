using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bai_1;

namespace TestCoor
{
    [TestClass]
    public class UnitTest1
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "[DataDirectory]\\Data.csv", "Data.csv", DataAccessMethod.Sequential),
            DeploymentItem("Data.csv")]
        public void TestMethod1()
        {
            Coor a = new Coor(GetValue("Ax"), GetValue("Ay"));
            Coor b = new Coor(GetValue("Bx"), GetValue("By"));
            double res = a.CalcDistance(b);
            double hopedRes = GetValue("HopedRes");

            Assert.AreEqual(res, hopedRes);
        }

        private int GetValue(string col)
        {
            return Int32.Parse(testContextInstance.DataRow[col].ToString());
        }
    }
}
