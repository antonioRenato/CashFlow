using CashFlow.Application.UseCases.Login;
using CashFlow.Communication.Requests;
using CashFlow.Domain.Entities;
using CommomTestUtilities.Cryptography;
using CommomTestUtilities.Entities;
using CommomTestUtilities.Repositories;
using CommomTestUtilities.Token;
using FluentAssertions;

namespace UseCase.Test.Login.DoLogin
{
    public class DoLoginUseCaseTest
    {
        [Fact]
        public async Task Sucess()
        {
            var user = UserBuilder.Build();

            var request = RequestLoginJsonBuilder.Build();
            var useCase = CreateUseCase(user);

            var result = await useCase.Execute(request);

            result.Should().NotBeNull();
            result.Name.Should().Be(user.Name);
            result.Token.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        public async Task Error_User_Not_Found()
        {

        }

        [Fact]
        public async Task Error_Password_Not_Match()
        {

        }

        private DoLoginUseCase CreateUseCase(User user)
        {
            var passwordEncripter = PasswordEncripterBuilder.Build();
            var tokenGenerator = JwtTokenGeneratorBuilder.Build();
            var readRepository = new UserReadOnlyRepositoryBuilder().GetUserByEmail(user).Build();

            return new DoLoginUseCase(readRepository, passwordEncripter, tokenGenerator);
        }
    }
}
