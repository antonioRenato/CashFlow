using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.Get
{
    public interface IGetExpenseUseCase
    { 
        Task<ResponseExpenseJson> Execute(long id);
    }
}
