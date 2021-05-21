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

namespace GUI.Controll
{
    /// <summary>
    /// Interaction logic for Khach.xaml
    /// </summary>
    public partial class Khach : UserControl
    {
        public Khach()
        {
            InitializeComponent();
            Load();
        }

        void Load()
        {
            dsban.ItemsSource = ATO.Ban.get().DefaultView;
            cbbTang.ItemsSource = ATO.Tang.get();
        }

        private void dsban_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView dr =  dsban.SelectedItem as DataRowView;
            if(dr!=null)
            {
                idban = Int32.Parse(dr[0].ToString());
                txtTenBan.Text = dr[1].ToString();
                cbbTang.Text = dr["tang"].ToString();
                ATO.Connect.get(@"exec Tinhtien " + dr[0].ToString());
                dsmon.ItemsSource = ATO.Connect.get(@"exec DSorder " + dr[0].ToString()).DefaultView;
                try
                {
                    Tong.Text =
                    ATO.Connect.get(@"select thanhtien from Bill where Trangthai = 0 and idban = " + dr[0].ToString()).Rows[0][0].ToString();
                }
                catch
                {
                    Tong.Text = "0";
                }
               

            }    
        }
        int idban;
        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked == false)
            {
                if (MessageBox.Show("tính tiền bàn " + (sender as CheckBox).Tag + " ?", "xác nhận",
                    MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    //--tính tiền
                    ATO.Connect.get("exec TinhBILL " + (sender as CheckBox).Tag);
                    dsmon.ItemsSource = null;
                    MessageBox.Show("BÀN SỐ " + (sender as CheckBox).Tag + " Số tiền là: " + Tong.Text, "Tính Tiền");
                    Tong.Text = "0";
                    txtThongtin.IsEnabled = false;
                    Load();
                }
                else (sender as CheckBox).IsChecked = true;
            }
            else {
                if (MessageBox.Show("Xác Nhận Khách Vào", "Xác Nhận", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    ATO.Connect.get("update ban set trangthai = 1 where id = " + (sender as CheckBox).Tag);
                    txtThongtin.IsEnabled = true;
                }
                else
                {
                    (sender as CheckBox).IsChecked = false;
                }    
            }
        }

        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new Add_Tang().ShowDialog();
            Load();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DTO.Ban ban = new DTO.Ban
            {
                tenban = txtTenBan.Text,
                tentang = cbbTang.Text,
            };
            if(ATO.Ban.Add(ban)==true)
            {
                MessageBox.Show("Thêm Bàn Thành Công!");
                Load();
            }  
            else MessageBox.Show("Thêm Bàn Thất Bại!!!");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DTO.Ban ban = new DTO.Ban
            {
                id = idban,
                tenban = txtTenBan.Text,
                tentang = cbbTang.Text,
            };
            if (ATO.Ban.Update(ban) == true)
            {
                MessageBox.Show("Sửa Bàn Thành Công!");
                Load();
            }
            else MessageBox.Show("Sửa Bàn Thất Bại!!!");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (ATO.Ban.Delete(idban) == true)
            {
                MessageBox.Show("Xóa Bàn Thành Công!");
                Load();
            }
            else MessageBox.Show("Xóa Bàn Thất Bại!!!");
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            new GUI.icon.Order(idban).ShowDialog();
            Load();
        }
    }
}
