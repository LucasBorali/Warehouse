using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows;
using Warehouse.Models;
using Warehouse.DB;

namespace Warehouse.ViewModels
{
    public partial class OutputVM : ObservableObject
    {
        public OutputVM()
        {
            var context = new DB.AppDbContext();
            context.Database.EnsureCreated();

            _ = LoadInputLogs();
            _ = LoadOutputLogs();

        }

        [ObservableProperty]
        private ObservableCollection<Input> inputLogs = new();

        [ObservableProperty]
        private ObservableCollection<Output> outputLogs = new();

        [ObservableProperty]
        private ObservableCollection<string> producers = new();

        [ObservableProperty]
        private ObservableCollection<string> tickets = new();



        private async Task LoadInputLogs()
        {
            var docks = await DB.DbExtensions.GetAllAsync<Input>();
            InputLogs.Clear();
            foreach (var dock in docks)
            {
                InputLogs.Add(dock);
            }

            Producers = new ObservableCollection<string>(InputLogs.Select(i => i.Producer).Distinct());


        }

        private async Task LoadOutputLogs()
        {
            var docks = await DB.DbExtensions.GetAllAsync<Output>();
            OutputLogs.Clear();
            foreach (var dock in docks)
            {
                OutputLogs.Add(dock);
            }
        }

        [ObservableProperty]
        private string selectedProducer;

        [ObservableProperty]
        private string selectedticket;

        partial void OnSelectedProducerChanged(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                var filteredTickets = InputLogs
                    .Where(i => i.Producer == value)
                    .Select(i => i.Ticket)
                    .Distinct();
                Tickets = new ObservableCollection<string>(filteredTickets);
            }
            else
            {
                Tickets.Clear();
            }
        }

        [ObservableProperty]
        private DateTime date = DateTime.Now;

        [ObservableProperty]
        private string plate;

        [ObservableProperty]
        private string peso;

        [ObservableProperty]
        private string buyer;




        [RelayCommand]
        private async Task AddOutputLog()
        {
            if (SelectedProducer == null || Selectedticket == null || string.IsNullOrWhiteSpace(Plate) || string.IsNullOrWhiteSpace(Peso) || string.IsNullOrWhiteSpace(Buyer))
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                return;
            }
            var finalDate = Date.Date == DateTime.Today ? DateTime.Now : Date;

            var newOutput = new Output
            {
                Date = finalDate,
                Ticket = Selectedticket,
                Plate = Plate,
                Peso = Peso,
                Buyer = Buyer
            };
            await DbExtensions.AddAsyncData(newOutput);
            await LoadOutputLogs();
            await LoadInputLogs();

            MessageBox.Show("Saída registrada com sucesso!");
            ClearFields();
        }


        private void ClearFields()
        {
            SelectedProducer = string.Empty;
            Selectedticket = string.Empty;
            Plate = string.Empty;
            Peso = string.Empty;
            Buyer = string.Empty;
            Date = DateTime.Now;
        }









    }
}
