using AssignmentPRN1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AssignmentPRN1
{
    /// <summary>
    /// Interaction logic for CustomerInfo.xaml
    /// </summary>
    public partial class CustomerInfo : Window
    {
        private FuminiHotelManagementContext dbContext = new FuminiHotelManagementContext();
        private int customerId;
        private Customer customer;

        public CustomerInfo(int customerId)
        {
            InitializeComponent();
            this.customerId = customerId;
            LoadCustomerData();
        }

        private void LoadCustomerData()
        {
            customer = dbContext.Customers.FirstOrDefault(c => c.CustomerId == customerId);
            if (customer != null)
            {
                txtFullName.Text = customer.CustomerFullName;
                txtTelephone.Text = customer.Telephone;
                txtEmailAddress.Text = customer.EmailAddress;
                txtBirthday.Text = customer.CustomerBirthday?.ToShortDateString();
                txtPassword.Password = customer.Password;

            }
            else
            {
                MessageBox.Show("Customer not found.");
                this.Close();
            }
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            if (customer != null)
            {
                customer.CustomerFullName = txtFullName.Text;
                customer.Telephone = txtTelephone.Text;
                customer.EmailAddress = txtEmailAddress.Text;

                if (DateOnly.TryParse(txtBirthday.Text, out DateOnly parsedDate))
                {
                    customer.CustomerBirthday = parsedDate;
                }
                else
                {
                    MessageBox.Show("Invalid date format. Please enter a valid date.");
                    return;
                }

                customer.Password = txtPassword.Password;

                try
                {
                    dbContext.SaveChanges();
                    MessageBox.Show("Your information updated successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving customer information: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Eror");
            }
        }

        private void ViewBooking_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                customer = dbContext.Customers
                                    .Include(c => c.BookingReservations)
                                    .FirstOrDefault(c => c.CustomerId == customerId);

                if (customer != null)
                {
                    var bookings = customer.BookingReservations.ToList();

                    if (bookings.Any())
                    {
                        dataGridBookings.ItemsSource = bookings; 
                    }
                    else
                    {
                        MessageBox.Show("No bookings found for this customer.");
                    }
                }
                else
                {
                    MessageBox.Show("Customer not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading bookings: {ex.Message}");
            }
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            Login loginWindow = new Login();
            loginWindow.Show();
            this.Close();
        }

        private void btnBookRoom_Click(object sender, RoutedEventArgs e)
        {
            CustomerBooking bookingWindow = new CustomerBooking(customerId);
            bookingWindow.Show();
            this.Close();
        }
    }
}