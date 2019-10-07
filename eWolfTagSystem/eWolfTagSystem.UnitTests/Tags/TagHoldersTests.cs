using eWolfTagSystem.Tags;
using FluentAssertions;
using NUnit.Framework;

namespace eWolfTagSystem.UnitTests.Tags
{
    public class TagHoldersTests
    {
        [Test]
        public void ShouldCreateTagHolders()
        {
            TagHolders th = new TagHolders("Test Tags");
            th.Line.Should().Be("Test Tags");
        }

        [Test]
        public void ShouldUpdateTagHolders()
        {
            TagHolders th = new TagHolders("Test Tags");
            th.Line = "Tag2 Tag";
            th.Line.Should().Be("Tag2 Tag");
        }

        [Test]
        public void ShouldAddTagsToTagHolders()
        {
            TagHolders th = new TagHolders("Test Tags");
            th.AddTag("Another tag");
            th.Line.Should().Be("Test Tags AnotherTag");
        }
    }
}