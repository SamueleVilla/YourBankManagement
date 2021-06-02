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
using static BankLibrary.Services.Database;

namespace WpfAppUI
{
    /// <summary>
    /// Logica di interazione per WithDrawalWindow.xaml
    /// </summary>
    public partial class WithDrawalWindow : Window
    {
        private MainWindow mainRef = null;

        public WithDrawalWindow(MainWindow mainRef)
        {
            InitializeComponent();
            this.mainRef = mainRef;
        }

        private bool ValidateInputs(out decimal amount)
        {

            if (!decimal.TryParse(txtAmount.Text, out amount))
            {
                txtAmount.Focus();
                MessageBox.Show("Importo inserito non valido!", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtAmount.Text))
            {
                txtAmount.Focus();
                MessageBox.Show("Importo inserito non valido!", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

           
            if (string.IsNullOrEmpty(txtNote.Text)) 
            {
                txtNote.Focus();
                MessageBox.Show("Nota inserita non valida!", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;

        }

        private void btnConfirmWithDrawal_Click(object sender, RoutedEventArgs e)
        {
            decimal amount = 0;
            if(ValidateInputs(out amount))
            {
                string note = txtNote.Text;
                CurrentAccount.MakeWithDrawal(amount, DateTime.Now, note);
                MessageBox.Show("Prelievo effettuato correttamente!", "Messaggio", MessageBoxButton.OK, MessageBoxImage.Information);
                mainRef.IsEnabled = true;
                this.Close();
            }
        }

        private void btnCancelWithDrawal_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
