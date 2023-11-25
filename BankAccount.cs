using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace lab_8
{
    internal class BankAccount
    {
        private int Number;
        private char Type;
        private double Balance;
        private const double SavingAccountConstant = 2.4;
        private const double CheckingAccountConstant = 0.5;
        private const double MoneyMarketAccountConstant = 8.00;

        public BankAccount(char type, double initialDeposit, int accountNumber)
        {
            Type = type;
            Balance = initialDeposit;
            Number = accountNumber;
            if (type == 'S' && initialDeposit >= 5)
            {
                Type = 'S';
                Balance = initialDeposit;
            }
            else if (type == 'M' && initialDeposit >= 1000)
            {
                Type = 'M';
                Balance = initialDeposit;
            }
            else
            {
                Type = 'C'; // Default to checking account if conditions are not met
                Balance = initialDeposit;
            }
        }

        // Copy Constructor
        public BankAccount(BankAccount typeOf)
        {
            Number = typeOf.Number;
            Type = typeOf.Type;
            Balance = typeOf.Balance;
        }

        public int getAccountNumber()
        {
            return Number;
        }

        public double getAccountBalance() 
        { 
            return Balance; 
        }

        public string getAccountTypeAsAString()
        {
            if(Type == 'S')
            {
                return "Savings Account";
            }
            else if (Type == 'C')
            {
                return "Checkings Account";
            }
            else
            {
                return "Money Marketing Account";
            }
        }

        public bool deposit(double amount)
        {
            if(amount <=0)
            {
                return false;
            }
            if (Type == 's' && amount < 5)
            {
                return false;
            }
            Balance += amount;
            return true;
        }

        public bool withdrawal(double amount)
        {
            if (amount <= 0 || amount > Balance)
            {
                return false;
            }

            if (Type == 'S' && (Balance - amount) < 5)
            {
                return false; // Withdrawal cannot make savings account balance go below $5
            }

            // Additional validation logic if needed

            Balance -= amount;
            return true;
        }

        public double monthlyInterest()
        {
            double addedInterest = 0;
            double interestRate = 0;
            if(Type == 'S')
            {
                addedInterest = Balance * (SavingAccountConstant/100);
                Balance += addedInterest;
                interestRate = SavingAccountConstant;
            }
            else if(Type == 'C')
            {
                addedInterest = Balance * (CheckingAccountConstant / 100);
                Balance += addedInterest;
                interestRate = CheckingAccountConstant;
            }
            else //MMA Account
            {
                addedInterest = Balance * (MoneyMarketAccountConstant / 100);
                Balance += addedInterest;
                interestRate = MoneyMarketAccountConstant;
            }
            return interestRate;
        }

        public override string ToString()
        {
            string msg = "";
            msg += $"Account Number: {Number}\n";
            msg += $"Account Type: {getAccountTypeAsAString()}\n";
            msg += $"Current Balance: ${Math.Round(Balance, 2)} \n";
            msg += $"Current Monthly Interest Rate: {monthlyInterest()}% \n ";
            return msg;
        }
    }
}
