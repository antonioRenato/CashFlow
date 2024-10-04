﻿using CashFlow.Domain.Repositories;
using Moq;

namespace CommomTestUtilities.Repositories
{
    public class UnityOfWorkBuilder
    {
        public static IUnitOfWork Build()
        {
            var mock = new Mock<IUnitOfWork>();

            return mock.Object;
        }
    }
}
