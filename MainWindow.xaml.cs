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

namespace SQLite_Homework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataAccess.IntitializeDatabase();
            
            DataAccess.GetData();
        }

        private void btnshow_Click(object sender, RoutedEventArgs e)
        {
            string Strdata = "";
            foreach(string data in DataAccess.GetData())
            {
                Strdata = Strdata + data;
 
            }
            MessageBox.Show(Strdata);

        }

        private void btnadd_Click(object sender, RoutedEventArgs e)
        {
            DataAccess.AddData(txt_uid.Text , txt_name.Text , txt_lastname.Text , txt_email.Text);
            txt_uid.Clear();
            txt_name.Clear();
            txt_lastname.Clear();
            txt_email.Clear();
        }
    }
}
