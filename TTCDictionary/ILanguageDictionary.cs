﻿using System.Collections.Generic;

namespace TTCDictionary
{
    public interface ILanguageDictionary
    {
        bool Check(string language, string word);

        bool Add(string language, string word);

        IEnumerable<string> Search(string word);
    }
}
