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

namespace Praktika1_2
{
    public partial class Page2 : Page
    {
        private PunktVidachiZakazovEntities3 pvz = new PunktVidachiZakazovEntities3();

        public Page2()
        {
            InitializeComponent();

            DataGrid2.ItemsSource = pvz.Orders.ToList();
        }

        private void ButtonPage2_Right_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page3());
        }

        private void ButtonPage2_Left_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page1());
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Orders orders = new Orders();
                orders.Order_Number = Convert.ToInt32(Number.Text);
                orders.Products = Products.Text;
                orders.Order_Price = Convert.ToInt32(Price.Text);
                orders.Arrival_DateTime = Convert.ToDateTime(DateTime.Text);

                pvz.Orders.Add(orders);
                pvz.SaveChanges();

                DataGrid2.ItemsSource = pvz.Clients.ToList();
            }
            catch (Exception ex)
            {

            }
            
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DataGrid2.SelectedItem != null)
                {
                    pvz.Orders.Remove(DataGrid2.SelectedItem as Orders);
                    pvz.SaveChanges();
                    DataGrid2.ItemsSource = pvz.Orders.ToList();
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
                if (DataGrid2.SelectedItem != null)
                {
                    var selected = DataGrid2.SelectedItem as Orders;
                    selected.Order_Number = Convert.ToInt32(Number.Text);
                    selected.Products = Products.Text;
                    selected.Order_Price= Convert.ToInt32(Price.Text);
                    selected.Arrival_DateTime = Convert.ToDateTime(DateTime.Text);           
                }
                
                pvz.SaveChanges();
                DataGrid2.ItemsSource = pvz.Clients.ToList();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
