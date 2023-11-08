using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using BankSystem.Data;
using BankSystem.Models;

class Program
{
    static void Main()
    {
        try
        {
            using (var context = new BankDbContext())
            {
                // Create a new user with accounts
                var user = new User { Name = "John Doe" };
                user.Accounts = new List<Account>
                {
                    new Account { AccountNumber = "123456", Balance = 1000 },
                    new Account { AccountNumber = "789012", Balance = 500 }
                };

                context.Users.Add(user);
                context.SaveChanges();

                // Display users and their accounts
                var users = context.Users.Include(u => u.Accounts).ToList();
                foreach (var u in users)
                {
                    Console.WriteLine($"User: {u.Name}");
                    foreach (var account in u.Accounts)
                    {
                        Console.WriteLine($"  Account: {account.AccountNumber}, Balance: {account.Balance}");
                    }
                }
            }
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine("A database update error occurred.");
            // Iterate through inner exceptions to get more details
            Exception innerException = ex;
            while (innerException.InnerException != null)
            {
                innerException = innerException.InnerException;
                Console.WriteLine($"Inner Exception: {innerException.Message}");
            }
        }
        catch (SqliteException sqlEx) // This handles SQLite-specific exceptions
        {
            Console.WriteLine("SQLite Exception: " + sqlEx.Message);
        }
        catch (Exception generalEx) // Handle any other exceptions
        {
            Console.WriteLine("An error occurred: " + generalEx.Message);
        }
    }
}
