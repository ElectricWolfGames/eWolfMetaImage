using eWolfTagSystem.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace eWolfTagSystem.Tags
{
    public class TagHolders
    {
        private string[] _parts = new string[0];

        public TagHolders(string line)
        {
            Line = line;
        }

        public void AddTag(string line)
        {
            List<string> words = _parts.ToList();
            words.Add(TagHelper.MakePascalCase(line));

            _parts = words.ToArray();
        }

        public string Line
        {
            get
            {
                return TagHelper.CreateFileNameFromTags(_parts);
            }
            set
            {
                _parts = TagHelper.GetTagsFromName(value);
            }
        }
    }
}