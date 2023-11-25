namespace lab_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
           BankAccount savingsAccount = new BankAccount('S', 100, 1);
            BankAccount checkingAccount = new BankAccount('C', 200, 2);
            BankAccount moneyMarketAccount = new BankAccount('M', 1500, 3);

            savingsAccount.deposit(50);
            checkingAccount.withdrawal(50);
            moneyMarketAccount.deposit(200);
            moneyMarketAccount.withdrawal(100);

            Console.WriteLine(savingsAccount.ToString());
            Console.WriteLine(checkingAccount.ToString());
            Console.WriteLine(moneyMarketAccount.ToString());
        }
    }
}