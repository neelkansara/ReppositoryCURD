using CURD.Business.Models;
using CURD.Contract.Service;
using CURD.Domain;
using CURD.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CURDAPI.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        private readonly IUserService _userService;

        public UserController()
        {
            _userService = new UserService();
        }

        public object Get()
        {
            var output = new ResponseDetail();
            try
            {
                var userItems = _userService.GetAllUserByRole(0);
                output.Data = userItems;
                output.Success = true;
                return output;
            }
            catch (Exception ex)
            {

                output.Success = false;
                output.Message = ex.Message;
                return output;
            }
        }

        public object Get(long id)
        {
            var output = new ResponseDetail();
            try
            {
                var userItems = _userService.GetActiveUser(id);
                output.Data = userItems;
                output.Success = true;
                return output;
            }
            catch (Exception ex)
            {

                output.Success = false;
                output.Message = ex.Message;
                return output;
            }
        }
        [Route("GetUser")]
        public object GetUser(long id)
        {
            var output = new ResponseDetail();
            try
            {
                var userItems = _userService.GetUser(id);
                output.Data = userItems;
                output.Success = true;
                return output;
            }
            catch (Exception ex)
            {

                output.Success = false;
                output.Message = ex.Message;
                return output;
            }
        }

        public object Login(LoginViewModel userDetail)
        {
            var output = new ResponseDetail();
            try
            {
                var user = _userService.Login(userDetail.Email, userDetail.Password);
                if (user!=null)
                {
                    output.Data = user;
                    output.Success = true;
                }
                else
                {
                    output.Success = false;
                    output.Message = "Please enter valid credentials";
                }
                return output;
            }
            catch (Exception ex)
            {
                output.Message = ex.Message;
                output.Success = false;
                return output;
                
            }
        }

        [Route("Post")]
        public async Task<object>  Post(tbl_User user)
        {
            var output = new ResponseDetail();
            try
            {
                var userDetail = _userService.CreateUser(user);
                output.Data = userDetail;
                output.Success = true;
                output.Message = "User created.";
                return output;
            }
            catch (Exception ex)
            {
                output.Message = ex.Message;
                output.Success = false;
                return output;
            }
        }

        [Route("Update")]
        public async Task<object> Put(tbl_User user)
        {
            var output = new ResponseDetail();
            try
            {
               _userService.Update(user);
                var userDetail = _userService.GetActiveUser(user.userid);
               output.Data = userDetail;
                output.Success = true;
                output.Message = "User Updated.";
                return output;
            }
            catch (Exception ex)
            {
                output.Message = ex.Message;
                output.Success = false;
                return output;
            }
        }
    }
}
