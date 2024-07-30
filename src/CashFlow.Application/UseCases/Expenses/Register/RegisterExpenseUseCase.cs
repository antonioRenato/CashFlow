using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.Register
{
    public class RegisterExpenseUseCase
    {
        public ResponsesRegisteredExpenseJson Execute(RequestRegisterExpenseJson request)
        {
            return new ResponsesRegisteredExpenseJson();
        }
    }
}
