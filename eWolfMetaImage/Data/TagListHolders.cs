using eWolfTagHolders.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace eWolfMetaImage.Data
{
    [Serializable]
    public class TagListHolders
    {
        private List<string> _tags { get; set; } = new List<string>();

        public List<string> Tags
        {
            get
            {
                return _tags;
            }
        }

        public void Add(string tag)
        {
            _tags.Add(TagHelper.MakePascalCase(tag));
            Modifyed = true;
        }

        public static string GetFileName { get; } = Configuration.Consts.WorkFolder + "tags.xml";

        public bool Modifyed { get; set; }

        public void Save()
        {
            Save(this);
        }

        public static void Save(TagListHolders taglist)
        {
            XmlSerializer xs = new XmlSerializer(typeof(TagListHolders));
            using (TextWriter tw = new StreamWriter(GetFileName))
            {
                xs.Serialize(tw, taglist);
            }
        }

        public static TagListHolders Load()
        {
            XmlSerializer xs = new XmlSerializer(typeof(TagListHolders));
            using (var sr = new StreamReader(GetFileName))
            {
                return (TagListHolders)xs.Deserialize(sr);
            }
        }

        internal void TidyUp()
        {
            _tags = _tags.Distinct().ToList();
        }
    }
}