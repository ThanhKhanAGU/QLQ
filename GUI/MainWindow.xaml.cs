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

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            MENU = new Controll.MonAn();
            QUAN = new Controll.Khach();
            DOANHTHU = new Controll.DoanhThu();
            InitializeComponent();
            change();
        }
        Controll.MonAn MENU;
        Controll.Khach QUAN;
        Controll.DoanhThu DOANHTHU;
        void change()
        {
            body.Children.Clear();
            foreach(RadioButton r in MenuButton.Children)
            {
                if(r.IsChecked == true)
                {
                    if (r.Tag.ToString() == "MÓN ĂN")
                        body.Children.Add(MENU);
                    if (r.Tag.ToString() == "KHÁCH")
                        body.Children.Add(QUAN);
                    if (r.Tag.ToString() == "D. THU")
                        body.Children.Add(DOANHTHU);
                }    
            }    
            
        }
        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void fullscreen(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            { 
                WindowState = WindowState.Maximized;
                btnfullscreen.Source = new BitmapImage(new Uri(@"/icon/full_screen_exit.png", UriKind.Relative));
                Screen.Margin = new Thickness(7);
            }
            else
            {
                WindowState = WindowState.Normal;
                btnfullscreen.Source = new BitmapImage(new Uri(@"/icon/full_screen.png", UriKind.Relative));
                Screen.Margin = new Thickness(0);
            }
        }

        private void minicreen(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void DockPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            change();
        }
    }
}
