using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Praktika1_2
{
    public partial class Page3 : Page
    {
        private PunktVidachiZakazovEntities3 pvz = new PunktVidachiZakazovEntities3();

        public Page3()
        {
            InitializeComponent();

            DataGrid3.ItemsSource = pvz.OrdersClients.ToList();
        }

        private void ButtonPage3_Left_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2());
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OrdersClients OrdersClients = new OrdersClients();
                OrdersClients.ReceivingDateTime = Convert.ToDateTime(ReceivingDateTime.Text);
                OrdersClients.ClientID = Convert.ToInt32(Client_ID.Text);
                OrdersClients.OrderID = Convert.ToInt32(Order_ID.Text);

                pvz.OrdersClients.Add(OrdersClients);
                pvz.SaveChanges();

                DataGrid3.ItemsSource = pvz.Clients.ToList();
            }
            catch (Exception ex)
            {

            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DataGrid3.SelectedItem != null)
                {
                    pvz.OrdersClients.Remove(DataGrid3.SelectedItem as OrdersClients);
                    pvz.SaveChanges();
                    DataGrid3.ItemsSource = pvz.OrdersClients.ToList();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DataGrid3.SelectedItem != null)
                {
                    var selected = DataGrid3.SelectedItem as OrdersClients;
                    selected.ReceivingDateTime = Convert.ToDateTime(ReceivingDateTime.Text);
                    selected.ClientID = Convert.ToInt32(Client_ID.Text);
                    selected.OrderID = Convert.ToInt32(Order_ID.Text);

                }

                pvz.SaveChanges();
                DataGrid3.ItemsSource = pvz.Clients.ToList();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
