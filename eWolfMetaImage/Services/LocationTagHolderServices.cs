using eWolfCommon.Helpers;
using eWolfTagHolders.Services;

using System.IO;
using System.Xml.Serialization;

namespace eWolfMetaImage.Data
{
    public class LocationTagHolderServices : BasicTagListBase
    {
        public static string GetFileName { get; } = "LocationTags.xml";

        public static LocationTagHolderServices GetLocationTagHolderServices
        {
            get
            {
                return ServiceLocator.Instance.GetService<LocationTagHolderServices>();
            }
        }

        public static LocationTagHolderServices Load()
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(LocationTagHolderServices));
                using (var sr = new StreamReader(Configuration.Consts.WorkFolder + GetFileName))
                {
                    return (LocationTagHolderServices)xs.Deserialize(sr);
                }
            }
            catch
            {
            }

            LocationTagHolderServices locationTagHolderServices = new LocationTagHolderServices();
            return locationTagHolderServices;
        }

        public void Save()
        {
            LocationTagHolderServices.Save(this);
        }

        private static void Save(LocationTagHolderServices taglist)
        {
            FileHelper.CreateBackUp(Configuration.Consts.WorkFolder, GetFileName);

            XmlSerializer xs = new XmlSerializer(typeof(LocationTagHolderServices));
            using (TextWriter tw = new StreamWriter(Configuration.Consts.WorkFolder + GetFileName))
            {
                xs.Serialize(tw, taglist);
            }
        }
    }
}