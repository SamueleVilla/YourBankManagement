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

namespace WpfAppUI
{
    /// <summary>
    /// Logica di interazione per TransactionWindow.xaml
    /// </summary>
    public partial class DepositWindow : Window
    {
        public DepositWindow()
        {
            InitializeComponent();
        }

        private void btnConfirmDeposit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancelDeposit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
