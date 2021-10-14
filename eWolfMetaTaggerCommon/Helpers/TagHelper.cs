using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eWolfMetaTaggerCommon.Helpers
{
    public static class TagHelper
    {
        public static string CreateFileNameFromTags(string[] parts)
        {
            return CreateFileNameFromTags(parts, " ");
        }

        public static string CreateFileNameFromTags(string[] parts, string delimitor)
        {
            List<string> words = new List<string>();
            bool skip = false;
            foreach (string part in parts)
            {
                if (!skip)
                {
                    skip = true;
                    continue;
                }

                words.Add(MakePascalCase(part));
            }

            words = words.OrderBy(x => x).ToList();

            words.Insert(0, parts[0]);
            return string.Join(delimitor, words);
        }

        public static string[] GetTagsFromName(string name)
        {
            string[] parts = name.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> trimmedParts = new List<string>();

            foreach (string part in parts)
            {
                trimmedParts.Add(part.Trim());
            }

            return trimmedParts.ToArray();
        }

        public static string MakePascalCase(string line)
        {
            string clearnLine = line.Replace("'", string.Empty);
            string[] words = clearnLine.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            StringBuilder sb = new StringBuilder();
            foreach (string word in words)
            {
                string wordHolder = word.First().ToString().ToUpper() + word.Substring(1);
                sb.Append(wordHolder);
            }

            return sb.ToString();
        }
    }
}