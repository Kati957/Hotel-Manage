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
    /// Interaction logic for CustomerBooking.xaml
    /// </summary>
    public partial class CustomerBooking : Window
    {
        // Biến lưu trữ và hàm khởi tạo, nhận vào ID của khách hàng
        private int customerId;

        public CustomerBooking(int customerId)
        {
            InitializeComponent();
            this.customerId = customerId;
        }

 
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            BookingReservation booking = getBookingReservation();
            if (booking == null) return;

            // Thêm booking vào cơ sở dữ liệu và lưu thay đổi
            FuminiHotelManagementContext.INSTANCE.BookingReservations.Add(booking);
            FuminiHotelManagementContext.INSTANCE.SaveChanges();
            MessageBox.Show("Booking Succesfully!");
        }

        // Phương thức lấy thông tin đặt phòng
        private BookingReservation getBookingReservation()
        {
            BookingReservation booking = new BookingReservation();
            try
            {
                // Lấy ngày bắt đầu từ DatePicker và chuyển đổi sang DateOnly
                booking.BookingDate = dpkStartDate.SelectedDate.HasValue ? DateOnly.FromDateTime(dpkStartDate.SelectedDate.Value) : (DateOnly?)null;

                // Chuyển đổi giá tiền từ chuỗi sang kiểu decimal
                booking.TotalPrice = decimal.TryParse(txtTotalPrice.Text, out decimal price) ? price : (decimal?)null;

                // Gán ID khách hàng và trạng thái đặt phòng
                booking.CustomerId = customerId;
                booking.BookingStatus = 1;
                return booking;
            }
            catch (Exception e)
            {
                // Hiển thị thông báo lỗi nếu có lỗi xảy ra
                MessageBox.Show("Error: " + e.Message);
                return null;
            }
        }

       
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Thiết lập nguồn dữ liệu cho ComboBox loại phòng
            cbxRoomType.ItemsSource = FuminiHotelManagementContext.INSTANCE.RoomTypes.ToList();
        }

        private void cbxRoomType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Lấy loại phòng đã chọn và thiết lập nguồn dữ liệu cho ComboBox số phòng tương ứng
            RoomType roomType = (RoomType)cbxRoomType.SelectedItem;
            cbxRoomNumber.ItemsSource = FuminiHotelManagementContext.INSTANCE.RoomInformations.Where(r => r.RoomTypeId == roomType.RoomTypeId).ToList();
        }

        // Phương thức tính tổng giá tiền
        private void count()
        {
            try
            {
                if (cbxRoomNumber == null) throw new Exception();
                RoomInformation room = (RoomInformation)cbxRoomNumber.SelectedItem;

                // Lấy ngày bắt đầu và ngày kết thúc từ DatePicker
                DateTime StartDate = dpkStartDate.SelectedDate ?? DateTime.Today;
                DateTime EndDate = dpkEndDate.SelectedDate ?? DateTime.Today;

                // Tính số ngày và kiểm tra tính hợp lệ của ngày kết thúc
                DateTime startDate = dpkStartDate.SelectedDate ?? DateTime.Today;
                DateTime endDate = dpkEndDate.SelectedDate ?? DateTime.Today;
                TimeSpan difference = endDate - startDate;
                int differenceInDays = (int)difference.TotalDays + 1;
                if (differenceInDays < 0) { txtTotalPrice.Text = "Wrong EndDate"; return; }

                if (room == null) throw new Exception();

                // Tính tổng giá tiền và hiển thị kết quả dựa trên số ngày và giá mỗi ngày của phòng 
                decimal total = (decimal)(differenceInDays * room.RoomPricePerDay);

                txtTotalPrice.Text = total.ToString();
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi nếu có lỗi xảy ra
                if (txtTotalPrice != null)
                    txtTotalPrice.Text = "Fill Input";
            }
        }

        private void cbxRoomNumber_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            count();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            // Mở cửa sổ thông tin khách hàng và đóng cửa sổ hiện tại
            CustomerInfo customerinfo = new CustomerInfo(customerId);
            customerinfo.Show();
            this.Close();
        }
    }
}
