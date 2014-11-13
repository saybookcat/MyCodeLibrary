
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Translation.Model
{
    public class DictLibrary
    {
        private IList<Dict> _list;

        public DictLibrary()
        {
            _list = new List<Dict>();
        }

        public void Add(Dict dict)
        {
            if (_list.Contains(dict)) return;

            Dict hasDict = GetDictByName(dict.Name);
            if (hasDict == null)
            {
                _list.Add(dict);
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(hasDict.Dz) && string.IsNullOrWhiteSpace(dict.Dz))
                    dict.Dz = hasDict.Dz;
                if (!string.IsNullOrWhiteSpace(hasDict.Idx) && string.IsNullOrWhiteSpace(dict.Idx))
                    dict.Idx = hasDict.Idx;
                if (!string.IsNullOrWhiteSpace(hasDict.Ifo) && string.IsNullOrWhiteSpace(dict.Ifo))
                    dict.Ifo = hasDict.Ifo;
            }
        }

        public void Remove(Dict dict)
        {
            if (_list.Contains(dict)) return;
            _list.Remove(dict);
        }

        public Dict GetDictByName(string name)
        {
            Dict hasDict = (from item in _list where item.Name == name select item).FirstOrDefault();
            return hasDict;
        }

        public void RemoveDictByName(string name)
        {
            var dict = GetDictByName(name);
            Remove(dict);
        }

        public int Count
        {
            get { return _list.Count; }
        }
    }
}
