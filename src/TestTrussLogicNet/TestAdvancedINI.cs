using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualWhirlwind.Truss.Logic.Support;
using System.IO;

namespace TestTrussLogicNet
{
    [TestClass]
    public class TestAdvancedINI
    {
        [TestMethod]
        public void AdvancedINI_ReadFile()
        {
            // C:\Users\cunninghamj\Apps\P\minetest-0.4.14\worlds\T1\map_meta.txt
            // C:\Users\cunninghamj\Apps\P\minetest-0.4.14\worlds\T1\world.mt

            // Arrange

            // Act
            //var Result = AdvancedINIProcessor.ReadFromFile(Path.Combine("TestFiles", "world.mt"));
            var Result = AdvancedINIProcessor.ReadFromFile(Path.Combine("TestFiles", "map_meta.txt"));

            // Assert
            Assert.IsNotNull(Result);
            Assert.IsNotNull(Result.Values);
            Assert.AreNotEqual(Result.Values.Count, 0);
        }

        [TestMethod]
        public void AdvancedINI_SaveFile()
        {
            // Arrange
            //string OriginalContent = File.ReadAllText(Path.Combine("TestFiles", "world.mt"));
            string OriginalContent = File.ReadAllText(Path.Combine("TestFiles", "map_meta.txt"));
            var AINI = AdvancedINIProcessor.Read(OriginalContent);

            // Act
            var Result = AdvancedINIProcessor.Save(AINI);

            // Assert
            Assert.IsNotNull(Result);
            Assert.AreEqual(OriginalContent, Result);
        }
    }
}
