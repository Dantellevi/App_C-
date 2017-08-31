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
    /// Логика взаимодействия для WinResult.xaml
    /// </summary>
    public partial class WinResult : Window
    {

       public string ImageNameResult;
        public WinResult(string str)
        {
            ImageNameResult = str;
           
            InitializeComponent();
            Uri iconUri = new Uri("pack://siteoforigin:,,,/addWin.ico", UriKind.RelativeOrAbsolute);
            this.Icon = new BitmapImage(iconUri);
        }

        private void OutWindows_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string Resstring = " ";
                Resstring = string.Format("  Описание:" + DescriptionTextResult.Text + "\n____________________________\n\n   Дата начала работ:" + DateOrigin.Text + "\n____________________________\n\n   Дата окончания работ:" + DateEND.Text + "\n   Неисправность: " + ERRORresult.Text + "\n____________________________\n\n   Выполнил(-и): " + AuthorBoxResult.Text + "\n____________________________\n\n   Оборудование:" + DevicesInResult.Text);
                //1 вариант через отдельные вызовы ----2 вариант все запихнуть в массив строк и расчечатать.....
                PrintDialog print = new PrintDialog();

                if (print.ShowDialog() == true)
                {
                    //----------------печать--------------------

                    Run desr = new Run(Resstring);
                    TextBlock visualdesc = new TextBlock();
                    visualdesc.Inlines.Add(desr);
                    visualdesc.Margin = new Thickness(5);
                    //visualdesc.TextWrapping = TextWrapping.Wrap;
                    visualdesc.LayoutTransform = new ScaleTransform(3, 3);
                    Size pageSize = new Size(print.PrintableAreaWidth, print.PrintableAreaHeight);
                    visualdesc.Measure(pageSize);
                    visualdesc.Arrange(new Rect(0, 0, pageSize.Width, pageSize.Height));

                    // Напечатать элемент
                    print.PrintVisual(visualdesc, "Распечатываем текст");
                }
            }

            catch(Exception exs)
            {
                MessageBox.Show("Ошибка попробуйте еще раз, попробуйте еще раз!!"+exs.Message);
            }

            

                
           

        }

        private void ViewsPhotoResult_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ViewPhoto poto = new ViewPhoto(ImageNameResult);
                poto.ShowDialog();
            }

            catch(Exception exs)
            {
                MessageBox.Show("Ошибка открытия формы, попробуйте еще раз!!"+exs.Message);
            }
            
        }
    }
}
