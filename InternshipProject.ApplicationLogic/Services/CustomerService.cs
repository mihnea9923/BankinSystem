﻿using InternshipProject.ApplicationLogic.Abstractions;
using InternshipProject.ApplicationLogic.Exceptions;
using InternshipProject.ApplicationLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InternshipProject.ApplicationLogic.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly ICardRepository cardRepository;
        private readonly ICardColorRepository cardColorRepository;
        public CustomerService(ICustomerRepository customerRepository , ICardRepository cardRepository,ICardColorRepository cardColorRepository )
        {
            this.customerRepository = customerRepository;
            this.cardRepository = cardRepository;
            this.cardColorRepository = cardColorRepository;
        }

        public Guid GetCustomerIdFromUserId(string userId)
        {
            var idToSearch = Guid.Parse(userId);
            var foundCustomer =  customerRepository?.GetCustomerByUserId(idToSearch);
            if (foundCustomer == null)
            {
                throw new CustomerNotFoundException(userId);
            }
            return foundCustomer.Id;
        }
        
        public IEnumerable<BankAccount> GetCustomerBankAccounts(Guid customerId)
        {
            var customer = customerRepository?.GetById(customerId);
            if (customer == null)
            {
                throw new CustomerNotFoundException(customerId);
            }
            
            return customer.BankAccounts
                            .AsEnumerable();           
        }
        public IEnumerable<BankAccount> GetCustomerBankAccounts(string userId)
        {
            Guid idToSearch = Guid.Empty;            
            Guid.TryParse(userId, out idToSearch);
            var customer = customerRepository?.GetCustomerByUserId(idToSearch);
            
            if (customer == null)
            {
                throw new CustomerNotFoundException(userId);
            }

            return customer.BankAccounts
                            .AsEnumerable();
        }
        public CardColor GetCardColor(Guid cardId)
        {
            return cardColorRepository.GetColor(cardId);
        }
        public Customer GetCustomer(string userId)
        {
            Guid idToSearch = Guid.Empty;
            Guid.TryParse(userId, out idToSearch);
            var customer = customerRepository?.GetCustomerByUserId(idToSearch);
            if (customer == null)
            {
                throw new CustomerNotFoundException(userId);
            }

            return customer;
        }

        public IEnumerable<Card> GetCardsByUserID(string userID)
        {
            Guid idToSearch = Guid.Empty;
            Guid.TryParse(userID, out idToSearch);
            var cards = cardRepository.GetByUserId(idToSearch);
            return cards;
        }



    }
}