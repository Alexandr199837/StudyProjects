using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Linq;
using sharpPDF;
using sharpPDF.Enumerators;
using WpfApp2;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;


namespace WpfApplication5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Объявление коллекции.
        /// </summary>
        public ObservableCollection<Dnevnik> katalog = new ObservableCollection<Dnevnik>();

        public MainWindow()
        {
            InitializeComponent();



            if (File.Exists("katalog.xml")) ///создание файла XML, необходимого при сериализации и десериализации.
            {
                System.Xml.Serialization.XmlSerializer x =
                    new System.Xml.Serialization.XmlSerializer(katalog.GetType());

                using (FileStream fs = new FileStream("katalog.xml", FileMode.OpenOrCreate))
                {
                    katalog = (ObservableCollection<Dnevnik>)x.Deserialize(fs);
                    DataGrid1.ItemsSource = katalog;
                }
            }

        }
        /// <summary>
        /// Метод, объявляющий кнопку добавления строк.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAdd(object sender, RoutedEventArgs e)
        {
            katalog.Add(new Dnevnik() { Number = " ", Target = " ", Chislo = " " });
            DataGrid1.ItemsSource = katalog;

            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(katalog.GetType());
            using (FileStream fs = new FileStream("katalog.xml", FileMode.OpenOrCreate))
            {
                x.Serialize(fs, katalog);
            }
        }

        /// <summary>
        /// Метод, объявляющий кнопку очистки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            katalog.Clear();

        }
        /// <summary>
        /// Метод, объявляющий кнопку очистки объекта.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            katalog.Remove(DataGrid1.SelectedItem as Dnevnik);
        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string text1 = Picker1.Text;
            string text2 = Picker2.Text;
            string[] delitel = { ".", "/" };
            string[] wordDate1 = text1.Split(delitel, StringSplitOptions.RemoveEmptyEntries);
            string[] wordDate2 = text2.Split(delitel, StringSplitOptions.RemoveEmptyEntries);

            string text = "";
            XmlTextReader reader = new XmlTextReader("katalog.xml");
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: 
                        text = text + "<" + reader.Name + ">";
                        break;
                    case XmlNodeType.Text: 
                        text = text + reader.Value;
                        break;
                    case XmlNodeType.EndElement: 
                        text = text + "</" + reader.Name + ">";
                        break;
                }
            }

            string[] separator = { "<", ">", " " };
            string[] word = text.Split(separator, StringSplitOptions.RemoveEmptyEntries);



            int i = 0;
            pdfDocument myDoc = new pdfDocument("TUTORIAL", "ME");
            string newText = "";
            while (i < word.Length)
            {

                int j = i + 1;

                if (word[i] == "Target")
                {
                    while (word[j] != "/Target")
                    {
                        newText = newText + word[j] + " ";
                        j = j + 1;
                    }
                    newText = newText + ";   ";
                }

                if (word[i] == "IsDone")
                {
                    while (word[j] != "/IsDone")
                    {
                        newText = newText + word[j] + " ";
                        j = j + 1;
                    }
                    newText = newText + ";   ";
                }

                if (word[i] == "myDate")
                {
                    string[] currentDate = word[i + 1].Split(delitel, StringSplitOptions.RemoveEmptyEntries);
                    if (Convert.ToInt32(currentDate[2]) >= Convert.ToInt32(wordDate1[2]) && Convert.ToInt32(currentDate[2]) <= Convert.ToInt32(wordDate2[2]))
                    {
                        if (Convert.ToInt32(currentDate[0]) >= Convert.ToInt32(wordDate1[1]) && Convert.ToInt32(currentDate[0]) <= Convert.ToInt32(wordDate2[1]))
                        {
                            if (Convert.ToInt32(currentDate[1]) >= Convert.ToInt32(wordDate1[0]) && Convert.ToInt32(currentDate[1]) <= Convert.ToInt32(wordDate2[0]))
                            {
                                while (word[j] != "/myDate")
                                {
                                    newText = newText + word[j] + " ";
                                    j = j + 1;
                                }
                                newText = newText + ".";/// Для создания pdf-файла, сначала необходимо сохранить табличные данные, для этого добавив один раз пустую строку.
                                pdfPage myPage = myDoc.addPage();
                                myPage.addText(newText, 20, 700, myDoc.getFontReference(predefinedFont.csCourier), 14);
                                myDoc.createPDF(@"Dairy.pdf");
                                myPage = null;
                                newText = "";
                            }
                            else { newText = ""; }
                        }
                        else { newText = ""; }
                    }
                    else { newText = ""; }

                }
                i++;
            }
            myDoc = null;
        }
    }
}
    




        
    

        

    

    

    /// <summary>
    /// Класс для инициализации столбцов.
    /// </summary>
    public class Dnevnik
    {
        public string Number { get; set; }
        public string Target { get; set; }
        public string Chislo { get; set; }
        public string Date { get; set; }
        public bool IsDone { get; set; }
        public string myDate { get; set; }
            
    }
  
