using MailSenderLibrary;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace MailSenderLibrary.Tests
{
   
    [TestClass]
    public class PasswordEncoderTests
    {
        /// <summary>
        /// выполняется перед всей сессией тестирования
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            Debug.WriteLine("Инициализация теста");
        }
        /// <summary>
        /// Перед началом очередного модульного теста
        /// </summary>
        /// <param name="context"> контекст с иформацией о текущем модульном тесте</param>
        [ClassInitialize]
        public static void TestInitialize(TestContext context)
        {

        }

        [ClassCleanup]
        public static void TestCleanup()
        {

        }

        [TestMethod]
        public void Encode_abc_bcd_key1()
        {

            /// Arrange  Act  Assert
            // Arrange
            var str = "abc";
            var expected = "bcd";
            var key = 1;

            // Act
            var actual = PasswordEncoder.Encode(str, key);

            // assert

            Assert.AreEqual(expected, actual);
            Debug.WriteLine("");
                   
            //StringAssert.Contains(); сравнение строк
            //CollectionAssert.Contains(); сравнение коллекций
        }
        

        [TestMethod]
        public void DecodeTest()
        {
            /// Arrange  Act  Assert
            // Arrange
            var str = "bcd";
            var expected = "abc";
            var key = 1;

            // Act
            var actual = PasswordEncoder.Decode(str, key);

            // assert
            Assert.AreEqual(expected, actual);
        }

    }
}
