using eWolfMetaTaggerCommon.TagData;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace eWolfMetaTaggerCommon.UnitTests.TagData
{
    public class BasicTagListBaseTests
    {
        [Test]
        public void ShouldAddTagsToCurrentSet()
        {
            BasicTagListBase basicTagListBase = new BasicTagListBase
            {
                Set = "Home"
            };

            basicTagListBase.Add("MyTag");

            basicTagListBase.Set.Should().Be("Home");
            basicTagListBase.Tags.Should().Contain("MyTag");

            basicTagListBase.Set = "Other";
            basicTagListBase.Tags.Should().NotContain("MyTag");
        }

        [Test]
        public void ShouldBeAbleAddSomeTagToDifferentSets()
        {
            BasicTagListBase basicTagListBase = new BasicTagListBase
            {
                Set = "Home"
            };

            basicTagListBase.Add("MyTag");
            basicTagListBase.Set = "Other";
            basicTagListBase.Add("MyTag");

            basicTagListBase.Tags.Should().Contain("MyTag");
            basicTagListBase.Set = "Home";
            basicTagListBase.Tags.Should().Contain("MyTag");
        }

        [Test]
        public void ShouldNotBeAbleAddSomeTagToSameSets()
        {
            BasicTagListBase basicTagListBase = new BasicTagListBase
            {
                Set = "Home"
            };

            basicTagListBase.Add("MyTag");
            basicTagListBase.Add("MyTag");
            basicTagListBase.Tags.Should().HaveCount(1);
        }

        [Test]
        public void ShouldOrderTagsAfterAdd()
        {
            BasicTagListBase basicTagListBase = new BasicTagListBase
            {
                Set = "Home"
            };

            basicTagListBase.Add("MyTagB");
            basicTagListBase.Add("MyTagA");
            basicTagListBase.Tags.Should().HaveCount(2);
            basicTagListBase.Tags[0].Should().Be("MyTagA");
            basicTagListBase.Tags[1].Should().Be("MyTagB");
        }
    }
}