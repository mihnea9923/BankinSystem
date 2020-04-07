﻿using InternshipProject.ApplicationLogic.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternshipProject.ApplicationLogic.Abstractions
{
    public interface ICardRepository
    {
        Card GetById(Guid cardId);
        IEnumerable<Card> GetByAccount(Guid accountId);
        Card Add(Card card);
    }
}
