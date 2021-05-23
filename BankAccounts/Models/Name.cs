namespace BankAccounts.Models
{
    public struct Name
    {
        private string _firstName;
        private string _lastName;

        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }

        public User User
        {
            get => default;
            set
            {
            }
        }
    }
}