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

namespace Hotel_Booking_Management
{
    /// <summary>
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void btnViewBookings_Click(object sender, RoutedEventArgs e)
        {
            ViewAndCheck view = new ViewAndCheck();
            view.Show();
            this.Close();

        }

        private void btnBookStay_Click(object sender, RoutedEventArgs e)
        {
            BookingStay book = new BookingStay();
            book.Show();
            this.Close();
        }

        private void btnCheckAvailability_Click(object sender, RoutedEventArgs e)
        {
            ViewAndCheck check = new ViewAndCheck();
            check.Show();
            this.Close();
        }

        private void btnModifyBookings_Click(object sender, RoutedEventArgs e)
        {
            ModifyBooking modify = new ModifyBooking();
            modify.Show();
            this.Close();

        }
    }
}
