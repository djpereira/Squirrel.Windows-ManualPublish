using System;
using System.Windows;
using System.Windows.Media;
using Squirrel;

namespace SquirrelManualPublish
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var mgr = new UpdateManager(@"C:\Users\danie_000\Documents\visual studio 2015\Projects\SquirrelManualPublish\Releases\"))
                {
                    var releaseEntry = await mgr.UpdateApp();
                    if (releaseEntry == null)
                        UpdateMessage($"There are no updates available", Brushes.Green);
                    else
                        UpdateMessage($"Updated to version {releaseEntry.Version}", Brushes.Green);
                }
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }

        private void ManageException(Exception ex)
        {
            UpdateMessage(ex.Message, Brushes.Red);
        }

        private void UpdateMessage(string text, Brush foreground)
        {
            Message.Text = text;
            Message.Foreground = foreground;
        }

    }
}
