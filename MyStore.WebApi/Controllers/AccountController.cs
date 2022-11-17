using Microsoft.AspNetCore.Mvc;
using MyStore.Models;
using MyStore.WebApi.Repositories;

namespace MyStore.WebApi.Controllers
{
    [ApiController]
    [Route("account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(Account account)
        {
            account.Id = Guid.NewGuid();

            var existedAccount = await _accountRepository.
                FindByEmail(account.Email);

            var accountExists = existedAccount is null;

            if (accountExists)
            {
                await _accountRepository.Add(account);
                return Ok();
            }
            else
            {
                return BadRequest(new
                {
                    Message = "Такой email уже зарегистрирован"
                }); 
            }
        }
    }
}
