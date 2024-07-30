    using AssignmentPRN1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Windows;

namespace AssignmentPRN1
{
    public partial class Login : Window
    {
        private readonly FuminiHotelManagementContext dbContext;
        private readonly IConfiguration configuration;
        private readonly string adminEmail;
        private readonly string adminPassword;

        public Login()
        {
            InitializeComponent();

            dbContext = new FuminiHotelManagementContext();

            configuration = LoadConfiguration();
            adminEmail = configuration["admincredentials:email"];
            adminPassword = configuration["admincredentials:password"];
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Password;

            if (email == adminEmail && password == adminPassword)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                var user = IsValidUser(email, password);
                if (user != null)
                {
                    CustomerInfo customerViewInfo = new CustomerInfo(user.CustomerId);
                    customerViewInfo.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid email or password. Please try again.");
                }
            }
        }

        private Customer IsValidUser(string email, string password)
        {
            return dbContext.Customers.FirstOrDefault(c => c.EmailAddress == email && c.Password == password);
        }

        private IConfiguration LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("AppSettings.json", optional: false, reloadOnChange: true);
            return builder.Build();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Close();
        }

        private void txtEmail_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
