using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Expenses
{
    public interface IExpensesUpdateOnlyRepository
    {
        Task<Expense?> Get(long id);
        void Update(Expense expense);
    }
}
