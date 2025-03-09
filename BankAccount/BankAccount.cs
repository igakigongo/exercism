namespace BankAccount;

public class BankAccount
{
    private readonly object _lock = new();
    private decimal _balance;

    private bool IsClosed { get; set; } = true;

    public decimal Balance
    {
        get
        {
            if (IsClosed) throw new InvalidOperationException();
            lock (_lock)
            {
                return _balance;
            }
        }
        private set
        {
            lock (_lock)
            {
                _balance = value;
            }
        }
    }

    public void Open()
    {
        if (IsClosed == false)
            throw new InvalidOperationException();

        Balance = 0;
        IsClosed = false;
    }

    public void Close()
    {
        if (IsClosed)
            throw new InvalidOperationException();
        IsClosed = true;
    }

    public void Deposit(decimal change)
    {
        if (IsClosed) throw new InvalidOperationException();
        if (change <= 0) throw new InvalidOperationException();
        Balance += change;
    }

    public void Withdraw(decimal change)
    {
        if (IsClosed) throw new InvalidOperationException();
        if (change <= 0) throw new InvalidOperationException();
        if (change > Balance) throw new InvalidOperationException();

        Balance -= change;
    }
}