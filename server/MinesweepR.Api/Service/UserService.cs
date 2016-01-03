using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Caching;
using MinesweepR.Api.Models;
namespace MinesweepR.Api.Service
{
    public class UserService
    {
        public static List<User> OnlineUsers { get; set; }

        public void Add(User user)
        {
            if (OnlineUsers == null)
            {
                OnlineUsers = new List<User>() {user};
            }else{
                var onlineUser = OnlineUsers.FirstOrDefault(p => p.UserName == user.UserName);
                if (onlineUser == null)
                {
                    OnlineUsers.Add(user);
                }
            }
            
        }
        public IEnumerable<User> Get()
        {
            return OnlineUsers;
        }

        public User Get(string userName)
        {
            return OnlineUsers.FirstOrDefault(p => p.UserName == userName);
        }

        public void Delete(string userName)
        {
           var cnt =   OnlineUsers.RemoveAll(a => a.UserName == userName);
        }
    }
}