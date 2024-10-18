using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Expenses
{
    public interface IExpenseReadOnlyRepository
    {
        Task<List<Expense>> GetAll(Entities.User user);
        Task<Expense?> Get(Entities.User user, long id);
    }
}
