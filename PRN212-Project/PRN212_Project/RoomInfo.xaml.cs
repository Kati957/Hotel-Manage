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
    /// Interaction logic for RoomInfo.xaml
    /// </summary>
    public partial class RoomInfo : UserControl
    {
        private FuminiHotelManagementContext dbContext = new FuminiHotelManagementContext();
        public RoomInfo()
        {
            InitializeComponent();
            LoadRoom();
        }
        private void LoadRoom()
        {
            using (var context = new FuminiHotelManagementContext())
            {
                var list = context.RoomInformations.ToList();
                dvgDisplay.ItemsSource = list;
            }
        }

        private void Button_InsertClick(object sender, RoutedEventArgs e)
        {
            RoomInformation room = new RoomInformation();
            room.RoomNumber = txtNumber.Text;
            room.RoomDetailDescription = txtDetail.Text;
            room.RoomMaxCapacity = int.Parse(txtMaxCapacity.Text);
            room.RoomTypeId = int.Parse(txtRoomTypeId.Text);
            room.RoomStatus = byte.Parse(txtStatus.Text);

            if (decimal.TryParse(txtPrice.Text, out decimal price))
            {
                room.RoomPricePerDay = price;
            }
                dbContext.Add(room);
                dbContext.SaveChanges();
                MessageBox.Show("insert room successfully!");
                LoadRoom();
         
        }

        private void Button_UpdateClick(object sender, RoutedEventArgs e)
        {
            
            RoomInformation selectedRoom = dvgDisplay.SelectedItem as RoomInformation;
            if (selectedRoom == null)
            {
                MessageBox.Show("Please select a room to update.");
                return;
            }

           
            var roomToUpdate = dbContext.RoomInformations.Find(selectedRoom.RoomId);
            if (roomToUpdate == null)
            {
                MessageBox.Show("Room not found in the database.");
                return;
            }

            
            roomToUpdate.RoomNumber = txtNumber.Text;
            roomToUpdate.RoomDetailDescription = txtDetail.Text;
            roomToUpdate.RoomMaxCapacity = int.Parse(txtMaxCapacity.Text);
            roomToUpdate.RoomTypeId = int.Parse(txtRoomTypeId.Text);
            roomToUpdate.RoomStatus = byte.Parse(txtStatus.Text);
            
            if (decimal.TryParse(txtPrice.Text, out decimal price))
            {
                roomToUpdate.RoomPricePerDay = price;
            }

            
            try
            {
                dbContext.SaveChanges();
                MessageBox.Show("Room information updated successfully.");
                LoadRoom(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating room information: {ex.Message}");
            }
        }




        private void Button_DeleteClick(object sender, RoutedEventArgs e)
        {
            RoomInformation room = dvgDisplay.SelectedItem as RoomInformation;
            var deleteRoom = dbContext.RoomInformations.Find(room.RoomId);
            if (deleteRoom != null)
            {
                dbContext.Remove(deleteRoom);
                dbContext.SaveChanges();
                MessageBox.Show("Delete Successfully!");
                LoadRoom();
            }
        }
    }
}
