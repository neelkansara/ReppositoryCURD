using CURD.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CURD.Contract.Service
{
    public interface IUserService
    {
        tbl_User CreateUser(tbl_User user);
        
            tbl_User GetUser(long id);

        tbl_User GetActiveUser(long id);

        List<tbl_User> GetAllUserByRole(int roleId);

        List<tbl_User> GetAllActiveUserByRole(int roleId);

        tbl_User Login(string email, string password);
    }
}
