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

namespace RegistrationFormLocalize
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetText();
            Russian.IsChecked = true;
        }

        private void SetText()
        {
            UserRegistration.Content = LanguageRes.UserRegLabel;
            Login.Content = LanguageRes.LoginLabel;
            SetLogin.Text = LanguageRes.SetLoginTextBox;
            Password.Content = LanguageRes.PasswordLabel;
            SetPassword.Text = LanguageRes.SetPasswordTextBox;
            RepeatPassword.Content = LanguageRes.RepeatPasswordLabel;
            SetPassword1.Text = LanguageRes.SetPasswordTextBox;
            LogIn.Content = LanguageRes.LogInButton;
            ChooseLanguage.Content = LanguageRes.ChooseLanguageLabel;
            Russian.Content = LanguageRes.RussianRadioButton;
            English.Content = LanguageRes.EnglishRadioButton;
        }

        private void Russian_Checked(object sender, RoutedEventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ru");
            SetText();
        }

        private void English_Checked(object sender, RoutedEventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
            SetText();
        }
    }
}
