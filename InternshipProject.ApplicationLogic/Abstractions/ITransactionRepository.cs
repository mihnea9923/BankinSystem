﻿using InternshipProject.ApplicationLogic.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternshipProject.ApplicationLogic.Abstractions
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        Transaction NewReceived(decimal amount, string externalName, string externalIBAN, Guid bankAccountId);

        Transaction NewTransaction(decimal amount, string externalName, string externalIBAN, Guid bankAccountId);
        Transaction GetTransactionById(Guid Id);
        IEnumerable<Transaction> GetAllTransactionsForCustomer(Guid userId);
        IEnumerable<Transaction> GetReceived(Guid userId);
        IEnumerable<Transaction> GetTransactionsFromBankAccount(Guid Id);
    }
}
