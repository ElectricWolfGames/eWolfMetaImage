using eWolfTagHolders.Helpers;
using eWolfTagHolders.Services;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace eWolfMetaImage.Data
{
    public class LocationTagHolderServices
    {
        public List<string> AllTags { get; set; } = new List<string>();

        public LocationTagHolderServices()
        {
            // PopulateData();
        }

        private void PopulateData()
        {
            AllTags.Add(string.Empty);
            AllTags.Add("GCR");
            AllTags.Add("Butterly");
            LocationTagHolderServices.Save(this);
        }

        public static string GetFileName { get; } = Configuration.Consts.WorkFolder + "LocationTags.xml";

        public static LocationTagHolderServices GetAllTagHolder
        {
            get
            {
                return ServiceLocator.Instance.GetService<LocationTagHolderServices>();
            }
        }

        internal void TidyUp()
        {
            AllTags = AllTags.Distinct().ToList();
        }

        public void Add(string tag)
        {
            AllTags.Add(TagHelper.MakePascalCase(tag));
        }

        public void Save()
        {
            LocationTagHolderServices.Save(this);
        }

        public static void Save(LocationTagHolderServices taglist)
        {
            XmlSerializer xs = new XmlSerializer(typeof(LocationTagHolderServices));
            using (TextWriter tw = new StreamWriter(GetFileName))
            {
                xs.Serialize(tw, taglist);
            }
        }

        public static LocationTagHolderServices Load()
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(LocationTagHolderServices));
                using (var sr = new StreamReader(GetFileName))
                {
                    return (LocationTagHolderServices)xs.Deserialize(sr);
                }
            }
            catch
            {
            }

            LocationTagHolderServices locationTagHolderServices = new LocationTagHolderServices();
            locationTagHolderServices.PopulateData();
            return locationTagHolderServices;
        }
    }
}