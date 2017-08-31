using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для SettingsRessive_Transmit.xaml
    /// </summary>
    public partial class SettingsRessive_Transmit : Window
    {

        protected internal int flagControl=0;
        public SettingsRessive_Transmit()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Tr_Ress_On_Checked(object sender, RoutedEventArgs e)
        {
            flagControl = 1;//включен и прием и передача
        }

        private void Tr_Ress_OFF_Checked(object sender, RoutedEventArgs e)
        {
            flagControl = 0;//выключен и прием и передача
        }

        private void Tr_On_Checked(object sender, RoutedEventArgs e)
        {
            flagControl = 2;//включена  передача
        }

        private void Ress_ON_Checked(object sender, RoutedEventArgs e)
        {
            flagControl = 3;//включен прием 
        }

        private void Tr_OFF_Checked(object sender, RoutedEventArgs e)
        {
            flagControl = 4;//выключена  передача
        }

        private void Ress_OFF_Checked(object sender, RoutedEventArgs e)
        {
            flagControl = 5;//выключен  прием 
        }
    }
}
