using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DuplicateFinderApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FolderBrowserDialog _firstDirectory;
        FolderBrowserDialog _secondDirectory;
        List<string> _firstNames;
        List<string> _secondNames;
        List<string> _firstPath;
        List<string> _secondPath;
        public MainWindow()
        {
            InitializeComponent();
            _firstDirectory = new FolderBrowserDialog();
            _secondDirectory = new FolderBrowserDialog();
            _firstNames = new List<string>();
            _secondNames = new List<string>();
            _firstPath = new List<string>();
            _secondPath = new List<string>();
            SetText();
        }

        private void FirstDirectory_Click(object sender, RoutedEventArgs e)
        {
            GetFileNames(_firstDirectory, _firstNames, _firstPath);
        }

        void GetFileNames(FolderBrowserDialog folderBrowserDialog, List<string> list, List<string> path)
        {
            folderBrowserDialog.ShowDialog();
            if (folderBrowserDialog.SelectedPath != null)
            {
                string[] names = Directory.GetFiles(folderBrowserDialog.SelectedPath);
                list.Clear();
                foreach (string name in names)
                {
                    path.Add(name); //добавляем в лист полный путь
                    list.Add(GetFileName(name));    //добавляем в другой лист только имя файла
                }
            }
        }

        void SetText()
        {
            Delete.Content = LanguageRes.DeleteButton;
            FirstDirectory.Content = LanguageRes.FirstButton;
            SecondDirectory.Content = LanguageRes.SecondButton;
            Search.Content = LanguageRes.FindButton;
        }

        string GetFileName(string path)
        {
            string fileName = path;
            int index = path.LastIndexOf("\\");
            if(index != -1)
            {
                fileName = path.Remove(0, index + 1);
            }
            return fileName;
        }

        private void SecondDirectory_Click(object sender, RoutedEventArgs e)
        {
            GetFileNames(_secondDirectory, _secondNames, _secondPath);
        }

        void SearchDublicate()
        {
            FileList.Items.Clear();
            foreach(string fileName in _firstNames)
            {
                if(_secondNames.Find(x => x == fileName) == fileName)
                {
                    int _firstindex = _firstNames.FindIndex(x => x == fileName);
                    int _secondindex = _secondNames.FindIndex(x => x == fileName);
                    long _firstSize = new FileInfo(_firstPath[_firstindex]).Length;
                    long _secondSize = new FileInfo(_secondPath[_secondindex]).Length;
                    
                    if(_firstSize == _secondSize)
                        FileList.Items.Add(fileName);
                }
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            SearchDublicate();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            foreach (string fileName in FileList.Items)
            {
               int index = _secondNames.FindIndex(x => x == fileName);
                File.Delete(_secondPath[index]);
            }
            System.Windows.MessageBox.Show("Удалено!");
            FileList.Items.Clear();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(LanguageChangeCB.SelectedIndex == 0)
            {
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ru");
            }
            else
            {
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
            }
            SetText();
        }
    }
}
