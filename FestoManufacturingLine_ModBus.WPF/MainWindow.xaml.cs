using EasyModbus;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace FestoManufacturingLine_ModBus.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private ModbusClient modeBusClient = new ModbusClient();
        private DispatcherTimer pollTimer = new DispatcherTimer();
        private Thread? tRead;
        private Thread? tWrite;
        private Thread? tAlwaysRunning;

        public MainWindow(object dataContext)
        {
            InitializeComponent();

            DataContext = dataContext;
        }

        private void pollTimer_Tick(object sender, EventArgs e)
        {
            if (modeBusClient.Connected)
            {
                Read();
                Write();
            }
        }

        private void connectButton_Click(object sender, RoutedEventArgs e)
        {
            Listen();

            pollTimer.Start();
        }

        private void disconnectButton_Click(object sender, RoutedEventArgs e)
        {
            StopListening();
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

        private void Listen()
        {
            //modeBusClient.IPAddress = ipAddressTextBox.Text;
            //modeBusClient.Port = int.Parse(portTextBox.Text);
            modeBusClient.ConnectionTimeout = 5000;

            tRead = new Thread(new ThreadStart(Read));
            tRead.Start();

            //tWrite = new Thread(new ThreadStart(Write));
            //tWrite.Start();

            if (!modeBusClient.Connected)
            {
                try
                {
                    modeBusClient.Connect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void StopListening()
        {
            //tRead.Abort();
            //tWrite.Abort();

            modeBusClient.Disconnect();
        }

        private void Read()
        {
            int[] readInputRegisters;

            if (modeBusClient.Connected)
            {
                readInputRegisters = modeBusClient.ReadInputRegisters(0, 10);

                string[] QW = new string[10];

                for (int i = 0; i < 10; ++i)
                {
                    QW[i] = readInputRegisters[i].ToString();
                }

                //QW1TextBlock.Text = QW[0];
                //QW2TextBlock.Text = QW[1];
                //QW3TextBlock.Text = QW[2];
                //QW4TextBlock.Text = QW[3];
                //QW5TextBlock.Text = QW[4];
                //QW6TextBlock.Text = QW[5];
                //QW7TextBlock.Text = QW[6];
                //QW8TextBlock.Text = QW[7];
                //QW9TextBlock.Text = QW[8];
                //QW10TextBlock.Text = QW[9];
            }
        }

        private void Write()
        {
            if (modeBusClient.Connected)
            {
                int[] writeValues = new int[]
                {
                    //int.Parse(QW1TextBlock.Text),
                    //int.Parse(QW2TextBlock.Text),
                    //int.Parse(QW3TextBlock.Text),
                    //int.Parse(QW4TextBlock.Text),
                    //int.Parse(QW5TextBlock.Text),
                    //int.Parse(QW6TextBlock.Text),
                    //int.Parse(QW7TextBlock.Text),
                    //int.Parse(QW8TextBlock.Text),
                    //int.Parse(QW9TextBlock.Text),
                    //int.Parse(QW10TextBlock.Text),
                    1,
                    2,
                    3,
                    4,
                    5,
                    6,
                    7,
                    8,
                    9,
                    10,
                };

                modeBusClient.WriteMultipleRegisters(0, writeValues);
            }
        }

        private void AlwaysRunning()
        {
            while (true)
            {
                if (modeBusClient.Connected)
                {
                    // ToDo
                }
                else
                {
                    // ToDo
                }
            }
        }
    }
}
