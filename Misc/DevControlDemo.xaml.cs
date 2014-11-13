using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DevExpress.Xpf.Core;
using Misc.ViewModel;

namespace Misc
{
    /// <summary>
    /// DevControlDemo.xaml 的交互逻辑
    /// </summary>
    public partial class DevControlDemo : DXWindow
    {
        public DevControlDemo()
        {
            InitializeComponent();
            this.DataContext = new DevControlViewModel();
        }

        private void ToggleButton_OnChecked(object sender, RoutedEventArgs e)
        {
            DevExpress.Xpf.Core.ThemeManager.ApplicationThemeName = "MetropolisLight";
        }

        private void ToggleButton_OnChecked1(object sender, RoutedEventArgs e)
        {
           DevExpress.Xpf.Core.ThemeManager.ApplicationThemeName = "Office2013";
        }
    }
}
