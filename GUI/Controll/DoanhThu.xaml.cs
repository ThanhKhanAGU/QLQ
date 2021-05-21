using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for DoanhThu.xaml
    /// </summary>
    public partial class DoanhThu : UserControl
    {
        public DoanhThu()
        {
            InitializeComponent();
            Load();
        }
        public void Load()
        {        
            //Bill.ItemsSource = ATO.Connect.get("select * From Bill where thanhtien is not null").DefaultView;
            //int a = 0;
            //foreach (DataRowView dt in Bill.Items)
            //{
            //    if (DateTime.Today.Date == DateTime.Parse(dt[0].ToString()).Date)
            //        a += Int32.Parse(dt[2].ToString());
            //}
            //txtdoanhthungay.Text = a + "";

        }

        private void day_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int a = 0;
                foreach (DataRowView dt in Bill.Items)
                {
                    if (DateTime.Parse(day.Text).Date == DateTime.Parse(dt[0].ToString()).Date)
                        a += Int32.Parse(dt[2].ToString());
                }
                
                txtdoanhthungay.Text = a + "";
            }
            catch
            {

            }
            
        }
    }
}
