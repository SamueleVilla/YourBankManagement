﻿using BankLibrary.Accounts;
using BankLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static BankLibrary.Services.Database;

namespace BankLibrary.Services
{
    public  class FileManager
    {
        private static string accountsPath  = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "BankManagement", "Accounts");

        public void SaveAccountData(IBankAccount currentAccount)
        {
            if (!Directory.Exists(accountsPath))
            {
                Directory.CreateDirectory(accountsPath);
            }

            string filePath = $@"{accountsPath}\{currentAccount.Owner.TaxCode}.csv";
            List<string> lines = new List<string>();

            // header - informazioni utente ex // Mario,Rossi,10/02/2000,MRORSS76D2023A,BankAccount
            lines.Add($"{currentAccount.Owner.FirstName}," +
                $"{currentAccount.Owner.LastName}," +
                $"{currentAccount.Owner.BithDate}," +
                $"{currentAccount.Owner.TaxCode}," +
                $"{currentAccount.GetType().Name}" +
                $"{currentAccount.MonthlyDeposit}");

            // aggiunta di tutte le transazioni dell'account
            foreach (TransactionModel t in currentAccount.AllTransactions)
            {
                lines.Add($"{t.Amount},{t.Date},{t.Note}");
            }

            // scrittura di tutte le righe sul file
            File.WriteAllLines(filePath, lines);
        }

        public static IBankAccount LoadAccountData(string taxCode)
        {
            string filePath = $@"{accountsPath}\{taxCode}.csv";

            if (File.Exists(filePath))
            {
                List<string> lines = File.ReadAllLines(filePath).ToList();

                // header - informazioni account
                string[] cols = lines[0].Split(',');
                UserModel owner = new UserModel { FirstName = cols[0], LastName = cols[1], BithDate = DateTime.Parse(cols[2]), TaxCode = cols[3] };
                AccountType type = (AccountType)Enum.Parse(typeof(AccountType), cols[4]);
                lines.RemoveAt(0);  //rimozione header file

                List<TransactionModel> allTransactions = new List<TransactionModel>();
                foreach (string line in lines)
                {
                    string[] tCols = line.Split(',');
                    allTransactions.Add(new TransactionModel(decimal.Parse(tCols[0]), DateTime.Parse(tCols[1]), tCols[2]));
                }

                switch (type)
                {
                    case AccountType.BankAccount:
                        return new BankAccount { Owner = owner, AllTransactions = allTransactions };

                    case AccountType.CreditCardAccount:
                        return new CreditCardAccount { Owner = owner, AllTransactions = allTransactions };

                    case AccountType.GiftCardAccount:
                        return new GiftCardAccount { Owner = owner, AllTransactions = allTransactions, MontlyDeposit = decimal.Parse(cols[5])};

                    case AccountType.EarningInterestAccount:
                        return new EarningInsterestAccount { Owner = owner, AllTransactions = allTransactions};

                    default:
                        throw new Exception("Impossibile creazione account");
                }

            }
            else
            {
                throw new Exception("Account non trovato! riprovare");
            }
            
        }
    }
}
