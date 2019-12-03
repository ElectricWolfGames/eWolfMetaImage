using eWolfTagHolders.Services;
using System.Collections.Generic;

namespace eWolfMetaImage.Data
{
    public class AllTagHolder
    {
        public List<string> AllTags { get; set; } = new List<string>();

        public AllTagHolder()
        {
            PopulateData();
        }

        private void PopulateData()
        {
            AllTags.Add(string.Empty);
            AllTags.Add("GCR");
            AllTags.Add("Butterly");
        }

        public static AllTagHolder GetAllTagHolder
        {
            get
            {
                return ServiceLocator.Instance.GetService<AllTagHolder>();
            }
        }
    }
}