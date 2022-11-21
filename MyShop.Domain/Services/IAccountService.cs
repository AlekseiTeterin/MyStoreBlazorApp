﻿using MyStore.Models;

namespace MyStore.Domain.Services
{
    public interface IAccountService
    {
        Task<Account> Register(Account account);
    }
}