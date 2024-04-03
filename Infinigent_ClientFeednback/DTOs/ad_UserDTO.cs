using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infinigent_ClientFeednback.DTOs
{
    public class ad_UserDTO
    {
        public string UserId { get; set; }
        public string UserPassword { get; set; }
        public int Client_Type_Id { get; set; }
        public string Creator { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsActive { get; set; }
        public string UserType { get; set; }
    }
}