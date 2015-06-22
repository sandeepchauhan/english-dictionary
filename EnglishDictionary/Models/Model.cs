using EnglishDictionary.HelperClasses;
using Learning.Libs.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnglishDictionary.Models
{
    public class Model
    {
        public static Trie<string> TrieDictionary;
        
        public static void Populate()
        {
            TrieDictionary = TrieDictionaryPopulator.Populate();
        }
    }
}