﻿using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataSourcePluginsInterfaces;

namespace UseCases
{
    public class SearchTransactionsUseCase
    {
        private readonly ITransactionsRepositry transactionsRepositry;

        public SearchTransactionsUseCase(ITransactionsRepositry transactionsRepositry)
        {
            this.transactionsRepositry = transactionsRepositry;
        }
        public IEnumerable<Transaction> Execute(string CashierName, DateTime DateStart, DateTime DateEnd)
        {
            return transactionsRepositry.Search(CashierName, DateStart, DateEnd);
        }
    }
}
