using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using Microsoft.VisualStudio.QualityTools.UnitTestFramework;
using NUnit.Framework.Internal;
using System.Linq;

namespace TTCDictionary.UnitTests
{
    [TestFixture]
    public class LanguageDictionaryTest
    {
        private LanguageDictionary SUT;

        private Dictionary<string, string> list;

        [SetUp]
        public void Setup()
        {
            list = new Dictionary<string, string>();

            SUT = new LanguageDictionary(list);
        }

        #region Test cases for Adding value to dictionary
        [Test]
        public void When_adding_a_word_which_does_not_exist_should_return_true()
        {
            // Arrange.
            var word = "test";
            var lang = "English";

            // Act.
            var result = SUT.Add(lang, word);

            // Assert.
            Assert.IsTrue(result);

            //var listCheck = this.list.FirstOrDefault(i => i.Key == lang && i.Value == word);

            //Assert.IsTrue(listCheck.Key == lang);
            //Assert.IsTrue(listCheck.Value == word);
        }

        [Test]
        public void When_adding_a_word_which_does_exist_should_return_false()
        {
            // Arrange.
            var word = "test";
            //this.SUT.Add("English", word);

            // Act.
            var result = SUT.Add("English", word);

            // Assert.
            Assert.IsFalse(result);
        }

        [Test]
        public void When_adding_a_word_which_does_exist_but_in_a_different_language_should_return_true()
        {
            // Arrange.
            var word = "test";
            //this.SUT.Add("English", word);

            // Act.
            var result = SUT.Add("German", word);

            // Assert.
            Assert.IsTrue(result);
        }
        #endregion

        #region Test cases for checking value in dictionary
        [Test]
        public void When_checking_a_word_which_does_not_exist_should_return_false()
        {
            // Arrange.
            var word = "test";

            // Act.
            var result = SUT.Check("English", word);

            // Assert.
            Assert.IsFalse(result);
        }

        [Test]
        public void When_checking_a_word_which_does_exist_should_return_true()
        {
            // Arrange.
            var word = "test";
            this.SUT.Add("English", word);

            // Act.
            var result = this.SUT.Check("English", word);

            // Assert.
            Assert.IsTrue(result);
        }
        #endregion

        #region Test cases for searching value in dictionary
        [Test]
        public void When_searching_a_word_which_does_exist_should_return_value()
        {
            // Arrange.
            this.SUT.Add("English", "test");
            this.SUT.Add("German", "test1");
            // Act.
            var result = this.SUT.Search("test");

            // Assert.
            Assert.IsTrue(result.Contains("test"));
        }

        [Test]
        public void When_searching_a_word_which_does_not_exist_should_return_empty_list()
        {
            // Arrange.
            this.SUT.Add("English", "test");
            this.SUT.Add("German", "test1");
            // Act.
            var result = this.SUT.Search("hi");

            // Assert.
            Assert.That(result, Is.Empty);
            Assert.IsFalse(result.Contains("hi"));
        }
        #endregion
    }
}
