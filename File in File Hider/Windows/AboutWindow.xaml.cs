using System.Windows;
using System.Windows.Input;

namespace File_in_File_Hider.Windows
{
    /// <summary>
    /// Interaktionslogik für AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : Window
    {
        public AboutWindow()
        {
            InitializeComponent();
        }

        private void LinkToWebSite_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Not avaiable for now. Coming soon!", "Coming Soon");
        }

        private void CloseAbout_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {

            
        }
        private void Grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
