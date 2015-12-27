using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BrockAllen.MembershipReboot.Ef;
namespace MinesweepR.Api.Models
{
    public class MembershipDatabase :DefaultMembershipRebootDatabase
    {
        public MembershipDatabase()
            : base("MembershipReboot")
        {
           
        }
    }
}