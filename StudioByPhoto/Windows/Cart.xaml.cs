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
using static StudioByPhoto.PhotoDataContext;
using static StudioByPhoto.UserInformation;

namespace StudioByPhoto
{
    public partial class Cart : Window
    {
        public Cart()
        {
            InitializeComponent();
            cartListView.ItemsSource = UserOrders;
            totalText.Text = $"Итого: {UserOrders.Sum(o => o.FinalPrice)} руб.";
        }

        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            if (cartListView.SelectedItem is Order selectedOrder)
            {
                if (MessageBox.Show("Вы уверены что хотите удалить выбранный заказ?", "Удаление!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    UserOrders.Remove(selectedOrder);
                    MessageBox.Show("Заказ успешно удален!", "Успешно!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    cartListView.ItemsSource = null;
                    cartListView.ItemsSource = UserOrders;
                    totalText.Text = $"Итого: {UserOrders.Sum(o => o.FinalPrice)} руб.";
                }
            }
        }

        private void AddOrdersButtonClick(object sender, RoutedEventArgs e)
        {
            UserName = customerNameTextBox.Text;
            UserPhone = customerPhoneTextBox.Text;

            int customerId;
            if (DBContext.Customer.SingleOrDefault(c => c.Name == UserName && c.Phone == UserPhone) != null)
            {
                customerId = DBContext.Customer.Single(c => c.Name == UserName && c.Phone == UserPhone).IdCustomer;
            }
            else
            {
                customerId = DBContext.Customer.Max(c => c.IdCustomer) + 1;
                Customer newCustomer = new Customer()
                {
                    IdCustomer = customerId,
                    Surname = null,
                    Name = UserName,
                    Phone = UserPhone,
                    Email = null
                };
                DBContext.Customer.Add(newCustomer);
            }

            foreach (Order newRegisteredOrder in UserOrders)
            {
                newRegisteredOrder.IdCustomer = customerId;
                DBContext.Order.Add(newRegisteredOrder);
                DBContext.SaveChanges();
            }
            MessageBox.Show("Заказ успешно оформлен!", "Успешно!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            UserOrders.Clear();
            cartListView.ItemsSource = null;
            cartListView.ItemsSource = UserOrders;
            totalText.Text = $"Итого: {UserOrders.Sum(o => o.FinalPrice)} руб.";
        }

        private void ExitButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
