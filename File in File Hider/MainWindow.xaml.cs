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

namespace File_in_File_Hider
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void btnHostFilePath_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog OpenDialog = new System.Windows.Forms.OpenFileDialog();
            OpenDialog.Filter = "jpg files (*.jpg)|*.jpg|png files (*.png)|*.png|gif files (*.gif)|*.gif|dll files (*.dll)|*.dll|All files (*.*)|*.*";
            OpenDialog.ShowDialog();
            if (OpenDialog.FileName != "")
                HostFilePath.Text = OpenDialog.FileName;
        }

        private void btnHidingFilePath_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog OpenDialog = new System.Windows.Forms.OpenFileDialog();
            OpenDialog.Filter = "7zip files (*.7z)|*.7z|rar files (*.rar)|*.rar|zip files (*.zip)|*.zip|All files (*.*)|*.*";
            OpenDialog.ShowDialog();
            if (OpenDialog.FileName != "")
                HidingFilePath.Text = OpenDialog.FileName;
        }

        private void btnProductedFilePath_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.SaveFileDialog SaveDialog = new System.Windows.Forms.SaveFileDialog();
            SaveDialog.Filter = "jpg files (*.jpg)|*.jpg|png files (*.png)|*.png|gif files (*.gif)|*.gif|All files (*.*)|*.*";
            SaveDialog.ShowDialog();
            if (SaveDialog.FileName != "")
                ProductedFilePath.Text = SaveDialog.FileName;
        }
        string DoneText = Properties.Resources.Done;
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            txtOutput.Text = txtOutput.Text + Properties.Resources.Preparing;

            if (System.IO.File.Exists(ProductedFilePath.Text))
            {
                txtOutput.Text = txtOutput.Text + Properties.Resources.FileExists;
            }
            else
            {
                ProcessStartInfo cmdStartInfo = new ProcessStartInfo();
                cmdStartInfo.FileName = "cmd.exe";
                cmdStartInfo.RedirectStandardOutput = true;
                cmdStartInfo.RedirectStandardError = true;
                cmdStartInfo.RedirectStandardInput = true;
                cmdStartInfo.UseShellExecute = false;
                cmdStartInfo.CreateNoWindow = true;

                Process cmdProcess = new Process();
                cmdProcess.StartInfo = cmdStartInfo;
                cmdProcess.ErrorDataReceived += cmd_Error;
                cmdProcess.OutputDataReceived += new DataReceivedEventHandler(cmd_DataReceived);
                cmdProcess.EnableRaisingEvents = true;
                cmdProcess.Start();
                cmdProcess.BeginOutputReadLine();
                cmdProcess.BeginErrorReadLine();

                txtOutput.Text = txtOutput.Text + Properties.Resources.Working;
                cmdProcess.StandardInput.WriteLine("copy /b \"{0}\" + \"{1}\" \"{2}\"", HostFilePath.Text, HidingFilePath.Text, ProductedFilePath.Text);

                cmdProcess.StandardInput.WriteLine("exit");             //Execute exit.
                txtOutput.Text = txtOutput.Text + DoneText + "\n\n";
                DoneText = Properties.Resources.Done;
                cmdProcess.WaitForExit();
            }
        }
        private void cmd_DataReceived(object sender, DataReceivedEventArgs e)
        {

        }
        private void cmd_Error(object sender, DataReceivedEventArgs e)
        {
            DoneText = Properties.Resources.ErrorOccured + e.Data + "\n\n";
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            HostFilePath.Text = "";
            HidingFilePath.Text = "";
            ProductedFilePath.Text = "";
            txtOutput.Text = "";
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void mnuShowHelpWindow_Click(object sender, RoutedEventArgs e)
        {
            Windows.HelpWindow helpWindow = new Windows.HelpWindow();
            helpWindow.Show();
        }

        private void mnuShowAboutWindow_Click(object sender, RoutedEventArgs e)
        {
            Windows.AboutWindow aboutWindow = new Windows.AboutWindow();
            aboutWindow.Show();
        }

        private void btnClearOoutput_Click(object sender, RoutedEventArgs e)
        {
            txtOutput.Text = "";
        }
    }
}
