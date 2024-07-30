using AssignmentPRN1.Models;
using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for ListCustomer.xaml
    /// </summary>
    public partial class ListCustomer : UserControl
    {
        private FuminiHotelManagementContext dbContext = new FuminiHotelManagementContext();
        private int customerId;
        private Customer customer;
        public ListCustomer()
        {
            InitializeComponent();
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            using (var context = new FuminiHotelManagementContext())
            {
                var list = context.Customers.ToList();
                dvgDisplay.ItemsSource = list;
            }
        }


        private void Button_UpdateClick(object sender, RoutedEventArgs e)
        {
            if (dvgDisplay.SelectedItem != null)
            {
                try
                {
                    Customer selectedCustomer = dvgDisplay.SelectedItem as Customer;

                    var customerToUpdate = dbContext.Customers.Find(selectedCustomer.CustomerId);

                    if (customerToUpdate != null)
                    {
                        
                        customerToUpdate.CustomerFullName = txtName.Text;
                        customerToUpdate.Telephone = txtPhone.Text;
                        customerToUpdate.EmailAddress = txtEmail.Text;

                        customerToUpdate.CustomerBirthday = DateOnly.Parse(dpkDob.Text);


                        dbContext.SaveChanges();
                        MessageBox.Show("Customer information updated successfully.");
                        LoadCustomers(); 
                    }
                    else
                    {
                        MessageBox.Show("Customer not found in the database.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating customer: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to update.");
            }
        }

        private void Button_DeleteClick(object sender, RoutedEventArgs e)
        {
            if (dvgDisplay.SelectedItem != null)
            {
                try
                {
                    Customer selectedCustomer = dvgDisplay.SelectedItem as Customer;
                    
                   
                    bool hasBookings = dbContext.BookingReservations.Any(br => br.CustomerId == selectedCustomer.CustomerId);

                    if (!hasBookings)
                    {
                        var customerToDelete = dbContext.Customers.Find(selectedCustomer.CustomerId);

                        if (customerToDelete != null)
                        {
                            
                            dbContext.Customers.Remove(customerToDelete);
                            dbContext.SaveChanges();
                            MessageBox.Show("Customer deleted successfully.");
                            LoadCustomers(); 
                        }
                        else
                        {
                            MessageBox.Show("Customer not found in the database.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cannot delete customer because there are associated bookings.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting customer: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to delete.");
            }
        }
    }
    
}
