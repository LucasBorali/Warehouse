using MahApps.Metro.Controls;

using System.Windows;
using Warehouse.Views;

namespace Warehouse
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {

        public MainWindow()
        {
            InitializeComponent();
            this.HamburguerMenuControl.Content = new ClientesView();
        }

        private void HamburgerMenuControl_OnItemInvoked(object sender, HamburgerMenuItemInvokedEventArgs e)
        {
            if (e.InvokedItem is HamburgerMenuGlyphItem item)
            {
                switch (item.Label)
                {
                    case "Clientes":
                        this.HamburguerMenuControl.Content = new ClientesView();
                        break;
                    case "Movimentações":
                        //this.HamburguerMenuControl.Content = new MovimentacoesView();
                        break;
                }
            }


            if (!e.IsItemOptions && this.HamburguerMenuControl.IsPaneOpen)
            {
                this.HamburguerMenuControl.SetCurrentValue(HamburgerMenu.IsPaneOpenProperty, false);
            }
        }


    }
}