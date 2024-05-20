using Model;
namespace WebAPI.Repository

{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetAccounts(); //tra về nhiều accounts

        Task<Account> GetAccount(string no); //tra ve account theo No Id 

        Task<Account> PostAccount(Account newAccount);

        Task<Account> PutAccount(Account editAccount);

        Task<Account> DeleteAccount(string no);
    }
}
