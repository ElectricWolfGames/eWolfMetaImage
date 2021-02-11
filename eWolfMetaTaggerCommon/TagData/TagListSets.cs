using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace eWolfMetaTaggerCommon.TagData
{
    [Serializable]
    [XmlRoot("TagListSets")]
    public class TagListSets
    {
        public List<string> SetTags { get; set; } = new List<string>();
        public string Set { get; set; }
    }
}