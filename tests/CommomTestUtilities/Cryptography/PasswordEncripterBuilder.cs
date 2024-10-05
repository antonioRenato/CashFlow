using CashFlow.Domain.Security.Cryptography;
using Moq;

namespace CommomTestUtilities.Cryptography
{
    public class PasswordEncripterBuilder
    {
        public static IPasswordEncripter Build()
        {
            var moq = new Mock<IPasswordEncripter>();

            moq.Setup(password => password.Encrypt(It.IsAny<string>())).Returns("!!!!Ddword");

            return moq.Object;
        }
    }
}
