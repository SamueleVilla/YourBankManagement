using System;
using System.Windows;
using Google.Cloud.Firestore;

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

        // stabilimento della connessione al database
        private void ConnectToFireBaseFireStore()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + "bankmanagement.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            // connessione al database cloud di google
            FirestoreDb db = FirestoreDb.Create("bankmanagement-b4f21");
            MessageBox.Show($"Connessione riuscita: {db.ProjectId}","Message",MessageBoxButton.OK);
        }

        // evento click bottone 
        private void BtnOpenAccount_Click(object sender, RoutedEventArgs e)
        {
            openBankAccount = new OpenBankAccount();
            openBankAccount.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ConnectToFireBaseFireStore();
        }


        // evento che si verifica dopo la chiusura dell'applicazione
        private void closing_Closed(object sender, EventArgs e)
        {
           
        }

        
    }
}
