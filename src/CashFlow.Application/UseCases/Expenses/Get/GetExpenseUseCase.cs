using AutoMapper;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Expenses.Get
{
    public class GetExpenseUseCase : IGetExpenseUseCase
    {
        private readonly IMapper _mapper;
        private readonly IExpenseRepository _repository;
        
        public GetExpenseUseCase(IExpenseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseExpenseJson> Execute(long id)
        {
            var result = await _repository.Get(id);

            if (result == null)
            {
                throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_FOUND);
            }

            return _mapper.Map<ResponseExpenseJson>(result);
        }
    }
}
