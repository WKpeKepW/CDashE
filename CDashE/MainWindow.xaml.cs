using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            TForemoticBuff.Text = CollectionEmotic.ReturnEmotic(TForemotic);//а так же нужно будет сделать чтобы приложение
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
