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
using System.Data;
using System.Data.SqlClient;

namespace GUI.Controll
{
    /// <summary>
    /// Interaction logic for MonAn.xaml
    /// </summary>
    public partial class MonAn : UserControl
    {
        public MonAn()
        {
            InitializeComponent();
            Loaddata();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
        public void Loaddata()
        {
            Monan.ItemsSource = ATO.Mon.get();
            loaimon.ItemsSource = ATO.LoaiMon.get();
            loaimon.SelectedIndex = 0;
        }
        int idselect;
        private void Monan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView dt = Monan.SelectedItem as DataRowView;
            if(dt!=null)
            {
                idselect = Int32.Parse(dt[0].ToString());
                tenmon.Text = dt[1].ToString();
                loaimon.Text = dt[3].ToString();
                gia.Text = dt[2].ToString();
            }    
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Add_loaimon().ShowDialog();
            Loaddata();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DTO.Mon m = new DTO.Mon {
                id = idselect,
                tenmon = tenmon.Text,
                tenloai = loaimon.Text,
                gia = Int32.Parse(gia.Text)
            };
            if (ATO.Mon.Add(m) == true)
            {
                MessageBox.Show("Thêm Thành Công");
                Loaddata();
            }
            else
                MessageBox.Show("Thêm Thất Bại, Trùng tên");

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            DTO.Mon m = new DTO.Mon
            {
                id = idselect,
                tenmon = tenmon.Text,
                tenloai = loaimon.Text,
                gia = Int32.Parse(gia.Text)
            };
            if (ATO.Mon.Update(m) == true)
            {
                MessageBox.Show("Sửa Thành Công");
                Loaddata();
            }
            else
                MessageBox.Show("Sửa Thất Bại, mời chọn món muốn sửa.");
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (ATO.Mon.Delete(idselect) == true)
            {
                MessageBox.Show("Xóa Thành Công");
                Loaddata();
            }
            else
                MessageBox.Show("Xóa Thất Bại, Mời chọn");
        }
    }
}
