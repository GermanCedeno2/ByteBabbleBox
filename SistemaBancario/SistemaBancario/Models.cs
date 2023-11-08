using System.Collections.Generic;

namespace BankSystem.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Account> Accounts { get; set; }
    }

    public class Account
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
