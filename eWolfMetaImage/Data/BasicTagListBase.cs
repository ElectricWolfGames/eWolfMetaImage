using eWolfTagHolders.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace eWolfMetaImage.Data
{
    [Serializable]
    [XmlRoot("BasicTagListBase")]
    [XmlInclude(typeof(TagListSets))]
    public abstract class BasicTagListBase
    {
        public BasicTagListBase()
        {
        }

        public TagListSets GetTagHolder
        {
            get
            {
                CreateSet();
                return TagSets.First(x => x.Set == Set);
            }
        }

        [XmlIgnore]
        public bool Modifyed { get; set; }

        public string Set { get; set; }

        [XmlIgnore]
        public List<string> Tags
        {
            get
            {
                CreateSet();
                return TagSets.First(x => x.Set == Set).SetTags;
            }
        }

        [XmlArrayItem("TagSetsLists")]
        public List<TagListSets> TagSets { get; set; } = new List<TagListSets>();

        public void Add(string tag)
        {
            var tagHolderSet = GetTagHolder;
            tagHolderSet.SetTags.Add(TagHelper.MakePascalCase(tag));
            TidyUp();
        }

        public void CreateSet()
        {
            if (!TagSets.Any(x => x.Set == Set))
            {
                TagListSets tls = new TagListSets
                {
                    Set = Set
                };
                TagSets.Add(tls);
            }
        }

        public void TidyUp()
        {
            foreach (var tagSet in TagSets)
            {
                tagSet.SetTags = tagSet.SetTags.OrderBy(x => x).ToList();
                tagSet.SetTags = tagSet.SetTags.Distinct().ToList();
            }
        }
    }
}