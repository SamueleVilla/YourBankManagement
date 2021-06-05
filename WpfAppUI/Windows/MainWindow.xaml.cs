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
            // aggiornamento dinamico della data corrente
            txtbCurrentDate.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");

        }

        private void SetUpComponets()
        {
            txtDisplayFullName.Text = Database.CurrentAccount.Owner.FullName;
            txtDispayAccount.Text = Database.DisplayAccountType(Database.CurrentAccount.GetType());
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

        private void Window_Closed(object sender, EventArgs e)
        {   
            
        }

        private void btnDeposit_Click(object sender, RoutedEventArgs e)
        {
            DepositWindow depositWindow = new DepositWindow(this);
            depositWindow.Show();
            this.IsEnabled = false;
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
