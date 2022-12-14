using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace LocalizeApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Указываем локализацию для программы
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("fr");
            OKBtn.Content = Strings.OkButton;
            CancelBtn.Content = Strings.CancelButton;
            UpdateText();
        }

        void UpdateText()
        {
            OKBtn.Content = Strings.OkButton;
            CancelBtn.Content = Strings.CancelButton;
        }

        private void OKBtn_Click(object sender, RoutedEventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ru");
            UpdateText();
        }
    }
}
