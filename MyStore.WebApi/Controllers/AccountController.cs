using Microsoft.AspNetCore.Mvc;
using MyStore.Models;
using MyStore.WebApi.Repositories;
using MyStore.WebApi.Services;

namespace MyStore.WebApi.Controllers
{
    [ApiController]
    [Route("account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountService _accountService;

        public AccountController(IAccountRepository accountRepository, IAccountService accountService)
        {
            _accountRepository = accountRepository;
            _accountService = accountService;
        }
        [HttpPost("register")]
        public async Task<ActionResult<Account>> Register(Account account)
        {
            try
            {
                var newAccount = await _accountService.Register(account);
                return newAccount;
            }
            catch (EmailIsBusyException ex)
            {
                return BadRequest(new
                {
                    ex.Message, 
                    account.Email
                });
            }
            
        }

        [HttpGet("get")]
        public async Task<ActionResult<Account>> GetAccount(Guid id)
        {
            try
            {
                Account account = await _accountRepository.GetById(id);
                return account;
            }
            catch(InvalidOperationException)
            {
                return NotFound();
            }
            
        }
    }
}
