﻿using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Expenses
{
    public interface IExpenseRepository
    {
        Task Add(Expense expense);
        Task<List<Expense>> GetAll();
        Task<Expense?> Get(long id);
    }
}
