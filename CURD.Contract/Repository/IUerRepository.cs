using CURD.Contract.Repository.Generic;
using CURD.Domain;
using System.Collections.Generic;

namespace CURD.Contract.Repository
{
    public interface IUerRepository :IBaseRepository<tbl_User>
    {
        tbl_User GetUser(long id);

        tbl_User GetActiveUser(long id);

        List<tbl_User> GetAllUserByRole(int roleId);

        List<tbl_User> GetAllActiveUserByRole(int roleId);

        tbl_User Login(string email, string password);


    }
}
