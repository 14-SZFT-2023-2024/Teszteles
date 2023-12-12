using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ConsoleApp1;
using FluentAssertions;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        /*[TestMethod]
        public void TesztOsszead()
        {
            Teszteles ts = new Teszteles();
            int result = ts.Osszead(1, 1);
            Assert.AreEqual(2, result);
        }
        */


        [TestMethod]
        public void ElsoTeszt()
        {
            Teszteles ts = new Teszteles();
            int result = ts.ElsoFeladat();
            result.Should().Be(0);
        }
        [TestMethod]
        public void MasodikTeszt()
        {
            Teszteles ts = new Teszteles();
            int result = ts.MasodikFeladat();
            result.Should().Be(0);
        }
        [TestMethod]
        public void HarmadikTeszt()
        {
            Teszteles ts = new Teszteles();
            int result = ts.HarmadikFeladat();
            result.Should().Be(1859);
        }
        [TestMethod]
        public void NegyedikTesztTaxi()
        {
            Teszteles ts = new Teszteles();
            double result1 = ts.NegyedikFeladatTaxi();
            result1.Should().Be(33.75);
        }
        [TestMethod]
        public void NegyedikTesztFuvar()
        {
            Teszteles ts = new Teszteles();
            int result1 = ts.NegyedikFeladatFuvar();
            result1.Should().Be(4);
        }
        [TestMethod]
        public void OtodikTesztKartya()
        {
            Teszteles ts = new Teszteles();
            int result1 = ts.OtodikFeladatKartya();
            result1.Should().Be(793);
        }
        [TestMethod]
        public void OtodikTesztKP()
        {
            Teszteles ts = new Teszteles();
            int result1 = ts.OtodikFeladatKP();
            result1.Should().Be(1050);
        }
        [TestMethod]
        public void OtodikTesztVitatott()
        {
            Teszteles ts = new Teszteles();
            int result1 = ts.OtodikFeladatVitatott();
            result1.Should().Be(4);
        }
        [TestMethod]
        public void OtodikTesztIngyen()
        {
            Teszteles ts = new Teszteles();
            int result1 = ts.OtodikFeladatIngyen();
            result1.Should().Be(10);
        }
        [TestMethod]
        public void OtodikTesztIsmeretlen()
        {
            Teszteles ts = new Teszteles();
            int result1 = ts.OtodikFeladatIsmeretlen();
            result1.Should().Be(2);
        }
        [TestMethod]
        public void HatodikTeszt()
        {
            Teszteles ts = new Teszteles();
            double result = ts.HatodikFeladat();
            result.Should().Be(8099.95);
        }
    }
}
