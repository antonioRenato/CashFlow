using CashFlow.Application.UseCases.Users.Register;
using CommomTestUtilities.Cryptography;
using CommomTestUtilities.Mapper;
using CommomTestUtilities.Repositories;
using CommomTestUtilities.Requests;
using CommomTestUtilities.Token;
using FluentAssertions;

namespace UseCase.Test.Users.Register
{
    public class RegisterUserUseCaseTest
    {
        [Fact]
        public async Task Sucess()
        {
            var request = RequestRegisterUserJsonBuilder.Build();
            var useCase = CreateUseCase();

            var result = await useCase.Execute(request);

            result.Should().NotBeNull();
            result.Name.Should().Be(request.Name);
            result.Token.Should().NotBeNullOrWhiteSpace();
        }

        private RegisterUserUseCase CreateUseCase()
        {
            var mapper = MapperBuilder.Build();
            var unityOfWork = UnityOfWorkBuilder.Build();
            var writeRepository = UserWriterOnlyRepositoryBuilder.Build();
            var passwordEncripter = PasswordEncripterBuilder.Build();
            var tokenGenerator = JwtTokenGeneratorBuilder.Build();

            return new RegisterUserUseCase(mapper, passwordEncripter, null, writeRepository, tokenGenerator, unityOfWork);
        }
    }


}
