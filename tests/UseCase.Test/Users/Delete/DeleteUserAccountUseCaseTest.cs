using CashFlow.Application.UseCases.Users.Delete;
using CashFlow.Domain.Entities;
using CommomTestUtilities.Entities;
using CommomTestUtilities.LoggedUser;
using CommomTestUtilities.Repositories;
using FluentAssertions;

namespace UseCase.Test.Users.Delete
{
    public class DeleteUserAccountUseCaseTest
    {
        [Fact]
        public async Task Sucess()
        {
            var user = UserBuilder.Build();
            var useCase = CreateUseCase(user);

            var act = async () => await useCase.Execute();

            await act.Should().NotThrowAsync();
        }

        private DeleteUserAccountUseCase CreateUseCase(User user)
        {
            var repository = UserWriterOnlyRepositoryBuilder.Build();
            var loggedUser = LoggedUserBuilder.Build(user);
            var unitOfWork = UnityOfWorkBuilder.Build();

            return new DeleteUserAccountUseCase(loggedUser, repository, unitOfWork);
        }
    }
}
