using eWolfTagHolders.Tags;
using FluentAssertions;
using NUnit.Framework;

namespace eWolfTagSystem.UnitTests.Tags
{
    public class TagHoldersTests
    {
        [Test]
        public void ShouldAddTagsToTagHolders()
        {
            TagHolders th = new TagHolders("PreTag Tags");
            th.AddTag("Another tag");
            th.Line.Should().Be("PreTag AnotherTag Tags");
        }

        [TestCase("1234 one two three")]
        public void ShouldClearAllTags(string line)
        {
            TagHolders th = new TagHolders(line);
            th.ClearAllTagsAfterFirst();
            th.Modifiy.Should().BeTrue();
            th.Line.Should().Be("1234");
        }

        [Test()]
        public void ShouldCopyTags()
        {
            TagHolders from = new TagHolders("1111 one two three");
            TagHolders to = new TagHolders("2222 more and somemore");

            to.CopyTags(from);
            from.Line.Should().Be("1111 One Three Two");
            to.Line.Should().Be("2222 One Three Two");
        }

        [Test]
        public void ShouldCreateTagHolders()
        {
            TagHolders th = new TagHolders("PreTag Test Tags");
            th.Line.Should().Be("PreTag Tags Test");
        }

        [Test]
        public void ShouldFindGetTagFromPartGroup()
        {
            TagHolders th = new TagHolders("2222 Part,Of,Group");
            th.HasTagInGroup("Group").Should().BeTrue();
        }

        [Test]
        public void ShouldGetTagFromPartGroupReturnTag()
        {
            TagHolders th = new TagHolders("2222 Part,Of,Group");
            th.GetTagFromPartGroup("Group").Should().Be("Part,Of,Group");
            th.GetTagFromPartGroup("Of").Should().Be("Part,Of,Group");
            th.GetTagFromPartGroup("Part").Should().Be("Part,Of,Group");
        }

        [TestCase("One", true)]
        [TestCase("Non", false)]
        public void ShouldHasTag(string tagToCheck, bool expected)
        {
            TagHolders th = new TagHolders("One Two");
            th.HasTag(tagToCheck).Should().Be(expected);
        }

        [Test]
        public void ShouldNotAddSameTag()
        {
            TagHolders th = new TagHolders("2222 more and somemore");
            th.AddTag("Some");
            th.Line.Should().Be("2222 And More Some Somemore");
            th.Modifiy.Should().BeTrue();
            th.Modifiy = false;

            th.AddTag("Some");
            th.Line.Should().Be("2222 And More Some Somemore");
            th.AddTag(string.Empty);
            th.Line.Should().Be("2222 And More Some Somemore");
            th.Modifiy.Should().BeFalse();
        }

        [Test]
        public void ShouldRemoveTag()
        {
            TagHolders th = new TagHolders("PreTag TagOne TagTwo");
            th.RemoveTag("TagOne");
            th.RemoveTag("NotInList");
            th.Line.Should().Be("PreTag TagTwo");
        }

        [Test]
        public void ShouldUpdateTagHolders()
        {
            TagHolders th = new TagHolders("PreTag Test Tags");
            th.Line = "PreTag Tag2 Tag";
            th.Line.Should().Be("PreTag Tag Tag2");
        }
    }
}