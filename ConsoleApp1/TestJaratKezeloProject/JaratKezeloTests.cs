using System;
using System.Collections.Generic;
using NUnit.Framework;
using JaratKezeloProject;

namespace TestJaratKezeloProject
{
    [TestFixture]
    public class JaratKezeloTests
    {
        [Test]
        public void TestUjJarat()
        {
            var jaratKezelo = new JaratKezelo();
            jaratKezelo.UjJarat("J123", "BUD", "NYC", new DateTime(2023, 6, 7, 12, 0, 0));

            var result = jaratKezelo.MikorIndul("J123");
            Assert.That(result, Is.EqualTo(new DateTime(2023, 6, 7, 12, 0, 0)));

            Assert.Throws<ArgumentException>(() => jaratKezelo.UjJarat("J123", "BUD", "LAX", new DateTime(2023, 6, 8, 12, 0, 0)));
            Assert.Throws<ArgumentException>(() => jaratKezelo.MikorIndul("J999"));
        }

        [Test]
        public void TestKeses()
        {
            var jaratKezelo = new JaratKezelo();
            jaratKezelo.UjJarat("J123", "BUD", "NYC", new DateTime(2023, 6, 7, 12, 0, 0));
            jaratKezelo.Keses("J123", 30);

            var result = jaratKezelo.MikorIndul("J123");
            Assert.That(result, Is.EqualTo(new DateTime(2023, 6, 7, 12, 30, 0)));

            Assert.Throws<ArgumentException>(() => jaratKezelo.Keses("J123", -60));
            Assert.Throws<ArgumentException>(() => jaratKezelo.Keses("J999", 10));
        }

        [Test]
        public void TestMikorIndul()
        {
            var jaratKezelo = new JaratKezelo();
            jaratKezelo.UjJarat("J123", "BUD", "NYC", new DateTime(2023, 6, 7, 12, 0, 0));
            jaratKezelo.Keses("J123", 10);
            jaratKezelo.Keses("J123", 20);

            var result = jaratKezelo.MikorIndul("J123");
            Assert.That(result, Is.EqualTo(new DateTime(2023, 6, 7, 12, 30, 0)));

            Assert.Throws<ArgumentException>(() => jaratKezelo.MikorIndul("J999"));
        }

        [Test]
        public void TestJaratokRepuloterrol()
        {
            var jaratKezelo = new JaratKezelo();
            jaratKezelo.UjJarat("J123", "BUD", "NYC", new DateTime(2023, 6, 7, 12, 0, 0));
            jaratKezelo.UjJarat("J124", "BUD", "LAX", new DateTime(2023, 6, 8, 12, 0, 0));
            jaratKezelo.UjJarat("J125", "LAX", "NYC", new DateTime(2023, 6, 9, 12, 0, 0));

            var result = jaratKezelo.JaratokRepuloterrol("BUD");

            Assert.That(result, Contains.Item("J123"));
            Assert.That(result, Contains.Item("J124"));
            Assert.That(result, Does.Not.Contain("J125"));

            Assert.That(jaratKezelo.JaratokRepuloterrol("Nem létező reptér."), Is.Empty);
        }
    }
}
