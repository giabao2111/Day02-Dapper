
using Model;
using WebAPI.Repository;
using Dapper;
using WebAPI.DatabaseContext;
using System.Security.Principal;

namespace WebAPI.Services
{
    public class AccountServiceImp : IAccountService
    {
        private readonly ConnectToDB connect = new ConnectToDB();

        public async Task<IEnumerable<Account>> GetAccounts()
        {
            string sql = "select * from Account";
            using (var db = connect.setConnect())
            {
                await db.OpenAsync();  //mở kết nối
                return await db.QueryAsync<Account>(sql, db);
            }


        }
        public async Task<Account> DeleteAccount(string no)
        {
            string sql = "Delete from Account where no=@no";
            using (var db = connect.setConnect())
            {
                await db.OpenAsync();  //mở kết nối
                var dp = new DynamicParameters();
                dp.Add("@no", no);
                return await db.ExecuteScalarAsync<Account>(sql, dp);
            }
        }

        public async Task<Account> GetAccount(string no)
        {
            string sql = "select * from Account where no=@no";
            using (var db = connect.setConnect())
            {
                await db.OpenAsync();  //mở kết nối
                var dp = new DynamicParameters();
                dp.Add("@no", no); //truyen tham so
                return await db.QueryFirstOrDefaultAsync<Account>(sql, dp);
            }
        }



        public async Task<Account> PostAccount(Account newAccount)
        {
            string sql = "insert  Account(no,name,pincode,address,balance) VALUES(@no,@name,@pincode,@address,@balance)";
            using (var db = connect.setConnect())
            {
                await db.OpenAsync();  //mở kết nối
                var dp = new DynamicParameters();
                dp.Add("@no", newAccount.no); //truyen tham so
                dp.Add("@name", newAccount.name); //truyen tham so
                dp.Add("@pincode", newAccount.pincode); //truyen tham so
                dp.Add("@address", newAccount.address); //truyen tham so
                dp.Add("@balance", newAccount.balance); //truyen tham so

                return await db.ExecuteScalarAsync<Account>(sql, dp);
            }
        }

        public async Task<Account> PutAccount(Account editAccount)
        {
            string sql = "update Account set balance=@balance where no=@no";
            using (var db = connect.setConnect())
            {
                await db.OpenAsync();  //mở kết nối
                var dp = new DynamicParameters();
           
                dp.Add("@balance", editAccount.balance); //truyen tham so
                dp.Add("@no", editAccount.no); //truyen tham so
                return await db.ExecuteScalarAsync<Account>(sql, dp);
            }
        }
    }
}
