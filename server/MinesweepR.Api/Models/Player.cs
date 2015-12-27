using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinesweepR.Api.Models
{
    public class Player
    {
        [JsonIgnore]
        public string ConnectionId
        {
            get;
            set;
        }
        public string PlayerName
        {
            get;
            set;
        }
    }
}