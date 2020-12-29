using DbContextModel.Framework;
using System.Data.SqlClient;
using System.Linq;

namespace DbContextModel
{
    public class AccountModel
    {
        private DbContextWeb context = null;
        public AccountModel()
        {
            context = new DbContextWeb();
        }
        public bool Login(string userName, string Password)
        {
            object[] sqlParas = {
                new SqlParameter("@UserName", userName),
                new SqlParameter("@Password", Password),
            };
            //Gọi thủ tục đã tạo có tên "Sp_Account_Login" sử dụng SingleOrDefault() để trả về giá trị duy nhất, 
            var res = context.Database.SqlQuery<bool>("Sp_Account_Login @UserName, @Password", sqlParas).SingleOrDefault();
            return res;
        }

    }
}
