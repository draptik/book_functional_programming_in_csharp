using System;
using Functional;
using static Functional.F;

// OO solution
// public class Account
// {
//    public decimal Balance { get; private set; }

//    public Account(decimal balance) { Balance = balance; }

//    public void Debit(decimal amount)
//    {
//       if (Balance < amount)
//          throw new InvalidOperationException("Insufficient funds");

//       Balance -= amount;
//    }
// }

public class AccountState
{
    public decimal Balance { get; }
    public AccountState(decimal balance) => Balance = balance;
}

public static class Account
{
    public static Option<AccountState> Debit(this AccountState account, decimal amount)
        => (account.Balance < amount)
            ? None
            : Some(new AccountState(account.Balance - amount));
}