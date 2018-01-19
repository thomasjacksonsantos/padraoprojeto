using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestProject1.Class;

namespace UnitTestProject1
{
    [TestClass]
    public class MonoState
    {
        [TestInitialize]
        public void SetUp()
        {
            Turnstile turnstile = new Turnstile();
            turnstile.Reset();
        }

        [TestMethod]
        public void TestInit()
        {
            Turnstile turnstile = new Turnstile();
            Assert.IsTrue(turnstile.Locked());
            Assert.IsFalse(turnstile.Alarm());
        }

        [TestMethod]
        public void TestCoin()
        {
            Turnstile turnstile = new Turnstile();
            turnstile.Coin();
            var t2 = new Turnstile();
            Assert.IsFalse(t2.Locked());
            Assert.IsFalse(t2.Alarm());
            Assert.AreEqual(t2.Coins, 1);
        }

        [TestMethod]
        public void TestCoinAndPass()
        {
            Turnstile t1 = new Turnstile();
            t1.Coin();
            t1.Pass();

            Turnstile t2 = new Turnstile();
            Assert.IsTrue(t1.Locked());
            Assert.IsFalse(t1.Alarm());
            Assert.AreEqual(1, t1.Coins, "coins");
        }

        [TestMethod]
        public void TestTwoCoins()
        {
            Turnstile t = new Turnstile();
            t.Coin();
            t.Coin();

            Turnstile t1 = new Turnstile();
            Assert.IsFalse(t1.Locked());
            Assert.AreEqual(1, t1.Coins);
            Assert.AreEqual(1, t1.Refunds);
            Assert.IsFalse(t1.Alarm());
        }
    }
}
