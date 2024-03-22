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
    public partial class Page1 : Page
    {
        private PunktVidachiZakazovEntities3 pvz = new PunktVidachiZakazovEntities3 ();

        public Page1()
        {
            InitializeComponent();

            DataGrid1.ItemsSource = pvz.Clients.ToList ();
        }

        private void ButtonPage1_Right_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2());
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(DataGrid1.SelectedItem != null)
                {
                    pvz.Clients.Remove(DataGrid1.SelectedItem as Clients);
                    pvz.SaveChanges();
                    DataGrid1.ItemsSource = pvz.Clients.ToList();
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DataGrid1.SelectedItem != null)
                {
                    var selected = DataGrid1.SelectedItem as Clients;
                    selected.ClientSurname = Surname.Text;
                    selected.ClientName = Name.Text;
                    selected.ClientMiddleName = Middlename.Text;
                    selected.PhoneNumber = PhoneNumber.Text;
                    selected.Email = Email.Text;
                }

                pvz.SaveChanges();
                DataGrid1.ItemsSource = pvz.Clients.ToList();
            }
            catch (Exception ex)
            {

            }
        }

        private void AddButton_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Clients clients = new Clients();
                clients.ClientSurname = Surname.Text;
                clients.ClientName = Name.Text;
                clients.ClientMiddleName = Middlename.Text;
                clients.PhoneNumber = PhoneNumber.Text;
                clients.Email = Email.Text;

                pvz.Clients.Add(clients);
                pvz.SaveChanges();

                DataGrid1.ItemsSource = pvz.Clients.ToList();
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
