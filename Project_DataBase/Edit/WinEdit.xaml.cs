using Microsoft.Win32;
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

namespace Project_DB_Remont.Edit
{
    /// <summary>
    /// Логика взаимодействия для WinEdit.xaml
    /// </summary>
    public partial class WinEdit : Window
    {

        public string OriginTimeedit;
        public string ENDTimeedit;
        public string ImageNameedit;

        public WinEdit()
        {
            InitializeComponent();
            Uri iconUri = new Uri("pack://siteoforigin:,,,/Edit.ico", UriKind.RelativeOrAbsolute);
            this.Icon = new BitmapImage(iconUri);
        }

        private void OriginWorkDate_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? Dateorigin = OriginWorkDate.SelectedDate;
            OriginTimeedit = Dateorigin.Value.Date.ToShortDateString();
        }

        private void EndWorks_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? DateEnd = EndWorks.SelectedDate;
            ENDTimeedit = DateEnd.Value.Date.ToShortDateString();
        }

        private void RefPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog myDialog = new OpenFileDialog();
            myDialog.Filter = "Картинки(*.JPG;*.GIF)|*.JPG;*.GIF" + "|Все файлы (*.*)|*.* ";
            myDialog.CheckFileExists = true;
            myDialog.Multiselect = true;
            if (myDialog.ShowDialog() == true)
            {
                ImageNameedit = myDialog.FileName;
            }


        }

        private void OKEY_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
    }
}
