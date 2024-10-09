using CashFlow.Domain.Security.Cryptography;
using Moq;

namespace CommomTestUtilities.Cryptography
{
    public class PasswordEncrypterBuilder
    {
        private readonly Mock<IPasswordEncripter> _mock;

        public PasswordEncrypterBuilder()
        {
            _mock = new Mock<IPasswordEncripter>();

            _mock.Setup(password => password.Encrypt(It.IsAny<string>())).Returns("!!!!Ddword");
        }

        public PasswordEncrypterBuilder Verify(string? password)
        {
            if (!string.IsNullOrWhiteSpace(password))
                _mock.Setup(passwordEncrypter => passwordEncrypter.Verify(password, It.IsAny<string>())).Returns(true);
            
            return this;
        }
            

        public IPasswordEncripter Build() => _mock.Object;
    }
}
