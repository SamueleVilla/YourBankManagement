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
        public MainWindow()
        {
            InitializeComponent();
            SetUpComponets();

            Database.CurrentAccount.MakeDeposit(20, DateTime.Now, "Vincita alle macchinette");
            Database.CurrentAccount.MakeDeposit(50, DateTime.Now, "Mancia della prof");
            Database.CurrentAccount.MakeDeposit(50, DateTime.Now, "Mancia della prof");
            Database.CurrentAccount.MakeDeposit(50, DateTime.Now, "Mancia della prof");
            Database.CurrentAccount.MakeDeposit(50, DateTime.Now, "Mancia della prof");
            Database.CurrentAccount.MakeDeposit(50, DateTime.Now, "Mancia della prof");
            Database.CurrentAccount.MakeDeposit(50, DateTime.Now, "Mancia della prof");
            Database.CurrentAccount.MakeDeposit(50, DateTime.Now, "Mancia della prof");
            Database.CurrentAccount.MakeDeposit(20, DateTime.Now, "Spesa giornaliera");

            LoadAllTransactions();


        }

        private void SetUpComponets()
        {
            txtDisplayFullName.Text = Database.CurrentAccount.Owner.FullName;
            txtDispayAccount.Text = Database.GetAccountType(Database.CurrentAccount.GetType());
            txtDisplayTaxCode.Text = Database.CurrentAccount.Owner.TaxCode;
            txtDisplayDate.Text = Database.CurrentAccount.Owner.BithDate.ToShortDateString();
            txtDisplayID.Text = Database.CurrentAccount.AccountNumeber;
        }

        private void LoadAllTransactions()
        {
            List<TransactionModel> allTrasactions = Database.CurrentAccount.AllTransaction;
            ListBox.ItemsSource = allTrasactions;
        }

        private void Window_Closed(object sender, EventArgs e)
        {   
            var accountspath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "BankManagement","Accounts");
            if (!Directory.Exists(accountspath))
                Directory.CreateDirectory(accountspath);

            var filePath = System.IO.Path.Combine(accountspath, $"{Database.CurrentAccount.AccountNumeber}.txt");
            
            using (FileStream fs = new FileStream(filePath,FileMode.Append))
            {
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine($"{Database.CurrentAccount.AccountNumeber} - {Database.CurrentAccount.Owner.ToString()}");
                sw.Close();
            }

            MessageBox.Show($"Dati salvati sul file!\n\n{filePath}","Messaggio",MessageBoxButton.OK,MessageBoxImage.Information);
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
            new WithDrawalWindow().Show();
        }
    }
}
