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
    /// Interaction logic for BookingStay.xaml
    /// </summary>
    public partial class BookingStay : Window
    {
        public BookingStay()
        {
            InitializeComponent();
        }

        private void btnBook_Click(object sender, RoutedEventArgs e)
        {
            int roomtype = 0;
            SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-4K6QFE4\SQLEXPRESS;Initial Catalog=HotelBooking;Integrated Security=True");

            SqlCommand cmd = new SqlCommand("INSERT INTO StudentInfo (Customer_Name, Customer_Phone, Customer_Email, Customer_ID_type, Booking_FromDate, Booking_ToDate,  Payment_Card_number) VALUES (@Customer_Name, @Customer_Phone, @Customer_Email, @Customer_ID_type, @RoomID, @Booking_FromDate, @Booking_ToDate, @Payment_Card_number)", sqlcon);
            cmd.CommandType = CommandType.Text;


            cmd.Parameters.AddWithValue("@Customer_Name", txtCustomerName.Text);
            cmd.Parameters.AddWithValue("@Customer_Phone", txtPhone.Text);
            cmd.Parameters.AddWithValue("@Customer_Email", txtEmailId1.Text);
            cmd.Parameters.AddWithValue("@Customer_ID_type", txtCustomerIdType.Text);
            cmd.Parameters.AddWithValue("@Booking_FromDate", dpFromDate.SelectedDate);
            cmd.Parameters.AddWithValue("@Booking_ToDate", dbToDate.SelectedDate);
            cmd.Parameters.AddWithValue("@Payment_Card_number", txtCreditCardNo.Text);

            if (rbPresidential.IsChecked == true)            
                roomtype = 1;        
            else if (rbBeachView.IsChecked == true)
                roomtype = 2;
            else
                roomtype = 3;

            cmd.Parameters.AddWithValue("@RoomID", roomtype);
        }

        private void btnback_Click(object sender, RoutedEventArgs e)
        {
            Window1 wnd1 = new Window1();
            wnd1.Show();
            this.Close();


        }
    }
}
