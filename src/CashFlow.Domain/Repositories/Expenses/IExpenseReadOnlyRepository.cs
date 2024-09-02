﻿using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Expenses
{
    public interface IExpenseReadOnlyRepository
    {
        Task<List<Expense>> GetAll();
        Task<Expense?> Get(long id);
    }
}