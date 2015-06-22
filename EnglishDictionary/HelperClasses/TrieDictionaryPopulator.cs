using Learning.Libs.DataStructures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;

namespace EnglishDictionary.HelperClasses
{
    public class TrieDictionaryPopulator
    {
        public static Trie<string> Populate()
        {
            Trie<string> trie = new Trie<string>();
            int insertions = 0;
            DictionarySanitizer.WriteSanitizedDictionary();
            string[] lines = File.ReadAllLines(WebConfigurationManager.AppSettings[Constants.DICTIONARY_FILE__PROCESSED]);
            foreach (string l in lines)
            {
                string[] parts = l.Split(new string[] { "======" }, StringSplitOptions.None);
                string word = parts[0].Trim();
                if (Regex.IsMatch(word, @"^[a-zA-Z]+$"))
                {
                    if (trie.TryAddWord(word, parts[1].Trim()))
                    {
                        insertions++;
                    }
                }
            }

            return trie;
        }
    }
}