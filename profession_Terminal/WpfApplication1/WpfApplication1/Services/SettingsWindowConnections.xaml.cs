using System;
using System.Collections.Generic;
using System.IO.Ports;
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
using System.Windows.Shapes;

namespace WpfApplication1.Services
{
    /// <summary>
    /// Логика взаимодействия для SettingsWindowConnections.xaml
    /// </summary>
    public partial class SettingsWindowConnections : Window
    {

        protected internal string portNumber;
        protected internal string SpeedBoud;
        protected internal string SizeBite;
        protected internal string ParitetBit;
        protected internal string StopBits;


        public SettingsWindowConnections()
        {
            InitializeComponent();

            string[] portNames = SerialPort.GetPortNames();
            foreach(var item in portNames)
            {
                ListPortComboBox.Items.Add(item);
            }
        }


        


        private void buttonOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void buttonOCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ListSpeedComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem Sp = ((sender as ComboBox).SelectedItem as ComboBoxItem);
            SpeedBoud = Sp.Content.ToString();
        }

        private void ListComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem Size = ((sender as ComboBox).SelectedItem as ComboBoxItem);
            SizeBite = Size.Content.ToString();
        }

        private void ListParitetComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem Pt = ((sender as ComboBox).SelectedItem as ComboBoxItem);
            ParitetBit = Pt.Content.ToString();
        }

        private void ListStopBitsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem Stop = ((sender as ComboBox).SelectedItem as ComboBoxItem);
            StopBits = Stop.Content.ToString();
        }

        private void ListPortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            portNumber = (ListPortComboBox.SelectedValue).ToString();
        }
    }
}
