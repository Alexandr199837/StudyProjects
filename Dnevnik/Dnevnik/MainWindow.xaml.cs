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

namespace Dnevnik
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Person[] persons = new Person[10];
            persons[0] = new Person() { Name = "1", Experience = { } };
            persons[1] = new Person() { Name = "2" };
            persons[2] = new Person() { Name = "3" };
            persons[3] = new Person() { Name = "4" };
            persons[4] = new Person() { Name = "5" };
            persons[5] = new Person() { Name = "6" };
            persons[6] = new Person() { Name = "7" };
            persons[7] = new Person() { Name = "8" };
            persons[8] = new Person() { Name = "9" };
            persons[9] = new Person() { Name = "10" };
            dgMain.ItemsSource = persons;
        }

        private void dgMain_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            if (e.Column.DisplayIndex != 1)
            {
                e.Cancel = true;
            }
        }
    }
}