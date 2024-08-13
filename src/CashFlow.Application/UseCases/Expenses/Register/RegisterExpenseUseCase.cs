using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Expenses.Register
{
    public class RegisterExpenseUseCase
    {
        public ResponsesRegisteredExpenseJson Execute(RequestRegisterExpenseJson request)
        {
            Validate(request);

            var entity = new Expense
            {
                Amount = request.Amount,
                Date = request.Date,
                Description = request.Description,
                Title = request.Title,
                PaymentType = (Domain.Enums.PaymentType)request.PaymentType,
            };

            return new ResponsesRegisteredExpenseJson();
        }

        private void Validate(RequestRegisterExpenseJson request)
        {
            var validate = new RegisterExpenseValidator();

            var result = validate.Validate(request);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
