using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows;
using Warehouse.DB;
using Warehouse.Models;

namespace Warehouse.ViewModels
{
    public partial class ClientesVM : ObservableObject
    {
        private readonly AppDbContext _context;
        public ClientesVM()
        {
            _context = new AppDbContext();
            _context.Database.EnsureCreated();
            _ = LoadCustomers();
        }
        [ObservableProperty]
        private string nome;

        [ObservableProperty]
        private string tel;

        [ObservableProperty]
        private string doc;

        [ObservableProperty]
        private ObservableCollection<Customer> customers = new ObservableCollection<Customer>();

        [ObservableProperty]
        private Customer selectedCustomer;

        //comandos
        [RelayCommand]
        private async Task AddCustomer()
        {
            if (!string.IsNullOrWhiteSpace(Nome) && !string.IsNullOrWhiteSpace(Tel) && !string.IsNullOrWhiteSpace(Doc))
            {
                var newCustomer = new Customer
                {
                    Nome = Nome,
                    Tel = Tel,
                    Doc = Doc
                };
                await _context.AddAsyncData(newCustomer);
                await LoadCustomers();
                // Limpar os campos após adicionar
                CleanFields();

            }
            else
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
            }
        }

        [RelayCommand]
        private async Task RemoveCustomer()
        {
            if (SelectedCustomer != null)
            {
                await _context.DeleteAsync(SelectedCustomer);
                await LoadCustomers();
                // Limpar os campos após remover
                CleanFields();
            }
            else
            {
                MessageBox.Show("Por favor, selecione um cliente para remover.");
            }
        }

        private async Task LoadCustomers()
        {
            var list = await _context.GetAllAsync<Customer>();
            Customers.Clear();
            foreach (var customer in list)
            {
                Customers.Add(customer);
            }
        }



        private void CleanFields()
        {
            Nome = string.Empty;
            Tel = string.Empty;
            Doc = string.Empty;
        }


    }
}
