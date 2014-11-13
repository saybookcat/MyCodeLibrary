using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms.VisualStyles;
using System.Windows.Media;
using DevExpress.Data.XtraReports.ServiceModel.DataContracts;
using DevExpress.Internal.DXWindow;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.DemoBase;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.NavBar;

namespace Misc.ViewModel
{
    public class NavBarModule : DemoModule
    {
        public NavBarModule()
        {
            this.Loaded += new RoutedEventHandler(OnLoaded);
            this.Unloaded += new RoutedEventHandler(OnUnloaded);
        }

        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            ThemeManager.ThemeChanged+=new ThemeChangedRoutedEventHandler(OnThemeChanged);
            OnThemeChanged(null, null);
        }

        private void OnThemeChanged(DependencyObject sender, ThemeChangedRoutedEventArgs e)
        {
            if (navBarControl != null)
            {
                navBarControl.ClearValue(ForegroundProperty);
                navBarControl.SetResourceReference(ForegroundProperty,
                    new DevExpress.Xpf.NavBar.Themes.CommonElementsThemeKeyExtension()
                    {
                        ResourceKey = DevExpress.Xpf.NavBar.Themes.CommonElementsThemeKeys.ItemForegroundBrush,
                        ThemeName = ThemeManager.ApplicationThemeName
                    });
            }
            ItemForegroundOnBackgroundPanel =
                new SolidColorBrush(IsDarkBackgroundTheme()
                    ? System.Windows.Media.Colors.White
                    : System.Windows.Media.Colors.Black);
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            ThemeManager.ThemeChanged -= OnThemeChanged;
            OnThemeChanged(null, null);
        }

        protected internal NavBarControl navBarControl { get; set; }

        public System.Windows.Media.SolidColorBrush ItemForegroundOnBackgroundPanel
        {
            get { return (System.Windows.Media.SolidColorBrush) GetValue(ItemForegroundOnBackgroundPanelPeroperty); }
            set { SetValue(ItemForegroundOnBackgroundPanelPeroperty,value); }
        }

        public static readonly DependencyProperty ItemForegroundOnBackgroundPanelPeroperty =
            DependencyPropertyManager.Register("ItemForegroundOnBackgroundPanel",
                typeof (System.Windows.Media.SolidColorBrush), typeof (NavBarModule),
                new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty ItemForegroundProperty =
            DependencyPropertyManager.Register("ItemForeground", typeof (System.Windows.Media.SolidColorBrush),
                typeof (NavBarModule), new FrameworkPropertyMetadata((null)));


        private static bool IsDarkBackgroundTheme()
        {
            return
                ThemeManager.ApplicationThemeName == "MetropolistDark" || ThemeManager.ApplicationThemeName ==
                    "Office2010Black";
        }

        protected virtual void SelectView(object sender, RoutedEventArgs e)
        {
            if (navBarControl == null)
                return;
            string name = (string) ((ListBoxEdit) sender).SelectedItem;
            switch (name)
            {
                case "Explorer Bar":
                    navBarControl.View = GetExplorerBarView();
                    break;
                case "Navigation Pane":
                    navBarControl.View = GetNavigationPaneView();
                    break;
                case "Side Bar":
                    navBarControl.View = GetSideBarView();
                    break;
                default:
                    throw new ArgumentException("Could not find specified view.");
            }
        }

        protected virtual ExplorerBarView GetExplorerBarView()
        {
            return new ExplorerBarView();
        }

        protected virtual NavigationPaneView GetNavigationPaneView()
        {
            return new NavigationPaneView();
        }

        protected virtual SideBarView GetSideBarView()
        {
           return new SideBarView();
        }
    }
}
