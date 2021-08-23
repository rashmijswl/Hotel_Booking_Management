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
            try
            {
                int roomid = 0;
                string roomtype;
                SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-4K6QFE4\SQLEXPRESS;Initial Catalog=HotelBooking;Integrated Security=True");

                SqlCommand cmd = new SqlCommand("INSERT INTO Bookings (Customer_Name, Customer_Phone, Customer_Email, Customer_ID_type, RoomID, Booking_FromDate, Booking_ToDate,  Payment_Card_number, RoomType) VALUES (@Customer_Name, @Customer_Phone, @Customer_Email, @Customer_ID_type, @RoomID, @Booking_FromDate, @Booking_ToDate, @Payment_Card_number,@RoomType)", sqlcon);
                cmd.CommandType = CommandType.Text;



                cmd.Parameters.AddWithValue("@Customer_Name", txtCustomerName.Text);
                cmd.Parameters.AddWithValue("@Customer_Phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@Customer_Email", txtEmailId1.Text);
                cmd.Parameters.AddWithValue("@Customer_ID_type", txtCustomerIdType.Text);

                if (rbPresidential.IsChecked == true)
                {
                    roomid = 1;
                    roomtype = rbPresidential.Content.ToString();
                }
                    
                else if (rbBeachView.IsChecked == true)
                {
                    roomid = 2;
                    roomtype = rbBeachView.Content.ToString();
                }
                else
                {
                    roomid = 3;
                    roomtype = rbApartment.Content.ToString();
                }

                cmd.Parameters.AddWithValue("@RoomID", roomid);
                cmd.Parameters.AddWithValue("@Booking_FromDate", dpFromDate.SelectedDate);
                cmd.Parameters.AddWithValue("@Booking_ToDate", dbToDate.SelectedDate);
                cmd.Parameters.AddWithValue("@Payment_Card_number", txtCreditCardNo.Text);
                cmd.Parameters.AddWithValue("@RoomType", roomtype);

                sqlcon.Open();
                cmd.ExecuteNonQuery();
                sqlcon.Close();

                MessageBox.Show("Stay booked!!");
                Window1 wnd1 = new Window1();
                wnd1.Show();
                this.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: {0}", ex.Message);
            }
        }

        private void btnback_Click(object sender, RoutedEventArgs e)
        {
            Window1 wnd1 = new Window1();
            wnd1.Show();
            this.Close();


        }
    }
}
