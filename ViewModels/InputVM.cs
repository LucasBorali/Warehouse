using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows;
using Warehouse.DB;
using Warehouse.Models;





namespace Warehouse.ViewModels
{
    public partial class InputVM : ObservableObject
    {

        public InputVM()
        {
            var context = new AppDbContext();
            context.Database.EnsureCreated();


            _ = LoadProducers();
            _ = LoadInputLogs();
        }

        [ObservableProperty]
        private DateTime date = DateTime.Now;

        [ObservableProperty]
        private string plate;

        [ObservableProperty]
        private ObservableCollection<Customer> producers = new ObservableCollection<Customer>();

        [ObservableProperty]
        private string producer;

        [ObservableProperty]
        private ObservableCollection<Input> inputLogs = new ObservableCollection<Input>();

        private async Task LoadProducers()
        {
            var customers = await DbExtensions.GetAllAsync<Customer>();
            Producers.Clear();
            foreach (var customer in customers) {

            Producers.Add(customer);
            }
           
        }

        private async Task LoadInputLogs()
        {
            var docks = await DbExtensions.GetAllAsync<Input>();
            InputLogs.Clear();
            foreach (var dock in docks)
            {
                InputLogs.Add(dock);
            }
        }

        [ObservableProperty]
        private string peso;

        [ObservableProperty]
        private string ticket;

        [ObservableProperty]
        private string impureza;

        [ObservableProperty]
        private string umidade;


        //Funções

        [RelayCommand]
        private async Task AddInputLog()
        {
            if (string.IsNullOrWhiteSpace(Plate) || string.IsNullOrWhiteSpace(Peso) || string.IsNullOrWhiteSpace(Ticket) || string.IsNullOrWhiteSpace(Impureza) || string.IsNullOrWhiteSpace(Umidade))
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                return;
            }
        }




    }
}
