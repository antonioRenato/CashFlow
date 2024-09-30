using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Repositories.User;
using CashFlow.Domain.Security.Cryptography;
using CashFlow.Domain.Security.Tokens;

namespace CashFlow.Application.UseCases.Login
{
    public class DoLoginUseCase : IDoLoginUseCase
    {
        private readonly IUserReadOnlyRepository _repository;
        private readonly IPasswordEncripter _passwordEncripter;
        private readonly IAcessTokenGenerator _acessTokenGenerator;
        
        public DoLoginUseCase(IUserReadOnlyRepository repository, IPasswordEncripter passwordEncripter, IAcessTokenGenerator acessTokenGenerator)
        {
            _repository = repository;
            _passwordEncripter = passwordEncripter;
            _acessTokenGenerator = acessTokenGenerator;        
        }

        public async Task<ResponseRegisteredUserJson> Execute(RequestLoginJson request)
        {
            return new ResponseRegisteredUserJson
            {

            };
        }
    }
}
