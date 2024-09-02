using CashFlow.Application.UseCases.Expenses;
using CashFlow.Communication.Enums;
using CashFlow.Exception;
using CommomTestUtilities.Requests;
using FluentAssertions;

namespace Validators.Tests.Expenses.Register
{
    public class RegisterExpenseValidatorTests
    {
        [Fact]
        public void Sucess()
        {
            //Arrange
            var validator = new ExpenseValidator();
            var request = RequestRegisterExpenseJsonBuilder.Build();

            //Act
            var result = validator.Validate(request);

            //Assert
            result.IsValid.Should().BeTrue();
        }
        
        [Theory]
        [InlineData("            ")]
        [InlineData("")]
        [InlineData(null)]
        public void ErrorTitleEmpty(string title)
        {
            //Arrange
            var validator = new ExpenseValidator();
            var request = RequestRegisterExpenseJsonBuilder.Build();
            request.Title = title;

            //Act
            var result = validator.Validate(request);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.TITLE_REQUIRED));
        }

        [Fact]
        public void ErrorDateInvalid() 
        {
            //Arrange
            var validator = new ExpenseValidator();
            var request = RequestRegisterExpenseJsonBuilder.Build();

            request.Date = DateTime.Now.AddDays(5);

            //Act
            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.EXPENSES_NO_FUTURE));
        }

        [Fact]
        public void ErrorPaymentTypeInvalid()
        {
            //Arrange
            var validator = new ExpenseValidator();
            var request = RequestRegisterExpenseJsonBuilder.Build();

            request.PaymentType = (PaymentType)700;

            //Act
            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.PAYMENT_TYPE_INVALID));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-4)]
        public void ErrorAmountInvalid(decimal amount)
        {
            //Arrange
            var validator = new ExpenseValidator();
            var request = RequestRegisterExpenseJsonBuilder.Build();

            request.Amount = amount;

            //Act
            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.AMOUNT_MUST_THAN_ZERO));
        }
    }
}
