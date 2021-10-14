using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace eWolfMetaImage.Data
{
    [Serializable]
    [XmlRoot("TagListSets")]
    public class TagListSets
    {
        public string Set { get; set; }
        public List<string> SetTags { get; set; } = new List<string>();
    }
}