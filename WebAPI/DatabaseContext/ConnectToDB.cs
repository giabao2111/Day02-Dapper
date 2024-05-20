using Microsoft.EntityFrameworkCore;
using Model;
using System.Data.SqlClient;

namespace WebAPI.DatabaseContext
{
    public class ConnectToDB: DbContext
    {
     

        string str = "Server=DESKTOP-F4OHHB4\\MSSQLSERVER01;Database=DMAWS;Trusted_Connection=True;TrustServerCertificate=True";
        public SqlConnection setConnect()
        {
            var sqlConnect = new SqlConnection(str);
            return sqlConnect;
        }
        public DbSet<Account> Accounts { get; set; }
    }
}
