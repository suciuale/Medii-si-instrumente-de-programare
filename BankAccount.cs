using System;

namespace Bank
{
    public class BankAccount
    {
        public string CustomerName { get; set; }
        public double Balance { get; private set; }

        public BankAccount(string customerName, double initialBalance)
        {
            if (initialBalance < 0)
                throw new ArgumentException("Initial balance cannot be negative");
            CustomerName = customerName;
            Balance = initialBalance;
        }

        public void Debit(double amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount), amount, "Debit amount must be greater than zero");
            if (amount > Balance)
                throw new InvalidOperationException("Debit amount exceeds available balance");
            Balance -= amount;
        }

        public void Credit(double amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount), amount, "Credit amount must be greater than zero");
            Balance += amount;
        }
    }
}

