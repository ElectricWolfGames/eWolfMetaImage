using eWolfTagHolders.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eWolfMetaImage.Data
{
    [Serializable]
    public abstract class BasicTagListBase
    {
        public string Set { get; set; } = "Default";
        protected List<string> _tags { get; set; } = new List<string>();

        protected Dictionary<string, List<string>> _tagSets { get; set; } = new Dictionary<string, List<string>>();

        public bool Modifyed { get; set; }

        public BasicTagListBase()
        {
            _tagSets.Add(Set, new List<string>());
        }

        public void FixDefaultSet()
        {
            foreach (string tag in _tags)
            {
                Add(tag);
            }
        }

        public List<string> Tags
        {
            get
            {
                CreateSet();
                return _tagSets[Set];
            }
        }

        public void TidyUp()
        {
            _tagSets[Set] = _tagSets[Set].OrderBy(x => x).ToList();
            _tagSets[Set] = _tagSets[Set].Distinct().ToList();
        }

        public void CreateSet()
        {
            if (!_tagSets.TryGetValue(Set, out _))
            {
                _tagSets.Add(Set, new List<string>());
            }
        }

        public void Add(string tag)
        {
            CreateSet();
            _tagSets[Set].Add(TagHelper.MakePascalCase(tag));
        }
    }
}