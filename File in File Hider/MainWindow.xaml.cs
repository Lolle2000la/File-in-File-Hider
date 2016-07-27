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
using System.Diagnostics;
using File_in_File_Hider.Windows;

namespace File_in_File_Hider
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            if (Properties.Settings.Default.Language != "") // If a language is selected, start with this language
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture =
                    new System.Globalization.CultureInfo(Properties.Settings.Default.Language); // Sets UI Language to the saved language
            }
            InitializeComponent();
            
        }

        private void btnHostFilePath_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog OpenDialog = new System.Windows.Forms.OpenFileDialog(); // Creates a OpenFileDialog named OpenDialog
            OpenDialog.Filter = "jpg files (*.jpg)|*.jpg|png files (*.png)|*.png|gif files (*.gif)|*.gif|dll files (*.dll)|*.dll|All files (*.*)|*.*"; // Sets the Filter of the OpenDialog
            OpenDialog.ShowDialog(); // Shows OpenDialog
            if (OpenDialog.FileName != "") // if OpenDialog.FileName isn't nothing,
                HostFilePath.Text = OpenDialog.FileName; // set HostFilePath.Text to OpenDialog.FileName
        }

        private void btnHidingFilePath_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog OpenDialog = new System.Windows.Forms.OpenFileDialog(); // Creates a OpenFileDialog named OpenDialog
            OpenDialog.Filter = "7zip files (*.7z)|*.7z|rar files (*.rar)|*.rar|zip files (*.zip)|*.zip|All files (*.*)|*.*"; // Sets the Filter of the OpenDialog
            OpenDialog.ShowDialog(); // Shows OpenDialog
            if (OpenDialog.FileName != "") // if OpenDialog.FileName isn't nothing,
                HidingFilePath.Text = OpenDialog.FileName; // set HidingFilePath.Text to OpenDialog.FileName
        }

        private void btnProductedFilePath_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.SaveFileDialog SaveDialog = new System.Windows.Forms.SaveFileDialog(); // Creates a SaveFileDialog named SaveDialog
            SaveDialog.Filter = "jpg files (*.jpg)|*.jpg|png files (*.png)|*.png|gif files (*.gif)|*.gif|All files (*.*)|*.*"; // Sets the Filter of the SaveDialog
            SaveDialog.ShowDialog(); // Shows SaveDialog
            if (SaveDialog.FileName != "") // if SaveDialog.FileName isn't nothing,
                ProductedFilePath.Text = SaveDialog.FileName; // if SaveDialog.FileName isn't nothing,
        }
        string DoneText = Properties.Resources.Done;
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            txtOutput.Text = txtOutput.Text + Properties.Resources.Preparing; // Adds "Preparing..." to txtOutput.Text

            if (System.IO.File.Exists(ProductedFilePath.Text)) // Checks if the File to produces exists
            {
                txtOutput.Text = txtOutput.Text + Properties.Resources.FileExists; // Adds "File Exists!!!" to txtOutput.Text
            }
            else // Else starts Generation Process
            {
                ProcessStartInfo cmdStartInfo = new ProcessStartInfo(); // Declares and initializes cmdStartInfo As ProcessStartInfo
                cmdStartInfo.FileName = "cmd.exe"; // Sets the FileName to "cmd.exe"
                cmdStartInfo.RedirectStandardOutput = true;
                cmdStartInfo.RedirectStandardError = true;
                cmdStartInfo.RedirectStandardInput = true;
                cmdStartInfo.UseShellExecute = false; // Sets ShellExecute to false
                cmdStartInfo.CreateNoWindow = true; // Hides the cmd Window

                Process cmdProcess = new Process(); // Declares and initializes cmdProcess As Process
                cmdProcess.StartInfo = cmdStartInfo; // Sets StartInfo to cmdStartInfo
                cmdProcess.ErrorDataReceived += cmd_Error; // Sets ErrorDataRecieved Event Handler 
                cmdProcess.OutputDataReceived += new DataReceivedEventHandler(cmd_DataReceived); // Sets OutputDataReceived Event Handler
                cmdProcess.EnableRaisingEvents = true; // Enables Events
                cmdProcess.Start(); // Starts cmd
                cmdProcess.BeginOutputReadLine(); // Beginns reading
                cmdProcess.BeginErrorReadLine(); // Beginns Error Listening

                txtOutput.Text = txtOutput.Text + Properties.Resources.Working; // Adds "working" to Output
                cmdProcess.StandardInput.WriteLine("copy /b \"{0}\" + \"{1}\" \"{2}\"", HostFilePath.Text, HidingFilePath.Text, ProductedFilePath.Text); // Enters the "copy /b" command

                cmdProcess.StandardInput.WriteLine("exit"); //Execute exit.
                cmdProcess.WaitForExit(); // Waits for exit

                txtOutput.Text = txtOutput.Text + Properties.Resources.Done + "\n\n"; // Adds "done!" to txtOutput.Text
                DoneText = Properties.Resources.Done; // Sets DoneText
            }
        }
        private void cmd_DataReceived(object sender, DataReceivedEventArgs e)
        {

        }
        private void cmd_Error(object sender, DataReceivedEventArgs e)
        {
            DoneText = Properties.Resources.ErrorOccured + e.Data + "\n\n"; // Sets DoneText to Error
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            HostFilePath.Text = ""; // Clears any TextBox on MainWindow
            HidingFilePath.Text = "";
            ProductedFilePath.Text = "";
            txtOutput.Text = "";
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); // Closes Application
        }

        private void mnuShowHelpWindow_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow helpWindow = new HelpWindow();
            helpWindow.Show(); // Shows HelpWindow
        }

        private void mnuShowAboutWindow_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.Show(); // Show AboutWindow
        }

        private void btnClearOoutput_Click(object sender, RoutedEventArgs e)
        {
            txtOutput.Text = ""; // Clears Output
        }

        private void mnuLanguage_Click(object sender, RoutedEventArgs e)
        {
            LanguageWindow languageWindow = new LanguageWindow();
            languageWindow.Show(); // Shows LanguageWindow
        }
    }
}
