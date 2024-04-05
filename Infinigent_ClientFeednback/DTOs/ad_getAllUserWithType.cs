using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infinigent_ClientFeednback.DTOs
{
    public class ad_getAllUserWithType
    {
        public string UserId { get; set; }
        public string UserType { get; set; }
        public bool CurrentStatus { get; set; }
      
    }
}