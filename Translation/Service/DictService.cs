using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Translation.Model;

namespace Translation.Service
{
    public class DictService
    {
        private static DictService _dictService;

        public static DictService Instance
        {
            get { return _dictService ?? (_dictService = new DictService()); }
        }

        private DictLibrary _dictLibrary;

        public DictLibrary DictLibrary
        {
            get { return _dictLibrary; }
        }

        private DictService()
        {
            
        }

        #region Load

        public void Load()
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory + @"dict";
            if (Path.IsPathRooted(path))
            {
                Load(path);
            }
        }

        private void Load(string path)
        {
            _dictLibrary=new DictLibrary();
            //TODO 加载散文件
            var files = Directory.GetFiles(path);
            var folders = Directory.GetDirectories(path);
            LoadFolders(folders);
        }

        private void LoadFolders(string[] folders)
        {
            if (folders == null) return;
            foreach (string folder in folders)
            {
                if(!Path.IsPathRooted(folder)) continue;
                Dict dict=new Dict();
                string name = Path.GetFileNameWithoutExtension(folder);
                dict.Name = name;
                
                //加载文件
                string[] files = Directory.GetFiles(folder);
                foreach (string file in files)
                {
                    string ext = Path.GetExtension(file);
                    if (string.IsNullOrWhiteSpace(ext)) break;
                    if (ext.ToLower().Contains("dz"))
                    {
                        dict.Dz = file;
                    }
                    if (ext.ToLower().Contains("idx"))
                    {
                        dict.Idx = file;
                    }
                    if (ext.ToLower().Contains("ifo"))
                    {
                        dict.Ifo = file;
                    }
                }
                _dictLibrary.Add(dict);
            }
        }

        #endregion

        public string Transloation(string strContext)
        {
            //TODO
            return string.Empty;
        }

    }
}
