using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infinigent_ClientFeednback.DTOs
{
    public class cff_Client_QuestionairesDTO
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Creator { get; set; }
        public int Rank { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsOthers { get; set; }
    }
}