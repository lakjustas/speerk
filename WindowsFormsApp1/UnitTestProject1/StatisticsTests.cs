using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApp1;

namespace UnitTestProject1
{
    [TestClass]
    public class StatisticsTests
    {

        Statistics stats = new Statistics();

        [TestMethod]
        public void SetScoresTests()
        {
            Statistics stats = new Statistics();

            stats.SetScores(5, 2);

            int score1 = 5;
            int score2 = 2;
            
            bool exp1 = true;
            bool exp2 = true;

            bool act1 = score1.Equals(stats.getScore1());
            bool act2 = score2.Equals(stats.getScore2());

            Assert.AreEqual(exp1, act1);
            Assert.AreEqual(exp2, act2);
        }
        [TestMethod]
        public void SetScoresTest_Null()
        {
            Statistics stats = new Statistics();

            int score1 = 5;
            int score2 = 2;

            bool exp1 = false;
            bool exp2 = false;

            bool act1 = score1.Equals(stats.getScore1());
            bool act2 = score2.Equals(stats.getScore2());

            Assert.AreEqual(exp1, act1);
            Assert.AreEqual(exp2, act2);

        }
    }
}
