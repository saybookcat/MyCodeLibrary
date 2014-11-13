using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace Misc
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Load();
        }

        private void Load()
        {
            DevExpress.Xpf.Core.ThemeManager.ApplicationThemeName = "MetropolisLight";
        }
    }
}
