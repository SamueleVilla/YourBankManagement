using BankAccounts;
using BankAccounts.Utils;
using System;
using System.Collections.Generic;
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

namespace WindowsUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static BankAccount currentAccount;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOpenAccount_Click(object sender, RoutedEventArgs e)
        {
            new OpenBankAccount().Show();
            this.IsEnabled = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // acquisizione dati account
            if (Directory.Exists(Database.AccountsPath))
            {
                var accounts = Directory.GetFiles(Database.AccountsPath);
                currentAccount = Database.GetAccount(accounts[0]);
            }

            // set all things here
            txtbFullName.Text = currentAccount.Owner.FullName;
            txtbTaxCode.Text = currentAccount.Owner.TaxCode;
            txtbBirthDate.Text = currentAccount.Owner.BirthDate.Value.ToString("dd/MM/yyyy");
        }
    }
}
