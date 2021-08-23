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
    /// Interaction logic for ModifyBooking.xaml
    /// </summary>
    public partial class ModifyBooking : Window
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-4K6QFE4\SQLEXPRESS;Initial Catalog=HotelBooking;Integrated Security=True");

        public ModifyBooking()
        {
            InitializeComponent();
        }

        private void btnback_Click(object sender, RoutedEventArgs e)
        {
            Window1 wnd1 = new Window1();
            wnd1.Show();
            this.Close();
        }

        private void btnFetch_Click(object sender, RoutedEventArgs e)
        {
            LoadGrid();
        }
        public void LoadGrid()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Bookings Where Booking_Id = @Booking_Id", sqlcon);

            cmd.Parameters.AddWithValue("@Booking_Id", txtBookingId.Text);


            DataTable dt = new DataTable();
            sqlcon.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            sqlcon.Close();
            modifydatagrid.ItemsSource = dt.DefaultView;

        }

        private void btnModify_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                SqlCommand cmd = new SqlCommand("UPDATE Bookings SET Booking_FromDate = @Booking_FromDate , Booking_ToDate = @Booking_ToDate Where Booking_Id = @Booking_Id", sqlcon);

                cmd.Parameters.AddWithValue("@Booking_Id", txtBookingId.Text);
                cmd.Parameters.AddWithValue("@Booking_FromDate", dpnewfromdate.SelectedDate);
                cmd.Parameters.AddWithValue("@Booking_ToDate", dpnewtodate.SelectedDate);

                sqlcon.Open();
                cmd.ExecuteNonQuery();
                sqlcon.Close();
                MessageBox.Show("New dates Updated!");

                LoadGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
