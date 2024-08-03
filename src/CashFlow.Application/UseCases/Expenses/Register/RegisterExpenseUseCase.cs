using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.Register
{
    public class RegisterExpenseUseCase
    {
        public ResponsesRegisteredExpenseJson Execute(RequestRegisterExpenseJson request)
        {
            Validate(request);

            return new ResponsesRegisteredExpenseJson();
        }

        private void Validate(RequestRegisterExpenseJson request)
        {
            var validate = new RegisterExpenseValidator();

            var result = validate.Validate(request);

            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
        }
    }
}
