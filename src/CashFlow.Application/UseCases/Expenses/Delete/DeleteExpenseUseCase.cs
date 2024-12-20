﻿using AutoMapper;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Domain.Services.LoggedUser;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Expenses.Delete
{
    public class DeleteExpenseUseCase : IDeleteExpenseUseCase
    {
        private readonly IExpenseReadOnlyRepository _expenseReadOnlyRepository;
        private readonly IExpensesWriteOnlyRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggedUser _loggedUser;
        
        public DeleteExpenseUseCase(IExpensesWriteOnlyRepository repository, 
            IUnitOfWork unitOfWork, 
            ILoggedUser loggedUser, 
            IExpenseReadOnlyRepository expenseReadOnlyRepository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _loggedUser = loggedUser;
            _expenseReadOnlyRepository = expenseReadOnlyRepository;
        }

        public async Task Execute(long id)
        {
            var loggedUser = await _loggedUser.Get();

            var expense = await _expenseReadOnlyRepository.Get(loggedUser, id);
            
            if (expense == null)
            {
                throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_FOUND);
            }

            await _repository.Delete(id);
            
            await _unitOfWork.Commit();
        }
    }
}
