using BankAccounts.Models;
using BankAccounts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using BankAccounts.Utils;

namespace WindowsUI
{
    /// <summary>
    /// Logica di interazione per OpenBankAccount.xaml
    /// </summary>
    public partial class OpenBankAccount : Window
    {


        public OpenBankAccount()
        {
            InitializeComponent();
        }

        private void btnOpenAccount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Name userName = new Name() { FirstName = txtbFirstName.Text, LastName = txtbLastName.Text };
                string taxCode = txtbTaxCode.Text;
                DateTime? birthDate = datePicker.SelectedDate;
                decimal initialBalance = decimal.Parse(txtbInitialBalance.Text);

                // istanza dell utente corrente
                var currentUser = new User(userName, birthDate, taxCode);
                var currentAccount = new BankAccount(currentUser, initialBalance);
                

                // salvataggio dei dati utente inseriti
                Database.SetAccount(currentAccount);
                MessageBox.Show("Dati salvati correnttamente!", "Messaggio", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}