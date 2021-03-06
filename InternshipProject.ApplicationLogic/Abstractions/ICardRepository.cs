﻿using InternshipProject.ApplicationLogic.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternshipProject.ApplicationLogic.Abstractions
{
    public interface ICardRepository: IRepository<Card>
    {

         IEnumerable<Card> GetByAccountId(Guid userId);
          void AddCardTransaction(Card card);

    }
}
