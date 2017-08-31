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

namespace Project_DB_Remont.Result
{
    /// <summary>
    /// Логика взаимодействия для ViewPhoto.xaml
    /// </summary>
    public partial class ViewPhoto : Window
    {
        protected internal string SorceImage;
        public ViewPhoto(string sstr)
        {
            SorceImage = sstr;
            InitializeComponent();
            Uri iconUri = new Uri("pack://siteoforigin:,,,/sequelpro.ico", UriKind.RelativeOrAbsolute);
            this.Icon = new BitmapImage(iconUri);
            PhotoImage.Source = new BitmapImage(new Uri(SorceImage));
           
        }

        private void printPhoto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PrintDialog printPhoto = new PrintDialog();

                if (printPhoto.ShowDialog() == true)
                {
                    gridd.Visibility = Visibility.Hidden;
                   
                    printPhoto.PrintVisual(PhotosN, "Расчечатать изображение!!!");
                    gridd.Visibility = Visibility.Visible;
                }
            }

            catch(Exception exs)
            {
                MessageBox.Show("Ошибка печати !!!" + exs.Message + "попробуйте еще раз");

            }


            
        }

        private void Out_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
