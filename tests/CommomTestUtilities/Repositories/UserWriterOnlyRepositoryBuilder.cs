using CashFlow.Domain.Repositories.User;
using Moq;

namespace CommomTestUtilities.Repositories
{
    public class UserWriterOnlyRepositoryBuilder
    {
        public static IUserWriteOnlyRepository Build()
        {
            var mock = new Mock<IUserWriteOnlyRepository>();

            return mock.Object;
        }
    }
}
