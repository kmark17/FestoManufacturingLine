using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for HandlingStationView.xaml
    /// </summary>
    public partial class HandlingStationView : UserControl
    {
        public HandlingStationView()
        {
            InitializeComponent();

            try
            {
                stationAnimationMediaElement.Source = new Uri(new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName + "/Resources/Animations/HandlingStation.wmv", UriKind.Absolute);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void stationAnimationMediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            stationAnimationMediaElement.Position = new TimeSpan(0, 0, 0);
            stationAnimationMediaElement.Play();
        }
    }
}
