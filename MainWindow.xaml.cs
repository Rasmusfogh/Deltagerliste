using System;
using System.IO;
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

namespace Deltagerliste
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var fs = new FileStream(@"C:\Users\Rasmus\Desktop\deltagerliste.csv", FileMode.Open, FileAccess.Read);
            var sr = new StreamReader(fs, Encoding.Default);
            List<DataStructure> dl = new List<DataStructure>();
            char[] separators = { ';' };
            string nextLine = "";
            while (!sr.EndOfStream)
            {
                string[] tokens;
                var ds = new DataStructure();
                var str = sr.ReadLine();
                tokens = str.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                ds.Lastname = tokens[0];
                ds.Firstname = tokens[1];
                ds.AuNumber = tokens[2];
                ds.Student = tokens[3];
                nextLine = $"{tokens[1],-20} {tokens[0],-20} {tokens[3],-12} {tokens[2],20}";
                dl.Add(ds);
            }
            listboxdl.ItemsSource = dl;
        }
        public class DataStructure
        {
            public string Firstname { get; set; }
            public string Lastname { get; set; }
            public string AuNumber { get; set; }
            public string Student { get; set; }
        }
    }
}




