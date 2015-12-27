using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BrockAllen.MembershipReboot;
using MinesweepR.Api.Models;

using BrockAllen.MembershipReboot.Helpers;
using BrockAllen.MembershipReboot.Ef;
using System.Data.Entity;
namespace MinesweepR.Api.Controllers
{
    public class UserController : ApiController
    {
        UserAccountService _userAccountService;
        public UserController(UserAccountService userAccountService)
        {
            _userAccountService = userAccountService;   
        }
        public void Post([FromBody]User user)
        {
            //var db = new MembershipDatabase();
           
            
            //var service = new UserAccountService(new DefaultUserAccountRepository(new DefaultMembershipRebootDatabase("MembershipReboot")));
            _userAccountService.CreateAccount(user.EmailAddress.Split('@')[0],user.Password,user.EmailAddress,null,DateTime.Today,null);
        }  
            
            
            
    }
}
