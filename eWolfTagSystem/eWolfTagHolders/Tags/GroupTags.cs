using System.Collections.Generic;

namespace eWolfTagHolders.Tags
{
    public class GroupTags
    {
        public string MasterTag { get; set; }

        public List<string> ClearableTags { get; set; } = new List<string>();

        public List<string> IndedifiableTags { get; set; } = new List<string>();

        public GroupTags(string masterTag)
        {
            MasterTag = masterTag;
        }

        public void Add(string tag)
        {
            IndedifiableTags.Add(tag);
        }

        public void AddClearTags(string tag)
        {
            ClearableTags.Add(tag);
        }
    }
}