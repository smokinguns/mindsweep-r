using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinesweepR.Api.Models
{
    public class User
    {
        [JsonIgnore]
        public string ConnectionId
        {
            get;
            set;
        }
        public string UserName
        {
            get;
            set;
        }
        public string EmailAddress
        {
            get;
            set;
        }
        //right now each user can only play one game
        //may refactor to allow multiple concurrent games
        public bool GameInProgress
        {
            get;
            set;
        }
        [JsonIgnore]
        public string Password
        {
            get;
            set;
        }
    }
}