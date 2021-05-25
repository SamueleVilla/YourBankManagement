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
        private static MainWindow mainWindow = new MainWindow();

        public OpenBankAccount()
        {
            InitializeComponent();
        }

        private void BtnOpenAccount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Name userName = new Name() { FirstName = txtbFirstName.Text, LastName = txtbLastName.Text };
                string taxCode = txtbTaxCode.Text;
                DateTime? birthDate = datePicker.SelectedDate;
                decimal initialBalance = decimal.Parse(txtbInitialBalance.Text);
                var currentUser = new User(userName, birthDate, taxCode);

                if ((bool)bankAccount.IsChecked) 
                {
                    // tipo account conto corrente
                    Database.CurrentAccount = new BankAccount(currentUser, initialBalance);
                    Database.CurrentAccount.SaveData();
                }
                else if((bool)lineOfCreditCard.IsChecked)
                {
                    Database.CurrentAccount = new LineOfCreditCard(currentUser, initialBalance);
                    Database.CurrentAccount.SaveData();
                }

                // salvataggio dei dati utente inseriti
                MessageBox.Show("Dati salvati correnttamente!", "Messaggio", MessageBoxButton.OK, MessageBoxImage.Information);

                // inizio sequenza chiusa app
                mainWindow.Close();
                mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            
        }
    }
}