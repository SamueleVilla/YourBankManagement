using BankLibrary;
using BankLibrary.Accounts;
using BankLibrary.Models;
using System;
using System.Windows;
using System.Windows.Input;
using static BankLibrary.Services.Database;

namespace WpfAppUI.Windows
{
    /// <summary>
    /// Logica di interazione per OpenAccountWindow.xaml
    /// </summary>
    public partial class OpenAccountWindow : Window
    {   
        /// <summary>
        /// Costruttore della finestra MainWindow
        /// </summary>
        public OpenAccountWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Questo metodo verifica che tutti i valori testuali inseriti (nome, cognome, codice fiscale, data nascita) siano validi
        /// </summary>
        /// <returns>
        /// Il metodo ritorna un valore booleano
        /// </returns>
        private bool ValidateInputs()
        {
            if (string.IsNullOrEmpty(txtbFirstName.Text))
            {
                MessageBox.Show("Nome inserito non valido!", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                txtbFirstName.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtbLastName.Text))
            {
                MessageBox.Show("Cognome inserito non valido!", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                txtbLastName.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtbTaxCode.Text) || txtbTaxCode.Text.Length != 16)
            {
                MessageBox.Show("Codice fiscale inserito non valido!", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                txtbTaxCode.Focus();
                return false;
            }

            if (DateTime.Today.Year - datePicker.SelectedDate.Value.Year < 18)
            {
                MessageBox.Show("L'utente deve essere maggiorenne!", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                datePicker.Focus();
                return false;
            }

            return true;

        }

        /// <summary>
        /// Questo metodo verifica che tutti i valori numerici (bilancio iniziale, deposito mensile) siano validi
        /// </summary>
        /// <param name="initialBalance"> Bilancio iniziale </param>
        /// <param name="montlyDeposit"> Deposito Mensile </param>
        /// <returns>
        /// Il metodo ritorna un valore booleano
        /// </returns>
        private bool ValidateNumbers(out decimal initialBalance, out decimal montlyDeposit)
        {
            bool result = true;

            if (!decimal.TryParse(txtbInitialBalance.Text, out initialBalance) )
            {
                txtbInitialBalance.Focus();
                MessageBox.Show("Bilancio iniziale non valido!", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                result = false;
            }

            if (txtbMontlyDeposit.IsEnabled)
            {
                if (!decimal.TryParse(txtbMontlyDeposit.Text, out montlyDeposit))
                {
                    txtbMontlyDeposit.Focus();
                    MessageBox.Show("Deposito mensile non valido!", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                    result = false;
                }
                else
                    montlyDeposit = 0;
            }
            else
                montlyDeposit = 0;

           return result;
        }

        /// <summary>
        /// Questo metodo verifca che il tipo di account selezionato sia valido 
        /// </summary>
        /// <param name="type"> Tipo account bancario </param>
        /// <returns>
        /// Il metodo ritorna un valore booleano
        /// </returns>
        private bool ValidateAccountType(out AccountType type)
        {
           
            if ((bool)bankAccount.IsChecked)
            {
                type = AccountType.BankAccount;
                return true;
            }

            else if ((bool)CreditCardAccount.IsChecked)
            {
                type = AccountType.CreditCardAccount;
                return true;
            }

            else if ((bool)EarningInterestAccount.IsChecked)
            {
                type = AccountType.EarningInterestAccount;
                return true;
            }

            else if ((bool)GiftCardAccount.IsChecked)
            {
                type = AccountType.GiftCardAccount;
                return true;
            }
            else
            {
                throw new ArgumentNullException("Inserire tipo di conto bancario");
            }


        }

        /// <summary>
        /// Gestione evento Click del bottone "Apri Conto Bancario"
        /// </summary>
        private void btnOpenAccount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                decimal monthlyDeposit;
                decimal initialBalance;
                AccountType accountType;
                
                if (ValidateInputs() && ValidateNumbers(out initialBalance, out monthlyDeposit) && ValidateAccountType(out accountType))
                {
                    string firstName = txtbFirstName.Text;
                    string lastName = txtbLastName.Text;
                    string taxCode = txtbTaxCode.Text;
                    DateTime birthDate = (DateTime)datePicker.SelectedDate;


                    // tutti i dati sono verificati -->  istanza dell' utente
                    UserModel owner = new UserModel { FirstName = firstName, LastName = lastName, TaxCode = taxCode, BithDate = birthDate };

                    // istanza dell'account bancario con il relativo tipo
                    CurrentAccount = AccountInstantiation(accountType, owner, initialBalance, monthlyDeposit);

                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();                                 
                }        
            }
            catch (Exception ex)    // nel caso venisse generata un eccezione
            {
                MessageBox.Show($"{ex.Message}", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        
        /// <summary>
        /// Gestione evento della selezione tipo account "Carta Regalo"
        /// </summary>
        private void GiftCardAccount_Checked(object sender, RoutedEventArgs e)
        {
            txtbMontlyDeposit.IsEnabled = true;  // è possibile inserire il deposito mensile
        }

        /// <summary>
        /// Gestione evento della de-selezione tipo account "Carta Regalo"
        /// </summary>
        private void GiftCardAccount_Unchecked(object sender, RoutedEventArgs e)
        {
            txtbMontlyDeposit.IsEnabled = false;   // non è più possibile inserire il deposito mensile
        }
        
   
        /// <summary>
        /// Gestione evento Click della TexBloxk "Hai già un account?"
        /// </summary>
        private void txtAlradyHaveAccount_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
        }
    }
}
