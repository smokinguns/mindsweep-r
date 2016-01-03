using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinesweepR.Api.Models
{
    public class Player :User
    {
        public bool AtBat
        {
            get;
            set;
        }
    }
}