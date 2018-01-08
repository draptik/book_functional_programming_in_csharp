using System;
using Functional;
using static Functional.F;
using Scratch;

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

public interface IRepository<T>
{
    Option<T> Get(Guid id);
    void Save(Guid id, T t);
}

interface ISwiftService
{
    void Wire(MakeTransfer transfer, AccountState account);
}

public class MakeTransfer
{
    public readonly decimal Amount;

    public Guid DebitedAccountId { get; }
}

public class MakeTransferController //: Controller
{
    IValidator<MakeTransfer> validator;
    IRepository<AccountState> accounts;
    ISwiftService swift;

    Func<MakeTransfer, MakeTransfer> Normalize = transfer => transfer;

    public void MakeTransfer(MakeTransfer transfer)
        => Some(transfer)
            .Map(Normalize)
            .Where(validator.IsValid)
            .ForEach(Book);

    void Book(MakeTransfer transfer)
        => accounts
            .Get(transfer.DebitedAccountId)
            .Bind(account => account.Debit(transfer.Amount))
            .ForEach(newState =>
                {
                    accounts.Save(transfer.DebitedAccountId, newState);
                    swift.Wire(transfer, newState);
                });

}

public interface IValidator<T>
{
    bool IsValid(T t);
}