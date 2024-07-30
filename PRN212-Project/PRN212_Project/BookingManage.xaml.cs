using AssignmentPRN1.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

namespace AssignmentPRN1
{
    /// <summary>
    /// Interaction logic for BookingManage.xaml
    /// </summary>
    public partial class BookingManage : UserControl
    {   
        private FuminiHotelManagementContext context = new FuminiHotelManagementContext();
        public BookingManage()
        {
            InitializeComponent();
            loadBooking();
        }

        private void loadBooking()
        {
            var list = context.BookingReservations.ToList();
            dvgDisplay.ItemsSource = list;
        }

        private void Button_UpdateClick(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var Booking = context.BookingReservations.FirstOrDefault(c=>c.BookingReservationId == id);
            if (Booking != null)
            {
                Booking.BookingStatus= byte.Parse(txtStatus.Text);
                context.SaveChanges();
                MessageBox.Show("Update successfully!");
                loadBooking();
            }
        }
    }
}
