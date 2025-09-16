using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Models;
using System.Collections.ObjectModel;

namespace Warehouse.ViewModels
{
    public partial class OutputVM: ObservableObject
    {
        public OutputVM() {
            var context = new DB.AppDbContext();
            context.Database.EnsureCreated();

            _ = LoadInputLogs();

        }

        [ObservableProperty]
        private ObservableCollection<Input> inputLogs = new();

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

        [ObservableProperty]
        private Input selectedProducer;

        [ObservableProperty]
        private Input selectedticket;

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

      






    }
}
