using CURD.Contract.Repository;
using CURD.DAL.Repository.Generic;
using CURD.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CURD.DAL.Repository
{
    public class UserRepository : BaseRepository<tbl_User>, IUerRepository
    {
        public UserRepository(TestDB_1Entities context) : base(context)
        {
            _context = context;
        }

        public tbl_User GetActiveUser(long id)
        {
            return _context.tbl_User.Where(x => x.userid == id && x.isactivated==true).SingleOrDefault();
        }

        public List<tbl_User> GetAllActiveUserByRole(int roleId)
        {
            return _context.tbl_User.Where(x=>x.isactivated==true).ToList();
        }

        public List<tbl_User> GetAllUserByRole(int roleId)
        {
            return _context.tbl_User.ToList();
        }

        public tbl_User GetUser(long id)
        {
            return _context.tbl_User.Where(x => x.userid == id ).SingleOrDefault();
        }

        public tbl_User Login(string email, string password)
        {
            return _context.tbl_User.Where(x =>  x.email.ToLower() == email.ToLower() && x.password==password).SingleOrDefault();
        }
    }
}
