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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO.Ports;
using System.Threading;
using WpfApplication1.About;
using WpfApplication1.Services;
namespace WpfApplication1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private delegate void setTextDeleg(string text);
        //--------------Настройки порта-------------------------
        private string M_portNumber;
        private string M_SpeedBoud;
        private string M_SizeBite;
        private string M_ParitetBit;
        private string M_StopBits;
        //-------------------------------------------------------
        //----------Флаг управления приема/передачи--------------
        private int flagTrRes=0;
        //-------------------------------------------------------
        //------------------------флаг управления положения кнопки------------------------------
        private int count_connect=1;
        //--------------------------------------------------------------------------------------
        //-------------------------флаг управления конвертации----------------------------------
        private bool flConvertTransmit = false;
        private bool flConvertRessive = false;
        //----------------------------------------------------------------------------------
        public MainWindow()
        {
            InitializeComponent();
            FildRessiveDataTextBox.Clear();
            FildTransmitDataTextBox.Clear();
            MessageTransmitTexbox.Clear();
            FildCodeTransmitDataTextBox.Clear();
            FildCodeDataTextBox.Clear();
        }

        SerialPort S_port = new SerialPort();

        #region Connection_Method_Com_port
        private void Connections_and_Settings()
        {
            bool error = false;
            if(M_portNumber!="" && M_SpeedBoud!="" && M_SizeBite!="" && M_ParitetBit!="" && M_StopBits!="")
            {
                S_port.PortName = M_portNumber;
                S_port.BaudRate = int.Parse(M_SpeedBoud);
                S_port.Parity = (Parity)Enum.Parse(typeof(Parity), M_ParitetBit);
                S_port.DataBits = int.Parse(M_SizeBite);
                S_port.StopBits = (StopBits)Enum.Parse(typeof(StopBits), M_StopBits);



                try
                {
                    S_port.Open();
                }
                catch(UnauthorizedAccessException)
                {
                    error = true;
                }
                catch(System.IO.IOException)
                {
                    error = true;
                }
                catch(ArgumentException)
                {
                    error = true;
                }
                if(error)
                {
                    MessageBox.Show("Ошибка!! Проверте правильность ввода данных!");
                }
                else
                {
                    MessageBox.Show("Настройки приняты!!!Соединение с портом....");
                }
            }
        }
        #endregion



        #region Click_Connection
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion


        #region Click_NoneConnection
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }
        #endregion



        #region Exit_Programm
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Click_SettingsConnection
        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                SettingsWindowConnections SetConnect = new SettingsWindowConnections();
                SetConnect.ShowDialog();
                if (SetConnect.DialogResult.HasValue && SetConnect.DialogResult.Value)
                {
                    M_portNumber = SetConnect.portNumber;
                    M_SpeedBoud = SetConnect.SpeedBoud;
                    M_SizeBite = SetConnect.SizeBite;
                    M_ParitetBit = SetConnect.ParitetBit;
                    M_StopBits = SetConnect.StopBits;

                }
                else
                {
                    return;
                }
            }
            catch(Exception ems)
            {
                MessageBox.Show("Ошибка!!! " + ems.Message);
            }
            
           

        }
        #endregion

        #region click_settingsInput_output
        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Click_SettingsTransmit_Ressive
        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            try
            {
                SettingsRessive_Transmit S_r_t = new SettingsRessive_Transmit();
                S_r_t.ShowDialog();
                if (S_r_t.DialogResult.HasValue && S_r_t.DialogResult.Value)
                {
                    flagTrRes = S_r_t.flagControl;

                    switch(flagTrRes)
                    {
                        case 0:
                            MessageBox.Show("Выключен и прием и передача данных!!!");
                            FildTransmitDataTextBox.IsEnabled = false;
                            FildRessiveDataTextBox.IsEnabled = false;
                            break;
                        case 1:
                            MessageBox.Show("Включен и прием и передача данных!!!");
                            FildTransmitDataTextBox.IsEnabled = true;
                            FildRessiveDataTextBox.IsEnabled = true;
                            break;
                        case 2:
                            MessageBox.Show("Включена передача  данных!!!");
                            FildTransmitDataTextBox.IsEnabled = true;
                            FildRessiveDataTextBox.IsEnabled = false;
                            break;
                        case 3:
                            MessageBox.Show("Включен прием данных!!!");
                            FildRessiveDataTextBox.IsEnabled = true;
                            FildTransmitDataTextBox.IsEnabled = false;
                            break;
                        case 4:
                            MessageBox.Show("Отключена прием данных!!!");
                            FildTransmitDataTextBox.IsEnabled = true;
                            FildRessiveDataTextBox.IsEnabled = false;
                            break;

                        case 5:
                            MessageBox.Show("Прием передача больших данных!");
                            break;
                    }
                }
                else
                {
                    return;
                }
            }
            catch(Exception es)
            {
                MessageBox.Show("Ошибка!!! " + es.Message);
            }
        }

        #endregion

        #region Click_About
        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            WindowAbout About = new WindowAbout();
            About.Show();
        }

        #endregion

        #region EnableConnection
        private void btnConnections_Click(object sender, RoutedEventArgs e)
        {
            count_connect++;
            if(count_connect%2!=0)
            {
                btnConnections.Content = "Нет соединения(разорвано)";
                Port_disconnect();



            }
            else if(count_connect%2==0)
            {
                btnConnections.Content = "Соединение установлено!!!";
                Connections_and_Settings();
                S_port.DataReceived += S_port_DataReceived;
                ButtanTransmit.IsEnabled = true;

            }


        }



        #endregion


        #region Disconnect_Com

        private void Port_disconnect()
        {
            try
            {
                MessageBox.Show("Закрытие соединения......");
                S_port.Close();
            }
            catch
            {

            }
        }

        #endregion



        #region Ressive_Data
        private void S_port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if(flagTrRes==1 || flagTrRes==3)
            {
                Thread.Sleep(50);
                string data = S_port.ReadLine();
                //--------------------------------------
                if (flConvertRessive == false)
                {
                    ConvertBinaryData(data, true);
                }
                else if (flConvertRessive == true)
                {
                    ConvertHexData(data, true);
                }
                //-------------------------------------
                Dispatcher.BeginInvoke(new setTextDeleg(Rceive_Data), new object[] { data });
            }
            else
            {
                MessageBox.Show("Прием отключен !!!Поменяйте настройки для включения режима -Прием!!");
            }
           

        }

        private void Rceive_Data(string Data)
        {
            FildRessiveDataTextBox.Text += ">>" + Data.Trim() + Environment.NewLine;

        }


        #endregion



        #region Transmit_Data
        private void ButtanTransmit_Click(object sender, RoutedEventArgs e)
        {
            if(flagTrRes==1|| flagTrRes==2)
            {
                if (count_connect % 2 != 0)
                {

                    ButtanTransmit.IsEnabled = false;


                }
                else if (count_connect % 2 == 0)
                {
                    ButtanTransmit.IsEnabled = true;

                    if (flConvertTransmit == false)
                    {
                        ConvertBinaryData(MessageTransmitTexbox.Text, false);
                    }
                    else if (flConvertTransmit == true)
                    {
                        ConvertHexData(MessageTransmitTexbox.Text, false);
                    }
                    Transmit_Data_Message();

                    


                }
            }
            else
            {
                MessageBox.Show("Передача данных отключена измените настройки!!!");
            }

           
        }

        private void Transmit_Data_Message()
        {
            try
            {
                string Text_Transmit;
                Text_Transmit = MessageTransmitTexbox.Text;
                S_port.WriteLine(String.Format("{0}", Text_Transmit));
                MessageTransmitTexbox.Clear();
                FildTransmitDataTextBox.Text += ">>" + Text_Transmit + " " + Environment.NewLine;

            }
            catch(Exception es)
            {
                MessageBox.Show("Ошибка!!!" + es.Message);
            }
        }


        #endregion

        #region parse_Binary_or_Hex

        private void CodeBinaryTransmit_Checked(object sender, RoutedEventArgs e)
        {
            flConvertTransmit = false;
        }

        private void CodeHexTransmit_Checked(object sender, RoutedEventArgs e)
        {
            flConvertTransmit = true;
        }

        private void CodeBinaryRessive_Checked(object sender, RoutedEventArgs e)
        {
            flConvertRessive = false;
        }

        private void CodeHexRessive_Checked(object sender, RoutedEventArgs e)
        {
            flConvertRessive = true;
        }


        private void ConvertBinaryData(string Message,bool flagRsTsm)
        {
            
            
            //если флаг true работаем с приемом данных
            if (flagRsTsm==true)
            {
                FildCodeDataTextBox.Text += ">>";
               for (int i=0;i<Message.Length;i++)
                {
                    FildCodeDataTextBox.Text += Convert.ToString(Message[i], 2)+" ";
                }
                FildCodeDataTextBox.Text += Environment.NewLine;

            }
            //иначе работаем с передачей
            else
            {
                FildCodeTransmitDataTextBox.Text += ">>";
                for (int i = 0; i < Message.Length; i++)
                {
                    FildCodeTransmitDataTextBox.Text += Convert.ToString(Message[i], 2) + " ";
                }
                FildCodeTransmitDataTextBox.Text += Environment.NewLine;
            }
            
            

        }


        private void ConvertHexData(string Message, bool flagRsTsm)
        {
            //если флаг true работаем с приемом данных
            if (flagRsTsm == true)
            {
                FildCodeDataTextBox.Text += ">>";
                for (int i = 0; i < Message.Length; i++)
                {
                    FildCodeDataTextBox.Text += Convert.ToString(Message[i], 16) + " ";
                }
                FildCodeDataTextBox.Text += Environment.NewLine;

            }
            //иначе работаем с передачей
            else
            {
                FildCodeTransmitDataTextBox.Text += ">>";
                for (int i = 0; i < Message.Length; i++)
                {
                    FildCodeTransmitDataTextBox.Text += Convert.ToString(Message[i], 16) + " ";
                }
                FildCodeTransmitDataTextBox.Text += Environment.NewLine;
            }
        }


        #endregion
    }
}
