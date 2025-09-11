using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows;
using Warehouse.DB;
using Warehouse.Models;





namespace Warehouse.ViewModels
{
    public partial class DockVM : ObservableObject
    {

        public DockVM()
        {
            var context = new AppDbContext();
            context.Database.EnsureCreated();

            _ = LoadProducers();
            _ = LoadDockLogs();
        }

        [ObservableProperty]
        private ObservableCollection<string> transactionTypes = new ObservableCollection<string>
        {
            "Entrada",
            "Saída",
        };

        [ObservableProperty]
        private string selectedTransactionType;

        [ObservableProperty]
        private DateTime date = DateTime.Now;

        [ObservableProperty]
        private string plate;

        [ObservableProperty]
        private ObservableCollection<Customer> producers = new ObservableCollection<Customer>();

        [ObservableProperty]
        private ObservableCollection<Dock> dockLogs = new ObservableCollection<Dock>();

        private async Task LoadProducers()
        {
            var customers = await DbExtensions.GetAllAsync<Customer>();
            Producers.Clear();
            foreach (var customer in customers) {

            Producers.Add(customer);
            }
           
        }

        private async Task LoadDockLogs()
        {
            var docks = await DbExtensions.GetAllAsync<Dock>();
            DockLogs.Clear();
            foreach (var dock in docks)
            {
                DockLogs.Add(dock);
            }
        }





        [ObservableProperty]
        private string peso;

        [ObservableProperty]
        private string ticket;

        //Opcionais

        [ObservableProperty]
        private string buyer;

        [ObservableProperty]
        private string impureza;

        [ObservableProperty]
        private string umidade;




    }
}
