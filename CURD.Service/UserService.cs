using CURD.Contract.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CURD.Domain;
using CURD.DAL;

namespace CURD.Service
{
    public class UserService : IUserService
    {
        public tbl_User CreateUser(tbl_User user)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                unitOfWork.UserRepository.Insert(user);
                unitOfWork.UserRepository.Save();
                return user;
            }
        }
        public tbl_User GetActiveUser(long id)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                return unitOfWork.UserRepository.GetActiveUser(id);
            }
        }

        public List<tbl_User> GetAllActiveUserByRole(int roleId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                return unitOfWork.UserRepository.GetAllActiveUserByRole(roleId);
            }
        }

        public List<tbl_User> GetAllUserByRole(int roleId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                return unitOfWork.UserRepository.GetAllUserByRole(roleId);
            }
        }

        public tbl_User GetUser(long id)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                return unitOfWork.UserRepository.GetUser(id);
            }
        }

        public tbl_User Login(string email, string password)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                return unitOfWork.UserRepository.Login(email,password);
            }
        }
    }
}
