using BankLibrary;
using BankLibrary.Accounts;
using BankLibrary.Models;
using BankLibrary.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfAppUI
{
    /// <summary>
    /// Logica di interazione per AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        
      

        public AuthWindow()
        {
            InitializeComponent();

        }
  
        private void btnOpenAccount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                decimal monthlyDeposit;
                string firstName = txtbFirstName.Text;
                string lastNAme = txtbLastName.Text;
                string taxCode = txtbTaxCode.Text;
                DateTime birthDate = datePicker.SelectedDate.Value.ToUniversalTime();
                decimal initialBalnce = decimal.Parse(txtbInitialBalance.Text);

                if (txtbMontlyDeposit.IsVisible)
                    monthlyDeposit = decimal.Parse(txtbMontlyDeposit.Text);
                else
                    monthlyDeposit = 0;


                if (ValidateInputs(firstName, lastNAme, taxCode, birthDate))
                {
                    // dati confermati - istanza dell account
                    UserModel owner = new UserModel { FirstName = firstName, LastName = lastNAme, TaxCode = taxCode, BithDate = birthDate };

                    var result = GetAccountType();
                    if (result == AccountType.BankAccount)
                        Database.CurrentAccount = new BankAccount(owner, initialBalnce);
                    else if (result == AccountType.CreditCardAccount)
                        Database.CurrentAccount = new CreditCardAccount(owner, initialBalnce);
                    else if (result == AccountType.EarningInterestAccount)
                        Database.CurrentAccount = new EarningInsterestAccount(owner, initialBalnce);
                    else if (result == AccountType.GiftCardAccount)
                        Database.CurrentAccount = new GiftCardAccount(owner, initialBalnce, monthlyDeposit);

                    Console.WriteLine("Dati Salvati Correttamente");
                    new MainWindow().Show();
                    this.Close();
                                     
                }        
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private bool ValidateInputs(string firstName, string lastName, string TaxCode, DateTime birth)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                MessageBox.Show("Nome inserito non valido!", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                txtbFirstName.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(lastName))
            {
                MessageBox.Show("Cognome inserito non valido!", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                txtbLastName.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(TaxCode) || TaxCode.Length != 16)
            {
                MessageBox.Show("Codice fiscale inserito non valido!", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                txtbTaxCode.Focus();
                return false;
            }

            if (DateTime.Today.Year - birth.Year < 18)
            {
                MessageBox.Show("L'utente deve essere maggiorenne!", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                datePicker.Focus();
                return false;
            }
            
            return true;

        }

        private AccountType GetAccountType()
        {

            if ((bool)bankAccount.IsChecked)
            {
                return AccountType.BankAccount;
            }

            else if ((bool)CreditCardAccount.IsChecked)
            {
                return AccountType.CreditCardAccount;
            }

            else if ((bool)EarningInterestAccount.IsChecked)
            {
                return AccountType.EarningInterestAccount;
            }

            else if ((bool)GiftCardAccount.IsChecked)
            {
                return AccountType.GiftCardAccount;
            }
            else
            {
                throw new ArgumentNullException("Inserire tipo di conto bancario");
            }


        }

        private void GiftCardAccount_Checked(object sender, RoutedEventArgs e)
        {
            txtbMontlyDeposit.Visibility = Visibility.Visible;
        }

        private void GiftCardAccount_Unchecked(object sender, RoutedEventArgs e)
        {
            txtbMontlyDeposit.Visibility = Visibility.Hidden;
        }

        private void btnHaveAccount_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAlradyHaveAccount_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
        }
    }
}
