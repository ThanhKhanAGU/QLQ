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
using System.Data;

namespace GUI.icon
{
    /// <summary>
    /// Interaction logic for Order.xaml
    /// </summary>
    public partial class Order : Window
    {
        public Order(int idban)
        {
            InitializeComponent();
            idbanduocchon = idban;
            txtmon.ItemsSource = ATO.Mon.get();
            dsmon.ItemsSource = ATO.Connect.get(@"exec DSorder " + idban).DefaultView;
        }
        int idbanduocchon;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataRowView vi = txtmon.SelectedItem as DataRowView;
            if(vi != null)
            {
                string query = @"insert OrderPart(id,idmon,soluong,idban,ghichu) values(getdate()," + vi[0].ToString() + "," + txtsoluong.Text + "," + idbanduocchon + ",N'" + txtghichu.Text + "')";
                if (!ATO.Connect.post(query)==true)
                    MessageBox.Show("Thêm không thành công mời chọn món");
                else dsmon.ItemsSource = ATO.Connect.get(@"exec DSorder " + idbanduocchon).DefaultView;
                txtsoluong.Text = "1";
            } 
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int a = Int32.Parse(txtsoluong.Text)-1;
            if (a < 0) a = 0;
            txtsoluong.Text = a + "";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int a = Int32.Parse(txtsoluong.Text) + 1;
            txtsoluong.Text = a + "";
        }

        private void txtmon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
