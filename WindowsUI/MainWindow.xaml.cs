using BankAccounts;
using BankAccounts.Utils;
using Microsoft.Win32;
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
        // istanza della finestra {openBankAccount}
        private static OpenBankAccount openBankAccount;

        //costruttore della classe 
        public MainWindow()
        {
            InitializeComponent();
        }

        // evento click bottone 
        private void BtnOpenAccount_Click(object sender, RoutedEventArgs e)
        {
            openBankAccount = new OpenBankAccount();
            openBankAccount.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // se la directory non esiste
            if (!Directory.Exists(Database.AccountsPath))
            {
                // creazione della directory
                Directory.CreateDirectory(Database.AccountsPath);
            }
            // se la directory non esiste
            if (!Directory.Exists(Database.LastOpenedPath))
            {
                Directory.CreateDirectory(Database.LastOpenedPath);
                File.CreateText(Database.LastOpenedFilePath).Close();
            }

            try
            {
                LoadLastOpenedAccount();
                SetAccountData();
            }
            catch (FileLoadException)
            {
                // il file è vuoto nessun ultimo account aperto 
                // Creazione nuvo account
                openBankAccount.Show();
            }
        }

        
        // evento che si verifica dopo la chiusura dell'applicazione
        private void closing_Closed(object sender, EventArgs e)
        {
            // salvare ultimo account utilizzato nel file temp
            File.WriteAllText($@"{Database.LastOpenedFilePath}"
                ,Database.CurrentAccount.AccountNumber);
        }

        private void LoadLastOpenedAccount()
        {
            // lettura dal file l'indetificativo dell'ultimo account aperto {Number}
            var lastAccountNumber = File.ReadAllText($"{Database.LastOpenedFilePath}");
            if (string.IsNullOrEmpty(lastAccountNumber))
            {
                throw new FileLoadException(); // nel caso il file fosse vuoto
            }
            else
            {
                Database.CurrentAccount = Database.GetAccount($@"{Database.AccountsPath}\{lastAccountNumber}.csv");
            }          
        }

        private void SetAccountData()
        {
            txtbBirthDate.Text = Database.CurrentAccount.Owner.BirthDate.Value.ToString("dd/MM/yyyy");
            txtbFullName.Text = Database.CurrentAccount.Owner.FullName;
            txtbTaxCode.Text = Database.CurrentAccount.Owner.TaxCode;
        }
    }
}
