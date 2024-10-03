using CashFlow.Application.UseCases.Users;
using CashFlow.Application.UseCases.Users.Register;
using CashFlow.Communication.Requests;
using CommomTestUtilities.Requests;
using FluentAssertions;
using FluentValidation;

namespace Validators.Tests.Users
{
    public class PasswordValidatorTest
    {
        [Theory]
        [InlineData("")]
        [InlineData("     ")]
        [InlineData(null)]
        [InlineData("a")]
        [InlineData("aaaa")]
        [InlineData("aaaaa")]
        [InlineData("aaaaaaaa")]
        [InlineData("AAAAAAAA")]
        [InlineData("Aaaaaaaa")]
        [InlineData("Aaaaaa11")]
        public void Error_Email_Empty(string password)
        {
            var validator = new PasswordValidator<RequestRegisterUserJson>();

            var result = validator.IsValid(new ValidationContext<RequestRegisterUserJson>(new RequestRegisterUserJson()), password);

            result.Should().BeFalse();
        }
    }
}
