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

            if (!(txtBookingId.Text == string.Empty))
            {
                LoadGrid();

            }
        }
        public void LoadGrid()
        {

            SqlCommand cmd1 = new SqlCommand("select count(*) from Bookings where Booking_Id = @Booking_id", sqlcon);
            cmd1.Parameters.AddWithValue("@Booking_id", txtBookingId.Text);
            sqlcon.Open();
            
            int count = cmd1.ExecuteNonQuery();
         
            //if (count > 0)
            {


                SqlCommand cmd = new SqlCommand("SELECT * FROM Bookings Where Booking_Id = @Booking_Id", sqlcon);

                cmd.Parameters.AddWithValue("@Booking_Id", txtBookingId.Text);



                DataTable dt = new DataTable();
                //sqlcon.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                sqlcon.Close();
                modifydatagrid.ItemsSource = dt.DefaultView;
                //return true;
            }
            //else
            {
            //    MessageBox.Show("Booking Id does not exist");
                //return false;
            }
        }

        private void btnModify_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (valididation())
                {


                    SqlCommand cmd = new SqlCommand("UPDATE Bookings SET Booking_FromDate = @Booking_FromDate , Booking_ToDate = @Booking_ToDate Where Booking_Id = @Booking_Id", sqlcon);



                    cmd.Parameters.AddWithValue("@Booking_Id", txtBookingId.Text);
                    cmd.Parameters.AddWithValue("@Booking_FromDate", dpnewfromdate.SelectedDate);
                    cmd.Parameters.AddWithValue("@Booking_ToDate", dpnewtodate.SelectedDate);

                    sqlcon.Open();
                    cmd.ExecuteNonQuery();
                    sqlcon.Close();
                    LoadGrid();

                    //if (LoadGrid())
                    {

                        MessageBox.Show("New dates Updated!");
                    }
                        
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public bool valididation()
        {
            DateTime today = DateTime.Now.Date;

            try
            {

                if (!(txtBookingId.Text == string.Empty))
                {

                        if (dpnewfromdate.SelectedDate >= today && dpnewtodate.SelectedDate >= today && dpnewtodate.SelectedDate >= dpnewfromdate.SelectedDate)
                        {
                            //sqlcon.Close();
                            return true;
                        }
                        else
                        {
                            //sqlcon.Close();
                            MessageBox.Show("Invalid Dates");
                            return false;
                        }                 
   
                }
                else
                {
                    MessageBox.Show("Booking Id cannot be empty");
                    return false;
                }

                
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally { sqlcon.Close(); }

        }
    }
}
