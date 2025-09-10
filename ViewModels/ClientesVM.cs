using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Warehouse.Models;

namespace Warehouse.ViewModels
{
    public partial class ClientesVM : ObservableObject
    {
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
        private void AddCustomer()
        {
            if (!string.IsNullOrWhiteSpace(Nome) && !string.IsNullOrWhiteSpace(Tel) && !string.IsNullOrWhiteSpace(Doc))
            {
                var newCustomer = new Customer
                {
                    Nome = Nome,
                    Tel = Tel,
                    Doc = Doc
                };
                Customers.Add(newCustomer);
                // Limpar os campos após adicionar
                CleanFields();

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
