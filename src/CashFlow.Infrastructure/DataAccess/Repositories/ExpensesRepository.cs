﻿using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CashFlow.Infrastructure.DataAccess.Repositories
{
    internal class ExpensesRepository : IExpenseReadOnlyRepository, IExpensesWriteOnlyRepository, IExpensesUpdateOnlyRepository
    {
        private readonly CashFlowDbContext _dbContext;

        public ExpensesRepository(CashFlowDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Expense expense)
        {
            await _dbContext.Expenses.AddAsync(expense);   
        }

        public async Task Delete(long id)
        {
            var result = await _dbContext.Expenses.FirstAsync(expense => expense.Id == id);

            _dbContext.Expenses.Remove(result);
        }

        public async Task<List<Expense>> GetAll(User user)
        {
            return await _dbContext.Expenses.AsNoTracking().Where(x => x.Id == user.Id).ToListAsync();
        }

        async Task<Expense?> IExpenseReadOnlyRepository.Get(User user, long id)
        {
            return await _dbContext.Expenses
                .Include(expense => expense.Tags)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id && e.UserId == user.Id);
        }

        async Task<Expense?> IExpensesUpdateOnlyRepository.Get(long id)
        {
            return await _dbContext.Expenses
                .Include(expense => expense.Tags)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public void Update(Expense expense)
        {
            _dbContext.Expenses.Update(expense);
        }
    }
}
