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
    public partial class OrderWindow : Window
    {
        private Service orderService;

        public OrderWindow(Service serviceToOrder)
        {
            InitializeComponent();
            placeListView.ItemsSource = DBContext.Studio.ToList();
            workerListView.ItemsSource = DBContext.Worker.Where(w => w.IdRole == 1).ToList();

            orderService = serviceToOrder;
        }

        private void AddOrderClick(object sender, RoutedEventArgs e)
        {
            if (workerListView.SelectedItem is Worker && placeListView.SelectedItem is Studio)
            {
                Order newOrder = new Order()
                {
                    IdService = orderService.IdService,
                    DateTime = DateTime.Now,
                    IdDiscount = null,
                    FinalPrice = orderService.Price,
                    IdWorker = (workerListView.SelectedItem as Worker).IdWorker
                };
                UserOrders.Add(newOrder);
                MessageBox.Show("Характеристики заказа выбраны!", "Успешно!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                MessageBox.Show("Выберите фотографа и место фотосесии!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            this.Close();
        }
    }
}
