using System.Transactions;

namespace ProcessManagement.Common.Helpers
{
    public static class TransactionHelper
    {
        public static TransactionScope CreateTransaction() => new(TransactionScopeAsyncFlowOption.Enabled);
    }
}
