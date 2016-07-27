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

namespace File_in_File_Hider.Windows
{
    /// <summary>
    /// Interaktionslogik für LanguageWindow.xaml
    /// </summary>
    public delegate void LanguageChangedEventHandler(object sender, EventArgs e);
    public partial class LanguageWindow : Window
    {
        public event LanguageChangedEventHandler LanguageChanged;
        public LanguageWindow()
        {
            InitializeComponent();
            switch (System.Threading.Thread.CurrentThread.CurrentUICulture.ToString()) // Checks the CurrentUICulture
            {
                case "en":
                    lstLanguages.SelectedIndex = 0; // Sets lstLanguage.SelectedIndex
                    btnApply.IsEnabled = false; // Disables the HideWindow
                    break;

                case "de":
                    lstLanguages.SelectedIndex = 1; // Sets lstLanguage.SelectedIndex
                    btnApply.IsEnabled = false; // Disables the HideWindow
                    break;

                case "es":
                    lstLanguages.SelectedIndex = 2; // Sets lstLanguage.SelectedIndex
                    btnApply.IsEnabled = false; // Disables the HideWindow
                    break;

                case "zh-Hans":
                    lstLanguages.SelectedIndex = 3; // Sets lstLanguage.SelectedIndex
                    btnApply.IsEnabled = false; // Disables the HideWindow
                    break;

                case "fr":
                    lstLanguages.SelectedIndex = 4; // Sets lstLanguage.SelectedIndex
                    btnApply.IsEnabled = false; // Disables the HideWindow
                    break;

                case "ja":
                    lstLanguages.SelectedIndex = 5; // Sets lstLanguage.SelectedIndex
                    btnApply.IsEnabled = false; // Disables the HideWindow
                    break;

                default:
                    lstLanguages.SelectedIndex = 0; // Sets lstLanguage.SelectedIndex
                    btnApply.IsEnabled = false; // Disables the HideWindow
                    break;
            }
        }

        private void btnAbort_Click(object sender, RoutedEventArgs e)
        {
            this.Hide(); // Hides the Window
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            btnApply.IsEnabled = false; // Disables the HideWindow
            txtRestartWarning.Visibility = Visibility.Visible; // Makes the RestartWarning visible
                switch (lstLanguages.SelectedIndex) // Checks Selected Language
                {
                    case 0:
                        System.Threading.Thread.CurrentThread.CurrentUICulture =
                            new System.Globalization.CultureInfo("en"); // Sets UICulture
                        Properties.Settings.Default.Language = "en"; // Sets the Language Setting
                        Properties.Settings.Default.Save(); // Saves the Settings
                        break;

                    case 1:
                        System.Threading.Thread.CurrentThread.CurrentUICulture =
                            new System.Globalization.CultureInfo("de"); // Sets UICulture
                        Properties.Settings.Default.Language = "de"; // Sets the Language Setting
                        Properties.Settings.Default.Save(); // Saves the Settings
                        break;

                    case 2:
                        System.Threading.Thread.CurrentThread.CurrentUICulture =
                            new System.Globalization.CultureInfo("es");// Sets UICulture
                        Properties.Settings.Default.Language = "es"; // Sets the Language Setting
                        Properties.Settings.Default.Save(); // Saves the Settings
                        break;

                    case 3:
                        System.Threading.Thread.CurrentThread.CurrentUICulture =
                            new System.Globalization.CultureInfo("zh-Hans"); // Sets UICulture
                        Properties.Settings.Default.Language = "zh-Hans"; // Sets the Language Setting
                        Properties.Settings.Default.Save(); // Saves the Settings
                        break;

                    case 4:
                        System.Threading.Thread.CurrentThread.CurrentUICulture =
                            new System.Globalization.CultureInfo("fr"); // Sets UICulture
                        Properties.Settings.Default.Language = "fr"; // Sets the Language Setting
                        Properties.Settings.Default.Save();// Saves the Settings
                        break;

                    case 5:
                        System.Threading.Thread.CurrentThread.CurrentUICulture =
                            new System.Globalization.CultureInfo("ja"); // Sets UICulture
                        Properties.Settings.Default.Language = "ja"; // Sets the Language Setting
                        Properties.Settings.Default.Save(); // Saves the Settings
                        break;
                }
            LanguageChanged(sender, e); // Sends the LanguageChanged Event
        }

        private void lstLanguages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnApply.IsEnabled = true; // Enables btnApply
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            switch (lstLanguages.SelectedIndex) // Makes the same as Apply
            {
                case 0:
                    System.Threading.Thread.CurrentThread.CurrentUICulture =
                        new System.Globalization.CultureInfo("en");
                    Properties.Settings.Default.Language = "en";
                    Properties.Settings.Default.Save();
                    break;

                case 1:
                    System.Threading.Thread.CurrentThread.CurrentUICulture =
                        new System.Globalization.CultureInfo("de");
                    Properties.Settings.Default.Language = "de";
                    Properties.Settings.Default.Save();
                    break;

                case 2:
                    System.Threading.Thread.CurrentThread.CurrentUICulture =
                        new System.Globalization.CultureInfo("es");
                    Properties.Settings.Default.Language = "es";
                    Properties.Settings.Default.Save();
                    break;

                case 3:
                    System.Threading.Thread.CurrentThread.CurrentUICulture =
                        new System.Globalization.CultureInfo("zh-Hans");
                    Properties.Settings.Default.Language = "zh-Hans";
                    Properties.Settings.Default.Save();
                    break;

                case 4:
                    System.Threading.Thread.CurrentThread.CurrentUICulture =
                        new System.Globalization.CultureInfo("fr");
                    Properties.Settings.Default.Language = "fr";
                    Properties.Settings.Default.Save();
                    break;

                case 5:
                    System.Threading.Thread.CurrentThread.CurrentUICulture =
                        new System.Globalization.CultureInfo("ja");
                    Properties.Settings.Default.Language = "ja";
                    Properties.Settings.Default.Save();
                    break;
            }
            LanguageChanged(sender, e); // Sends LanguageChanged Event
            this.Hide(); // Hides the Window
        }
    }
}
