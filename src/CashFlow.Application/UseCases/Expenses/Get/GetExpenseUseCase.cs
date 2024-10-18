using AutoMapper;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Domain.Services.LoggedUser;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Expenses.Get
{
    public class GetExpenseUseCase : IGetExpenseUseCase
    {
        private readonly IMapper _mapper;
        private readonly IExpenseReadOnlyRepository _repository;
        private readonly ILoggedUser _loggedUser;
        
        public GetExpenseUseCase(IExpenseReadOnlyRepository repository, IMapper mapper, ILoggedUser loggedUser)
        {
            _repository = repository;
            _mapper = mapper;
            _loggedUser = loggedUser;
        }

        public async Task<ResponseExpenseJson> Execute(long id)
        {
            var loggedUser = await _loggedUser.Get();
            
            var result = await _repository.Get(loggedUser, id);

            if (result == null)
            {
                throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_FOUND);
            }

            return _mapper.Map<ResponseExpenseJson>(result);
        }
    }
}
