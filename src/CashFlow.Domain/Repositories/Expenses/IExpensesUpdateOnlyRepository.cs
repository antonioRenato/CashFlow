﻿using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Expenses
{
    public interface IExpensesUpdateOnlyRepository
    {
        Task<Expense?> Get(Entities.User user, long id);
        void Update(Expense expense);
    }
}
