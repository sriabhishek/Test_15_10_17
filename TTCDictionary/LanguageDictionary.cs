using System.Collections.Generic;
using System.Linq;

namespace TTCDictionary
{
    public class LanguageDictionary : ILanguageDictionary
    {
        private Dictionary<string, string> list;

        public LanguageDictionary(Dictionary<string, string> list)
        {
            this.list = list;
        }

        public bool Check(string language, string word)
        {
            if (list.Any(i => i.Key == language && i.Value == word))
            {
                return true;
            }
            return false;
        }

        public bool Add(string language, string word)
        {

            if (list.Any(i => i.Key == language && i.Value == word))
            {
                return false;
            }
            else
            {
                list.Add(language, word);

                return true;
            }
            if(!list.ContainsValue(word))
            {
                return false;
            }
        }

        public IEnumerable<string> Search(string word)
        {
            List<string> searchedlist = (from x in list where x.Value.Contains(word) select x.Value).ToList();
            return searchedlist;
        }
    }
}
