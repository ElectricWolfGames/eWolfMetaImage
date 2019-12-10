using eWolfTagHolders.Helpers;
using FluentAssertions;
using NUnit.Framework;

namespace eWolfTagSystem.UnitTests.Helpers
{
    public class TagHelperTests
    {
        [TestCase("Name", "Name")]
        [TestCase("Name ", "Name")]
        [TestCase("Name Test Split", "Name", "Test", "Split")]
        [TestCase("    Name        Test   Split  ", "Name", "Test", "Split")]
        public void ShouldGetAllTags(string name, params string[] tags)
        {
            string[] parts = TagHelper.GetTagsFromName(name);

            foreach (string tag in tags)
            {
                parts.Should().Contain(tag);
            }
        }

        [TestCase("word", "Word")]
        [TestCase("word with more", "WordWithMore")]
        [TestCase("    word with    more", "WordWithMore")]
        [TestCase("IveGotPacalAllReady", "IveGotPacalAllReady")]
        [TestCase("I've Got ", "IveGot")]
        public void ShouldMakePascalCase(string line, string expectedLine)
        {
            TagHelper.MakePascalCase(line).Should().Be(expectedLine);
        }

        [TestCase("0123", "a", "d", "0123 A D")]
        [TestCase("0123", "PartOfWords", "a", "0123 A PartOfWords")]
        public void ShouldCreateFileName(string partA, string partB, string partC, string expected)
        {
            string[] words = new string[] { partA, partB, partC };
            TagHelper.CreateFileNameFromTags(words).Should().Be(expected);
        }
    }
}