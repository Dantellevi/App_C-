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
using Project_DB_Remont.Model;
using Project_DB_Remont.addElem;
using Project_DB_Remont.Edit;
using Project_DB_Remont.Result;
using System.Data.Entity;
using System.Data;

namespace Project_DB_Remont
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EFContext db;
        public string URLPhoto;
        public MainWindow()
        {
            
            InitializeComponent();
            Uri iconUri = new Uri("pack://siteoforigin:,,,/Main.ico", UriKind.RelativeOrAbsolute);
            this.Icon = new BitmapImage(iconUri);
           
            db = new EFContext();
            db.remonts.Load();
            dataGrid.ItemsSource = db.remonts.Local.ToBindingList();
            this.Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        private void addNew(object sender, RoutedEventArgs e)
        {
            try
            {
                WinAdd ADDELEM = new WinAdd();
                ADDELEM.ShowDialog();
                if (ADDELEM.DialogResult.HasValue && ADDELEM.DialogResult.Value)
                {
                    Remout Rem = new Remout();
                    Rem.description = ADDELEM.DescriptionText.Text;
                    Rem.OriginRemont = ADDELEM.Dateorigin;
                    Rem.EndRemont = ADDELEM.DateEnd;
                    Rem.Neispravnost = ADDELEM.Neisp.Text;
                    Rem.FotoNeispr = ADDELEM.ImageName;
                    Rem.directAuthors = ADDELEM.AuthorBox.Text;
                    Rem.MarkaDevices = ADDELEM.MarkaDevices.Text;
                    db.remonts.Add(Rem);
                    db.SaveChanges();
                    MessageBox.Show("Новый объект добавлен");

                }
                else
                {
                    return;

                }
            }

            catch(Exception exs)
            {
                MessageBox.Show("Ошибка !!" + exs.Message);
            }


           
            

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                WinAdd ADDELEM = new WinAdd();
                ADDELEM.ShowDialog();
                if (ADDELEM.DialogResult.HasValue && ADDELEM.DialogResult.Value)
                {
                    Remout Rem = new Remout();
                    Rem.description = ADDELEM.DescriptionText.Text;
                    Rem.OriginRemont = ADDELEM.Dateorigin;
                    Rem.EndRemont = ADDELEM.DateEnd;
                    Rem.Neispravnost = ADDELEM.Neisp.Text;
                    Rem.FotoNeispr = ADDELEM.ImageName;
                    Rem.directAuthors = ADDELEM.AuthorBox.Text;
                    Rem.MarkaDevices = ADDELEM.MarkaDevices.Text;
                    db.remonts.Add(Rem);
                    db.SaveChanges();
                    MessageBox.Show("Новый объект добавлен");

                }
                else
                {
                    return;

                }
            }
            catch(Exception exs)
            {
                MessageBox.Show("Ошибка !!" + exs.Message);
            }


           


        }

        private void deleteDb_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dataGrid.SelectedItems.Count > 0)
                {
                    for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
                    {
                        Remout Rem = dataGrid.SelectedItems[i] as Remout;

                        if (Rem != null)
                        {
                            db.remonts.Remove(Rem);
                        }
                    }

                }
                db.SaveChanges();
            }

            catch(Exception exs)
            {
                MessageBox.Show("Ошибка !!" + exs.Message);
            }


            
        }

        private void EditDb_Click(object sender, RoutedEventArgs e)
        {


            try
            {
                if (dataGrid.SelectedItems.Count > 0)
                {



                    int Id = ((Remout)dataGrid.SelectedItem).Id;

                    Remout RemEdit = db.remonts.Find(Id);

                    WinEdit EditWindow = new WinEdit();
                    EditWindow.DescriptionText.Text = RemEdit.description;
                    EditWindow.ERROR.Text = RemEdit.Neispravnost;
                    EditWindow.OriginTimeedit = RemEdit.OriginRemont;
                    EditWindow.ENDTimeedit = RemEdit.EndRemont;
                    EditWindow.AuthorBox.Text = RemEdit.directAuthors;
                    EditWindow.ImageNameedit = RemEdit.FotoNeispr;
                    EditWindow.DevicesIn.Text = RemEdit.MarkaDevices;
                    EditWindow.ShowDialog();
                    if (EditWindow.DialogResult.HasValue && EditWindow.DialogResult.Value)
                    {
                        RemEdit.description = EditWindow.DescriptionText.Text;
                        RemEdit.OriginRemont = EditWindow.OriginTimeedit;
                        RemEdit.EndRemont = EditWindow.ENDTimeedit;
                        RemEdit.Neispravnost = EditWindow.ERROR.Text;
                        RemEdit.FotoNeispr = EditWindow.ImageNameedit;
                        RemEdit.directAuthors = EditWindow.AuthorBox.Text;
                        RemEdit.MarkaDevices = EditWindow.MarkaDevices.Text;
                        db.SaveChanges();
                        dataGrid.ItemsSource = null;
                        dataGrid.ItemsSource = db.remonts.Local.ToBindingList();



                        MessageBox.Show("Объект изменен!!!");

                    }
                    else
                    {
                        return;
                    }




                }

                else
                {
                    MessageBox.Show("Ошибка выделите редактируемый элемент!!");
                }
            }
            catch(Exception exs)
            {
                MessageBox.Show("Ошибка !!" + exs.Message);
            }

            
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

            try
            {
                if (dataGrid.SelectedItems.Count > 0)
                {



                    int Id = ((Remout)dataGrid.SelectedItem).Id;

                    Remout RemEdit = db.remonts.Find(Id);

                    WinEdit EditWindow = new WinEdit();
                    EditWindow.DescriptionText.Text = RemEdit.description;
                    EditWindow.ERROR.Text = RemEdit.Neispravnost;
                    EditWindow.OriginTimeedit = RemEdit.OriginRemont;
                    EditWindow.ENDTimeedit = RemEdit.EndRemont;
                    EditWindow.AuthorBox.Text = RemEdit.directAuthors;
                    EditWindow.ImageNameedit = RemEdit.FotoNeispr;
                    EditWindow.DevicesIn.Text = RemEdit.MarkaDevices;
                    EditWindow.ShowDialog();
                    if (EditWindow.DialogResult.HasValue && EditWindow.DialogResult.Value)
                    {
                        RemEdit.description = EditWindow.DescriptionText.Text;
                        RemEdit.OriginRemont = EditWindow.OriginTimeedit;
                        RemEdit.EndRemont = EditWindow.ENDTimeedit;
                        RemEdit.Neispravnost = EditWindow.ERROR.Text;
                        RemEdit.FotoNeispr = EditWindow.ImageNameedit;
                        RemEdit.directAuthors = EditWindow.AuthorBox.Text;
                        RemEdit.MarkaDevices = EditWindow.MarkaDevices.Text;
                        db.SaveChanges();
                        dataGrid.ItemsSource = null;
                        dataGrid.ItemsSource = db.remonts.Local.ToBindingList();



                        MessageBox.Show("Объект изменен!!!");

                    }
                    else
                    {
                        return;
                    }




                }

                else
                {
                    MessageBox.Show("Ошибка выделите редактируемый элемент!!");
                }
            }
            catch(Exception exs)
            {
                MessageBox.Show("Ошибка !!"+exs.Message);
            }

           


        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {

            try
            {
                if (dataGrid.SelectedItems.Count > 0)
                {
                    for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
                    {
                        Remout Rem = dataGrid.SelectedItems[i] as Remout;

                        if (Rem != null)
                        {
                            db.remonts.Remove(Rem);
                        }
                    }

                }
                db.SaveChanges();
            }
            catch(Exception exs)
            {
                MessageBox.Show("Ошибка !!" + exs.Message);
            }
          
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {

            this.Close();
        }

        private void resultWork_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dataGrid.SelectedItems.Count > 0)
                {



                    int Id = ((Remout)dataGrid.SelectedItem).Id;

                    Remout RemRes = db.remonts.Find(Id);
                    URLPhoto = RemRes.FotoNeispr;
                    WinResult ResultWindow = new WinResult(URLPhoto);
                    ResultWindow.DescriptionTextResult.Text = RemRes.description;
                    ResultWindow.ERRORresult.Text = RemRes.Neispravnost;
                    ResultWindow.DateOrigin.Text = RemRes.OriginRemont;
                    ResultWindow.DateEND.Text = RemRes.EndRemont;
                    ResultWindow.AuthorBoxResult.Text = RemRes.directAuthors;
                    ResultWindow.ImageNameResult = URLPhoto;
                    ResultWindow.DevicesInResult.Text = RemRes.MarkaDevices;
                    ResultWindow.ShowDialog();

                }

                else
                {
                    MessageBox.Show("Ошибка, выделите редактируемый элемент!!");
                }
            }
            catch(Exception exs)
            {
                MessageBox.Show("Ошибка !!" + exs.Message);
            }
           

           

        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            try
            {
                WinAdd ADDELEM = new WinAdd();
                ADDELEM.ShowDialog();
                if (ADDELEM.DialogResult.HasValue && ADDELEM.DialogResult.Value)
                {
                    Remout Rem = new Remout();
                    Rem.description = ADDELEM.DescriptionText.Text;
                    Rem.OriginRemont = ADDELEM.Dateorigin;
                    Rem.EndRemont = ADDELEM.DateEnd;
                    Rem.Neispravnost = ADDELEM.Neisp.Text;
                    Rem.FotoNeispr = ADDELEM.ImageName;
                    Rem.directAuthors = ADDELEM.AuthorBox.Text;
                    Rem.MarkaDevices = ADDELEM.MarkaDevices.Text;
                    db.remonts.Add(Rem);
                    db.SaveChanges();
                    MessageBox.Show("Новый объект добавлен");

                }
                else
                {
                    return;

                }
            }

            catch (Exception exs)
            {
                MessageBox.Show("Ошибка !!" + exs.Message);
            }
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dataGrid.SelectedItems.Count > 0)
                {
                    for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
                    {
                        Remout Rem = dataGrid.SelectedItems[i] as Remout;

                        if (Rem != null)
                        {
                            db.remonts.Remove(Rem);
                        }
                    }

                }
                db.SaveChanges();
            }

            catch (Exception exs)
            {
                MessageBox.Show("Ошибка !!" + exs.Message);
            }

        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dataGrid.SelectedItems.Count > 0)
                {



                    int Id = ((Remout)dataGrid.SelectedItem).Id;

                    Remout RemEdit = db.remonts.Find(Id);

                    WinEdit EditWindow = new WinEdit();
                    EditWindow.DescriptionText.Text = RemEdit.description;
                    EditWindow.ERROR.Text = RemEdit.Neispravnost;
                    EditWindow.OriginTimeedit = RemEdit.OriginRemont;
                    EditWindow.ENDTimeedit = RemEdit.EndRemont;
                    EditWindow.AuthorBox.Text = RemEdit.directAuthors;
                    EditWindow.ImageNameedit = RemEdit.FotoNeispr;
                    EditWindow.DevicesIn.Text = RemEdit.MarkaDevices;
                    EditWindow.ShowDialog();
                    if (EditWindow.DialogResult.HasValue && EditWindow.DialogResult.Value)
                    {
                        RemEdit.description = EditWindow.DescriptionText.Text;
                        RemEdit.OriginRemont = EditWindow.OriginTimeedit;
                        RemEdit.EndRemont = EditWindow.ENDTimeedit;
                        RemEdit.Neispravnost = EditWindow.ERROR.Text;
                        RemEdit.FotoNeispr = EditWindow.ImageNameedit;
                        RemEdit.directAuthors = EditWindow.AuthorBox.Text;
                        RemEdit.MarkaDevices = EditWindow.MarkaDevices.Text;
                        db.SaveChanges();
                        dataGrid.ItemsSource = null;
                        dataGrid.ItemsSource = db.remonts.Local.ToBindingList();



                        MessageBox.Show("Объект изменен!!!");

                    }
                    else
                    {
                        return;
                    }




                }

                else
                {
                    MessageBox.Show("Ошибка выделите редактируемый элемент!!");
                }
            }
            catch (Exception exs)
            {
                MessageBox.Show("Ошибка !!" + exs.Message);
            }
        }

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }
    }
}
