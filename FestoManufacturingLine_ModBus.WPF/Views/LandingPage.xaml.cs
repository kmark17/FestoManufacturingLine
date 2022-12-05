using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FestoManufacturingLine_ModBus.WPF.Views
{
    /// <summary>
    /// Interaction logic for LandingPage.xaml
    /// </summary>
    public partial class LandingPage : UserControl
    {
        public LandingPage()
        {
            InitializeComponent();
        }

        private void GithubButton_Click(object sender, RoutedEventArgs e)
        {
            // UseShellExecute is default to false on .NET Core while true on .NET Framework.
            // Only this value is set to true, the url link can be opened.
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/kmark17/FestoManufacturingLine",
                UseShellExecute = true
            });
        }
    }
}
