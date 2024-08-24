using CashFlow.Communication.Responses;
using CashFlow.Domain.Repositories.Expenses;

namespace CashFlow.Application.UseCases.Expenses.GetAll
{
    public class GetAllExpenseUseCase : IGetAllExpenseUseCase
    {
        private readonly IExpenseRepository _repository;
        
        public GetAllExpenseUseCase(IExpenseRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseExpensesJson> Execute()
        {

        }
    }
}
