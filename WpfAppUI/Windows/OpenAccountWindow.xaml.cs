using BankLibrary.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Linq;
using BankLibrary.Models;

namespace WpfAppUI.Windows
{
    /// <summary>
    /// Logica di interazione per OpenAccountWindow.xaml
    /// </summary>
    public partial class OpenAccountWindow : Window
    {

        private static List<FileModel> AllAccountsFiles = new List<FileModel>();

        private List<FileModel> LoadAllAccountsFiles(string accountsPath)
        {
            List<FileModel> files = new List<FileModel>();
            if (!Directory.Exists(accountsPath))
            {
                Directory.CreateDirectory(accountsPath);
            }

            foreach (string file in Directory.GetFiles(accountsPath))
            {
                FileModel model = new FileModel { DirectoryPath = accountsPath, FileName = Path.GetFileNameWithoutExtension(file), Extension = Path.GetExtension(file) };
                files.Add(model);
            }

            return files;
        }

        public OpenAccountWindow()
        {
            InitializeComponent();
            cbSelectAccount.ItemsSource = LoadAllAccountsFiles(Database.DataBaseService.AccountsPath);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            CreateAccountWindow createAccount = new CreateAccountWindow();
            createAccount.Show();
            this.Close();
        }

        private void btnOpenAccount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FileModel fileModel = (FileModel)cbSelectAccount.SelectedItem;
                Database.CurrentAccount = Database.DataBaseService.LoadAccountData(fileModel.FileName);
                MessageBox.Show($"Benvenuto, {Database.CurrentAccount.Owner.FullName}!", "Messaggio", MessageBoxButton.OK, MessageBoxImage.Information);

                MainWindow main = new MainWindow();
                main.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
    }
}
