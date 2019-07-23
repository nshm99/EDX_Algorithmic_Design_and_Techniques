using Microsoft.VisualStudio.TestTools.UnitTesting;
using A2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;
using System.Diagnostics;

namespace A2.Tests
{
    [TestClass()]
    public class ProgramTests
    {

        [TestMethod()]
        //[DeploymentItem("TestData", "TestData")]
        [DeploymentItem("TestData", "A2_TestData")]
        public void GradedTest_Correctness()
        {
            TestTools.RunLocalTest("A2",Program.Process);
        }

        [TestMethod(),Timeout(500)]
        //[DeploymentItem("TestData", "TestData")]
        [DeploymentItem("TestData", "A2_TestData")]
        public void GradedTest_Performance()
        {
            TestTools.RunLocalTest("A2",Program.Process);
        }

        [TestMethod()]
        public void GradedTest_Stress()
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            while (timer.Elapsed.Seconds <= 5)
            {
                Random rnd = new Random();
                Random rnd2 = new Random();
                int n = rnd.Next(2, 10);
                List<int> numbers = new List<int>();
                for (int i = 0; i < n; i++)
                {
                    numbers.Add(rnd2.Next(0, 8));

                }

                var result1 = Program.NaiveMaxPairwiseProduct(numbers);
                var result2 = Program.FastMaxPairwiseProduct(numbers);
                Assert.AreEqual(result1, result2);
            }
        }


    }
}