using Microsoft.VisualStudio.TestTools.UnitTesting;
using A4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A4.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        //1.............................................................................

        [TestMethod(),Timeout(1000)]
        [DeploymentItem(@"TestData","A4_TestData")]
        public void ChangingMony1Test()
        {
            TestTools.RunLocalTest("A4", Program.ProcessChangingMony1, "TD1");
        }

        //2.............................................................................
        [TestMethod(), Timeout(1000)]
        [DeploymentItem(@"TestData", "A4_TestData")]
        public void MaximizingLoot2Test()
        {
            TestTools.RunLocalTest("A4", Program.ProcessMaximizingLoot2, "TD2");
        }
        
        //3.............................................................................
        [TestMethod(),Timeout(1000)]
        [DeploymentItem(@"TestData", "A4_TestData")]

        public void MaximizingOnlineAdRevenue3Test()
        {
            TestTools.RunLocalTest("A4", Program.ProcessMaximizingOnlineAdRevenue3, "TD3");
        }

        //4..............................................................................
        [TestMethod(), Timeout(1000)]
        [DeploymentItem(@"TestData", "A4_TestData")]

        public void CollectingSignatures4Test()
        {
            TestTools.RunLocalTest("A4", Program.ProcessCollectingSignatures4, "TD4");
        }

        //5..............................................................................

        [TestMethod(), Timeout(1000)]
        [DeploymentItem(@"TestData", "A4_TestData")]

        public void MaximizeNumberOfPrizePlaces5Test()
        {
            TestTools.RunLocalTest("A4", Program.ProcessMaximizeNumberOfPrizePlaces5, "TD5");
        }

        //6...........................................................................

        [TestMethod(), Timeout(1000)]
        [DeploymentItem(@"TestData", "A4_TestData")]

        public void MaximizeSalary6Test()
        {
            TestTools.RunLocalTest("A4", Program.ProcessMaximizeSalary6, "TD6");
        }
    }
}