using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary.Models
{
    public class FileModel
    {
        /// <summary>
        /// Proprietà Percorso cartella contenente il file
        /// </summary>
        public string DirectoryPath { get; set; }
        /// <summary>
        /// Proprietà Nome del file
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// Proprietà Esstensione del file
        /// </summary>
        public string Extension { get; set; }
    }
}
