using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.GetAll
{
    public interface IGetAllExpenseUseCase
    {
        async Task<ResponseExpensesJson> Execute();
    }
}
