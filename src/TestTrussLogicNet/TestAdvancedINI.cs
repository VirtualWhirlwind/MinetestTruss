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
            // Arrange

            // Act
            var Result1 = AdvancedINIProcessor.ReadFromFile(Path.Combine("TestFiles", "world.mt"));
            var Result2 = AdvancedINIProcessor.ReadFromFile(Path.Combine("TestFiles", "map_meta.txt"));

            // Assert
            Assert.IsNotNull(Result1);
            Assert.IsNotNull(Result1.Values);
            Assert.AreNotEqual(Result1.Values.Count, 0);

            Assert.IsNotNull(Result2);
            Assert.IsNotNull(Result2.Values);
            Assert.AreNotEqual(Result2.Values.Count, 0);
        }

        [TestMethod]
        public void AdvancedINI_SaveFile()
        {
            // Arrange
            string OriginalContent1 = File.ReadAllText(Path.Combine("TestFiles", "world.mt"));
            string OriginalContent2 = File.ReadAllText(Path.Combine("TestFiles", "map_meta.txt"));

            var AINI1 = AdvancedINIProcessor.Read(OriginalContent1);
            var AINI2 = AdvancedINIProcessor.Read(OriginalContent2);

            // Act
            var Result1 = AdvancedINIProcessor.Save(AINI1);
            var Result2 = AdvancedINIProcessor.Save(AINI2);

            // Assert
            Assert.IsNotNull(Result1);
            Assert.AreEqual(OriginalContent1, Result1);

            Assert.IsNotNull(Result2);
            Assert.AreEqual(OriginalContent2, Result2);
        }
    }
}
