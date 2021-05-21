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

namespace GUI
{
    /// <summary>
    /// Interaction logic for Add_loaimon.xaml
    /// </summary>
    public partial class Add_loaimon : Window
    {
        public Add_loaimon()
        {
            InitializeComponent();
            txtLoai.ItemsSource = ATO.LoaiMon.get();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ATO.LoaiMon.Add(txtLoai.Text) == true)
            {
                MessageBox.Show("Thành Công", "Thông báo");
                this.Close();
            }
            else MessageBox.Show("Thất bại trùng tên", "Thông báo");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (ATO.LoaiMon.Delete(txtLoai.Text) == true)
            {
                MessageBox.Show("Xóa Thành Công", "Thông Báo");
                txtLoai.ItemsSource = ATO.LoaiMon.get();
            }
            else MessageBox.Show("Thất Bại! Không tồn tại món", "Thông Báo");
        }
    }
}
