using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;

namespace CDashE
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

        private void Bresult_Click(object sender, RoutedEventArgs e)// сделать хороший интерфейс который будет менятся 
        {                                                           //динамичиски как только я буду делать его совсем мал
            TForemoticBuff.Text = CollectionEmotic.ReturnEmotic(TForemotic.Text);//а так же нужно будет сделать чтобы приложение
                                                                            //само считывало буфер обмена и закидовало туда 
        }

        private void Past_Click(object sender, RoutedEventArgs e)
        {
            TForemotic.Text = Clipboard.GetText();
        }

        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(TForemoticBuff.Text);
        }

        private void ChangeConfig_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo(AppDomain.CurrentDomain.BaseDirectory + "\\Emotic.txt") { UseShellExecute = true });
        }
    }
}
