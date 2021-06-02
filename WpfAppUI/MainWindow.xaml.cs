using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
using BankLibrary;
using BankLibrary.Models;
using BankLibrary.Services;
namespace WpfAppUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static List<TransactionModel> dislayAccountTransactions = null;

        public MainWindow()
        {
            InitializeComponent();
            SetUpComponets();

            RefreshData();
        }

        private void SetUpComponets()
        {
            txtDisplayFullName.Text = Database.CurrentAccount.Owner.FullName;
            txtDispayAccount.Text = Database.GetAccountType(Database.CurrentAccount.GetType());
            txtDisplayTaxCode.Text = Database.CurrentAccount.Owner.TaxCode;
            txtDisplayDate.Text = Database.CurrentAccount.Owner.BithDate.ToShortDateString();
        }

        private void RefreshData()
        {
            dislayAccountTransactions = Database.CurrentAccount.AllTransaction;
            ListBox.ItemsSource = dislayAccountTransactions;
            ICollectionView wiew = CollectionViewSource.GetDefaultView(ListBox.ItemsSource);
            wiew.Refresh();
            
        }

        private void Window_Closed(object sender, EventArgs e)
        {   
            
        }

        private void btnDeposit_Click(object sender, RoutedEventArgs e)
        {
            new DepositWindow().Show();
        }

        private void btnSimulateMonth_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnWithDrawal_Click(object sender, RoutedEventArgs e)
        {
            WithDrawalWindow drawalWindow = new WithDrawalWindow(this);
            drawalWindow.Show();
            this.IsEnabled = false;
        }

        private void Window_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            RefreshData();
        }
    }
}
