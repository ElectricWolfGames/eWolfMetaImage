using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eWolfTagSystem.Helpers
{
    public static class TagHelper
    {
        public static string[] GetTagsFromName(string name)
        {
            string[] parts = name.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            List<string> trimmedParts = new List<string>();

            foreach (string part in parts)
            {
                trimmedParts.Add(part.Trim());
            }

            return trimmedParts.ToArray();
        }

        public static string CreateFileNameFromTags(string[] parts)
        {
            List<string> words = new List<string>();
            foreach (string part in parts)
            {
                words.Add(MakePascalCase(part));
            }

            return string.Join(" ", words);
        }

        public static string MakePascalCase(string line)
        {
            string clearnLine = line.Replace("'", string.Empty);
            string[] words = clearnLine.Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries);

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