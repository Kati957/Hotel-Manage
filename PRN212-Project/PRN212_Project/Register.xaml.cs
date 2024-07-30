using AssignmentPRN1.Models;
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
using System.Windows.Shapes;

namespace AssignmentPRN1
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        private FuminiHotelManagementContext context = new FuminiHotelManagementContext();
        public Register()
        {
            InitializeComponent();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            Customer customer = new Customer();
            customer.CustomerFullName = txtFullName.Text;
            customer.Telephone = txtTelephone.Text;
            customer.EmailAddress = txtEmailAddress.Text;
            customer.CustomerBirthday = DateOnly.Parse(dpkDate.Text);
            customer.CustomerStatus = 1;

            try
            {
                if (txtPassword.Password.Equals(txtConfirmPassword.Password))
                {
                    customer.Password = txtConfirmPassword.Password;
                    context.Add(customer);
                    context.SaveChanges();
                    MessageBox.Show("Register Successfully");
                    Login login = new Login();
                    login.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Passwords do not match!");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

        }
    }
}
//using AssignmentPRN1.Models;
//using System;
//using System.Net;
//using System.Net.Mail;
//using System.Windows;

//namespace AssignmentPRN1
//{
//    /// <summary>
//    /// Interaction logic for Register.xaml
//    /// </summary>
//    public partial class Register : Window
//    {
//        private FuminiHotelManagementContext context = new FuminiHotelManagementContext();

//        public Register()
//        {
//            InitializeComponent();
//        }

//        private void Save(object sender, RoutedEventArgs e)
//        {
//            Customer customer = new Customer
//            {
//                CustomerFullName = txtFullName.Text,
//                Telephone = txtTelephone.Text,
//                EmailAddress = txtEmailAddress.Text,
//                CustomerBirthday = DateOnly.Parse(dpkDate.Text),
//                CustomerStatus = 1
//            };

//            try
//            {
//                if (txtPassword.Password.Equals(txtConfirmPassword.Password))
//                {
//                    customer.Password = txtConfirmPassword.Password;
//                    context.Add(customer);
//                    context.SaveChanges();
//                    SendConfirmationEmail(customer.EmailAddress, customer.CustomerFullName);
//                    MessageBox.Show("Register Successfully");
//                    Login login = new Login();
//                    login.Show();
//                    this.Close();
//                }
//                else
//                {
//                    MessageBox.Show("Passwords do not match!");
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"An error occurred: {ex.Message}");
//            }
//        }

//        private void SendConfirmationEmail(string toEmail, string customerName)
//        {
//            try
//            {
//                var fromAddress = new MailAddress("hungnvhe173013@fpt.edu.vn", "katii");
//                var toAddress = new MailAddress(toEmail, customerName);
//                const string fromPassword = "rhrg wzwb lbpd pcym";
//                const string subject = "Registration Confirmation";
//                string body = $"Dear {customerName},\n\nThank you for registering at Fumini Hotel Management.\n\nBest Regards,\nFumini Hotel Management Team";

//                var smtp = new SmtpClient
//                {
//                    Host = "smtp.gmai.com",
//                    Port = 587,
//                    EnableSsl = true,
//                    DeliveryMethod = SmtpDeliveryMethod.Network,
//                    UseDefaultCredentials = false,
//                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
//                };

//                using (var message = new MailMessage(fromAddress, toAddress)
//                {
//                    Subject = subject,
//                    Body = body
//                })
//                {
//                    smtp.Send(message);
//                }

//                MessageBox.Show("Confirmation email sent successfully.");
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Failed to send confirmation email: {ex.Message}");
//            }
//        }
//    }
//}
