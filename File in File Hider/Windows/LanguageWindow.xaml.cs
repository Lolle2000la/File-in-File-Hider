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
            switch (System.Threading.Thread.CurrentThread.CurrentUICulture.ToString())
            {
                case "en":
                    lstLanguages.SelectedIndex = 0;
                    break;

                case "de":
                    lstLanguages.SelectedIndex = 1;
                    break;

                case "es":
                    lstLanguages.SelectedIndex = 2;
                    break;

                case "zh-Hans":
                    lstLanguages.SelectedIndex = 3;
                    break;

                case "fr":
                    lstLanguages.SelectedIndex = 4;
                    break;

                case "ja":
                    lstLanguages.SelectedIndex = 5;
                    break;
            }
        }

        private void btnAbort_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            btnApply.IsEnabled = false;
            txtRestartWarning.Visibility = Visibility.Visible;
                switch (lstLanguages.SelectedIndex)
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
            LanguageChanged(sender, e);
        }

        private void lstLanguages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnApply.IsEnabled = true;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            switch (lstLanguages.SelectedIndex)
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
            LanguageChanged(sender, e);
            this.Hide();
        }
    }
}
