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
        private ObservableCollection<Input> inputLogs = new ObservableCollection<Input>();

        private async Task LoadInputLogs()
        {
            var docks = await DB.DbExtensions.GetAllAsync<Input>();
            InputLogs.Clear();
            foreach (var dock in docks)
            {
                InputLogs.Add(dock);
            }
        }





    }
}
