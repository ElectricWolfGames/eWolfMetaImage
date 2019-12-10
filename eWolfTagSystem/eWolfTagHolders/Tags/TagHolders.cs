using eWolfTagHolders.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace eWolfTagHolders.Tags
{
    public class TagHolders
    {
        private string[] _parts = new string[0];

        public TagHolders(string line)
        {
            Line = line;
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

        public string LineWithCommons
        {
            get
            {
                return TagHelper.CreateFileNameFromTags(_parts, " - ");
            }
        }

        public bool Modifiy { get; set; }

        public void AddTag(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
                return;

            if (HasTag(line))
                return;

            List<string> words = _parts.ToList();
            words.Add(TagHelper.MakePascalCase(line));

            _parts = words.ToArray();
            Modifiy = true;
        }

        public void ClearAllTagsAfterFirst()
        {
            string firstWord = _parts[0];
            _parts = new string[1] { firstWord };
            Modifiy = true;
        }

        public void CopyTags(TagHolders tagHolder)
        {
            List<string> words = tagHolder._parts.ToList();
            words = words.Skip(1).ToList();
            words.Insert(0, _parts[0]);
            _parts = words.ToArray();
            Modifiy = true;
        }

        public string GetTagFromPartGroup(string tag)
        {
            foreach (string part in _parts)
            {
                if (part.Contains(","))
                {
                    string[] groupParts = part.Split(',');
                    foreach (string groupPart in groupParts)
                    {
                        if (groupPart == tag)
                            return part;
                    }
                }
            }
            return string.Empty;
        }

        public bool HasTag(string tag)
        {
            return _parts.Contains(tag);
        }

        public bool HasTagInGroup(string tag)
        {
            return GetTagFromPartGroup(tag) != string.Empty;
        }

        public void RemoveTag(string tag)
        {
            List<string> items = new List<string>();

            foreach (string part in _parts)
            {
                if (part != tag)
                    items.Add(part);
            }

            _parts = items.ToArray();
            Modifiy = true;
        }
    }
}