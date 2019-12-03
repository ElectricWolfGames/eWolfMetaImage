using eWolfTagHolders.Tags;
using System.IO;

namespace eWolfMetaImage.Data
{
    public class ImageDetails
    {
        public ImageDetails(string filename)
        {
            FilePath = filename;
            FileName = Path.GetFileNameWithoutExtension(filename);
            PathOnly = filename.Replace(Path.GetFileName(filename), string.Empty);
            ExceptionName = Path.GetExtension(filename);
            TagHolder = new TagHolders(FileName);
        }

        public string DisplayTags
        {
            get
            {
                return TagHolder.LineWithCommons;
            }
        }

        public string ExceptionName { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }

        public bool Modifiy
        {
            get
            {
                return TagHolder.Modifiy;
            }
        }

        public string NewPath
        {
            get
            {
                return PathOnly + TagHolder.Line + ExceptionName;
            }
        }

        public string PathOnly { get; set; }

        public TagHolders TagHolder { get; set; }

        public void Update()
        {
            string filename = NewPath;
            FilePath = filename;
            FileName = Path.GetFileNameWithoutExtension(filename);
            PathOnly = filename.Replace(Path.GetFileName(filename), string.Empty);
            ExceptionName = Path.GetExtension(filename);
            TagHolder = new TagHolders(FileName);
        }

        internal void AddRemoveTag(string tag)
        {
            if (!TagHolder.HasTag(tag))
            {
                TagHolder.AddTag(tag);
            }
            else
            {
                TagHolder.RemoveTag(tag);
            }
        }
    }
}