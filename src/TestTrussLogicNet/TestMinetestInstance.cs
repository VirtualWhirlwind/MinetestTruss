using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualWhirlwind.Truss.Logic.Models;

namespace TestTrussLogicNet
{
    [TestClass]
    public class TestMinetestInstance
    {
        [Ignore]
        [TestMethod]
        public void MinetestInstanceLaunch()
        {
            // Arrange
            MinetestInstance MI = new MinetestInstance()
            {
                BasePath = @"...\minetest-0.4.14"
            };

            // Act
            var Result = MI.Launch();

            // Assert
            Assert.IsTrue(Result);
        }
    }
}
