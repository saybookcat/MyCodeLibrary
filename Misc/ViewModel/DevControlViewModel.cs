using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpf.DemoBase;

namespace Misc.ViewModel
{
    public class DevControlViewModel :NavBarModule
    {
        protected override void SelectView(object sender, System.Windows.RoutedEventArgs e)
        {
            base.SelectView(sender, e);
            UpdateControlAvailability();
        }

        private void UpdateControlAvailability()
        {
            
        }
    }
}
