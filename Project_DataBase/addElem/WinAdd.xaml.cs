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
using Microsoft.Win32;
namespace Project_DB_Remont.addElem
{
    /// <summary>
    /// Логика взаимодействия для WinAdd.xaml
    /// </summary>
    public partial class WinAdd : Window
    {
        public string ImageName;
        public string Dateorigin;
        public string DateEnd;
        public WinAdd()
        {
            InitializeComponent();
            Uri iconUri = new Uri("pack://siteoforigin:,,,/Excel_course.ico", UriKind.RelativeOrAbsolute);
            this.Icon = new BitmapImage(iconUri);
        }

        private void EMage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog myDialog = new OpenFileDialog();
            myDialog.Filter = "Картинки(*.JPG;*.GIF)|*.JPG;*.GIF" + "|Все файлы (*.*)|*.* ";
            myDialog.CheckFileExists = true;
            myDialog.Multiselect = true;
            if(myDialog.ShowDialog()==true)
            {
                ImageName = myDialog.FileName;
            }
        }

        private void OriginSelectDate(object sender, SelectionChangedEventArgs e)
        {
            DateTime? selectedDateOrigin = OriginWorkDate.SelectedDate;
            Dateorigin = selectedDateOrigin.Value.Date.ToShortDateString();

        }

        private void EndDateSelect(object sender, SelectionChangedEventArgs e)
        {
            DateTime? selectedDateEnd = EndWorks.SelectedDate;
            DateEnd = selectedDateEnd.Value.Date.ToShortDateString();
        }

        private void resDialog(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
    }
}
