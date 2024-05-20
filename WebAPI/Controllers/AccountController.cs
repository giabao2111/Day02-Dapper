using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private Repository.IAccountService _accountService;


        public AccountController(Repository.IAccountService accountService)
        {
            this._accountService = accountService;
        }
        [HttpGet()]
        public async Task<IEnumerable<Account>> GetAccounts()
        {
            return await _accountService.GetAccounts();
        }

        [HttpGet("{no}")]
        public async Task<Account> GetAccount(string no)
        {
            return await _accountService.GetAccount(no);
        }

        [HttpPost()]
        public async Task<Account> PostAccount(Account account)
        {
            return await _accountService.PostAccount(account);
        }

        [HttpPut()]
        public async Task<Account> PutAccount(Account account)
        {
            return await _accountService.PutAccount(account);
        }
        [HttpDelete("{no}")]
        public async Task<Account> DeleteAccount(string no)
        {
            return await _accountService.DeleteAccount(no);
        }

    }
}
