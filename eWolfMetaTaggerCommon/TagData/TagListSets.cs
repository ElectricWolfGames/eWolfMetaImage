using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace eWolfMetaTaggerCommon.TagData
{
    [Serializable]
    [XmlRoot("TagListSets")]
    public class TagListSets
    {
        public string Set { get; set; }
        public List<string> SetTags { get; set; } = new List<string>();
    }
}