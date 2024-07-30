using AssignmentPRN1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AssignmentPRN1
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

        private void btnLoadCustomer(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new ListCustomer();
        }

        private void btnLoadRoom(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new RoomInfo();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            Login loginWindow = new Login();
            loginWindow.Show();
            this.Close();
        }

        private void btnBooking_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new BookingManage();

        }
    }
}
