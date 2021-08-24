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
using System.Data.SqlClient;
using System.Data;

namespace Hotel_Booking_Management
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

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-4K6QFE4\SQLEXPRESS;Initial Catalog=HotelBooking;Integrated Security=True");
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                    SqlCommand cmd = new SqlCommand(@"SELECT * FROM [Admin1] WHERE UserName = @uname AND Password = @pwd", sqlcon);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@uname", tbusername.Text);
                    cmd.Parameters.AddWithValue("@pwd", tbpassword.Password);
                    int cnt = Convert.ToInt32(cmd.ExecuteScalar());
                   
                    if (cnt == 1)
                    {
                        Window1 wnd1 = new Window1();
                        wnd1.Show();
                        this.Close();
                        //MessageBox.Show("Working");
                    }
                    else
                    {
                        MessageBox.Show("Incorrect username or password");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong {0}", ex.Message.ToString());


            }
        }
    }
}
