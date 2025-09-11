using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows;
using Warehouse.DB;
using Warehouse.Models;

namespace Warehouse.ViewModels
{
    public partial class ClientesVM : ObservableObject
    {
        
        public ClientesVM()
        {
            var context = new AppDbContext();
            context.Database.EnsureCreated();

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

        partial void OnSelectedCustomerChanged(Customer? value)
        {
            if(value != null)
            {
                Nome = value.Nome;
                Tel = value.Tel;
                Doc = value.Doc;
            }
        }





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
                await DbExtensions.AddAsyncData(newCustomer);
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
                await DbExtensions.DeleteAsync(SelectedCustomer);
                await LoadCustomers();
                // Limpar os campos após remover
                CleanFields();
            }
            else
            {
                MessageBox.Show("Por favor, selecione um cliente para remover.");
            }
        }

        [RelayCommand]
        private async Task UpdateCustomer()
        {
            if (SelectedCustomer != null && !string.IsNullOrWhiteSpace(Nome) && !string.IsNullOrWhiteSpace(Tel) && !string.IsNullOrWhiteSpace(Doc))
            {
                SelectedCustomer.Nome = Nome;
                SelectedCustomer.Tel = Tel;
                SelectedCustomer.Doc = Doc;
                await DbExtensions.UpdateAsync(SelectedCustomer);
                await LoadCustomers();
                // Limpar os campos após atualizar
                CleanFields();
            }
            else
            {
                MessageBox.Show("Por favor, selecione um cliente e preencha todos os campos para atualizar.");
            }
        }

        private async Task LoadCustomers()
        {
            var list = await DbExtensions.GetAllAsync<Customer>();
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
            SelectedCustomer = null;
        }


    }
}
