using eWolfTagHolders.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eWolfMetaImage.Data
{
    [Serializable]
    public abstract class BasicTagListBase
    {
        protected List<string> _tags { get; set; } = new List<string>();

        public bool Modifyed { get; set; }

        public List<string> Tags
        {
            get
            {
                return _tags;
            }
        }

        public void TidyUp()
        {
            _tags = _tags.OrderBy(x => x).ToList();
            _tags = _tags.Distinct().ToList();
        }

        public void Add(string tag)
        {
            _tags.Add(TagHelper.MakePascalCase(tag));
        }
    }
}