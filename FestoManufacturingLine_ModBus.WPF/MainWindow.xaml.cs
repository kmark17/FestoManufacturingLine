using MahApps.Metro.Controls;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FestoManufacturingLine_ModBus.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow(object dataContext)
        {
            InitializeComponent();

            DataContext = dataContext;
        }

        private void HamburgerMenuControl_OnItemInvoked(object sender, HamburgerMenuItemInvokedEventArgs e)
        {
            hamburgerMenu.Content = e.InvokedItem;
        }

        private void HamburgerMenuControl_HamburgerButtonClick(object sender, RoutedEventArgs e)
        {
            if (!Separator_1.IsVisible || !Separator_2.IsVisible)
            {
                Separator_1.IsVisible = true;
                Separator_2.IsVisible = true;
            }
            else
            {
                Separator_1.IsVisible = false;
                Separator_2.IsVisible = false;
            }
        }
    }
}
