using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace Hotel_Booking_Management
{
    /// <summary>
    /// Interaction logic for ViewAndCheck.xaml
    /// </summary>
    public partial class ViewAndCheck : Window
    {

        SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-4K6QFE4\SQLEXPRESS;Initial Catalog=HotelBooking;Integrated Security=True");

        public ViewAndCheck()
        {
            InitializeComponent();
          
        }


        private void btnback_Click(object sender, RoutedEventArgs e)
        {
            Window1 wnd1 = new Window1();
            wnd1.Show();
            this.Close();
        }

        private void btnViewBookings_click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dpFromDate.SelectedDate.ToString() == string.Empty || dpToDate.SelectedDate.ToString() == string.Empty)
                {
                    MessageBox.Show("Please select the date");
                    
                }
                else if (dpFromDate.SelectedDate > dpToDate.SelectedDate)
                {
                    MessageBox.Show("From Date can not be greater than To Date.");
                }
                else
                {
                    LoadGrid();
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        public void LoadGrid()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Bookings Where Booking_FromDate BETWEEN @Booking_FromDate AND @Booking_ToDate", sqlcon);
            cmd.Parameters.AddWithValue("@Booking_FromDate", dpFromDate.SelectedDate);
            cmd.Parameters.AddWithValue("@Booking_ToDate", dpToDate.SelectedDate);


            DataTable dt = new DataTable();
            sqlcon.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            sqlcon.Close();
            dataGrid.ItemsSource = dt.DefaultView;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tbapartmentcount.Text = "100";
            tbbeachviewcount.Text = "50";
            tbpresidentavailcount.Text = "8";
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow loginScreen = new MainWindow();
            loginScreen.Show();
            this.Close();
        }
    }
}
