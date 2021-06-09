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
using System.Windows.Threading;

namespace WpfAppUI.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer dispatcherTimer = new DispatcherTimer();

        private static List<TransactionModel> dislayAccountTransactions = null;

        public MainWindow()
        {
            TimerStart();
            InitializeComponent();
            SetUpComponets();     
            RefreshData();
        }


        private void TimerStart()
        {
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            //aggiornamento dinamico della data corrente
            txtbCurrentDate.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
        }

        /// <summary>
        ///  Questo metodo restituisce il nome del tipo di account instanziato
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string DisplayAccountType(Type type)
        {
            AccountType result = (AccountType)Enum.Parse(typeof(AccountType), type.Name);
            switch (result)
            {
                case AccountType.BankAccount:
                    return "Conto Corrente";

                case AccountType.CreditCardAccount:
                    return "Carta di Credito";

                case AccountType.EarningInterestAccount:
                    return "Conto con Interesse";

                case AccountType.GiftCardAccount:
                    return "Carta Regalo";

                default:
                    throw new ArgumentOutOfRangeException(nameof(type), "Tipo account non definito");
            }
        }

        private void SetUpComponets()
        {
            txtDisplayFullName.Text = Database.CurrentAccount.Owner.FullName;
            txtDispayAccount.Text = DisplayAccountType(Database.CurrentAccount.GetType());
            txtDisplayTaxCode.Text = Database.CurrentAccount.Owner.TaxCode;
            txtDisplayDate.Text = Database.CurrentAccount.Owner.BithDate.ToShortDateString();
        }

        private void RefreshData()
        {
            txtbToatDrawals.Text = Database.CurrentAccount.TotalDrawals.ToString();
            txtbTotalDeposit.Text = Database.CurrentAccount.TotalDeposits.ToString();
            txtbCurrentBalance.Text = Database.CurrentAccount.Balance.ToString();
            dislayAccountTransactions = Database.CurrentAccount.AllTransactions;
            ListBox.ItemsSource = dislayAccountTransactions;
            ICollectionView wiew = CollectionViewSource.GetDefaultView(ListBox.ItemsSource);
            wiew.Refresh();
            
        }

        private void btnDeposit_Click(object sender, RoutedEventArgs e)
        {
            DepositWindow depositWindow = new DepositWindow(this);
            depositWindow.Show();
            this.IsEnabled = false;
        }

        private void btnSimulateMonth_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Database.CurrentAccount.PerformMonthEndTransactions();
                Database.DatabaseServices.SaveAccountData(Database.CurrentAccount);
                MessageBox.Show("Oprazione di fine messe effettuata!","Avviso",MessageBoxButton.OK,MessageBoxImage.Warning);
                RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Avviso", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
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

        private void btnExitAccount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Database.DatabaseServices.SaveAccountData(Database.CurrentAccount);
                Database.CurrentAccount = null;
                CreateAccountWindow createAccount = new CreateAccountWindow();
                createAccount.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Avviso", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
