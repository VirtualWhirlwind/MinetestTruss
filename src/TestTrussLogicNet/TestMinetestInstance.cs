using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualWhirlwind.Truss.Logic.Models;

namespace TestTrussLogicNet
{
    [TestClass]
    public class TestMinetestInstance
    {
        [TestMethod]
        public void MinetestInstanceLaunch()
        {
            // Arrange
            MinetestInstance MI = new MinetestInstance()
            {
                BasePath = @"C:\Users\cunninghamj\Apps\P\minetest-0.4.14"
            };

            // Act
            var Result = MI.Launch();

            // Assert
            Assert.IsTrue(Result);
        }
    }
}
