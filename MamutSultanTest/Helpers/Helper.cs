using System.Transactions;

namespace MamutSultanTest.Helpers;

public static class Helper
{
    public static TransactionScope CreateTransactionScope(int seconds = 1)
    {
        return new TransactionScope
        (TransactionScopeOption.Required,
            new TimeSpan(0, 0, seconds),
            TransactionScopeAsyncFlowOption.Enabled
        );
    }
}