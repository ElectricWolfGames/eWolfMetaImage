using eWolfTagHolders.Tags;
using FluentAssertions;
using NUnit.Framework;

namespace eWolfTagSystem.UnitTests.Tags
{
    public class GroupTagsHolderTests
    {
        [Test]
        public void ShouldApplyGroup()
        {
            GroupTagsHolder groupTagsHolder = new GroupTagsHolder();
            GroupTags groupTags = new GroupTags("92214,Class9F,2-10-0,LeicesterCity");
            groupTags.Add("92214");
            groupTagsHolder.GroupTagCollection.Add(groupTags);

            TagHolders tagHolders = new TagHolders("92214");

            groupTagsHolder.AdjustTags(tagHolders);

            tagHolders.HasTag("92214").Should().BeFalse();
            tagHolders.HasTag("92214,Class9F,2-10-0,LeicesterCity").Should().BeTrue();
        }

        [Test]
        public void ShouldClearOutOtherTags()
        {
            GroupTagsHolder groupTagsHolder = new GroupTagsHolder();
            GroupTags groupTags = new GroupTags("92214,LeicesterCity,Class9F,2-10-0");
            groupTags.Add("92214");
            groupTags.AddClearTags("LeicesterCity");
            groupTags.AddClearTags("Class9F");

            groupTagsHolder.GroupTagCollection.Add(groupTags);

            TagHolders tagHolders = new TagHolders("123456789 92214 Class9F");

            groupTagsHolder.AdjustTags(tagHolders);

            tagHolders.HasTag("92214").Should().BeFalse();
            tagHolders.Line.Should().Be("123456789 92214,LeicesterCity,Class9F,2-10-0");
        }

        [Test]
        public void ShouldReplaceOtherGroupTags()
        {
            GroupTagsHolder groupTagsHolder = new GroupTagsHolder();
            GroupTags groupTags = new GroupTags("92214,LeicesterCity,Class9F,2-10-0");
            groupTags.Add("92214");
            groupTags.AddClearTags("LeicesterCity");
            groupTags.AddClearTags("Class9F");

            groupTagsHolder.GroupTagCollection.Add(groupTags);

            TagHolders tagHolders = new TagHolders("123456789 92214,Class9F,2-10-0,LeicesterCity");

            groupTagsHolder.AdjustTags(tagHolders);

            tagHolders.HasTag("92214").Should().BeFalse();
            tagHolders.Line.Should().Be("123456789 92214,LeicesterCity,Class9F,2-10-0");
        }
    }
}