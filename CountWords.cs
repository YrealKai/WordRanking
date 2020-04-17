using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WordRanking
{
    public static class StringExtension
    {
        public static string StripPunctuation(this string s)
        {
            var sb = new StringBuilder();
            foreach (char c in s)
            {
                if (!char.IsPunctuation(c))
                    sb.Append(c);
            }
            return sb.ToString();
        }
    }
    public class CountWords
    {
        public Dictionary<string, int> CountWordsAndOrder(string title, int length, string order)
        {
            string path = @"../../../Books/";
            string ext = "";
            var listing = new Dictionary<string, int>();
            var files = Directory.GetFiles(path, title + ".*");
            if (files.Length > 0)
            {
                ext = files[0].Substring(files[0].Length - 3, 3);
                
            }
            string pathAndTitle = path + title + "." +ext;
            
            foreach (string line in File.ReadLines(pathAndTitle))
            {
                var words = line.StripPunctuation().Split(" ");
                foreach (var word in words)
                {
                    if (word.Length >= length)
                    {
                        var lowerWord = word.ToLower();
                        if (!listing.ContainsKey(lowerWord))
                        {
                            listing.Add(lowerWord, 1);
                        }
                        else
                        {
                            var currentCount = listing[lowerWord];
                            listing[lowerWord] = currentCount + 1;
                        }
                    }
                }
            }
            if (order == "asc") { 
                return listing.OrderBy(x => x.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            }
            else
            {
                return listing.OrderByDescending(x => x.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            }
        }
    }
}
