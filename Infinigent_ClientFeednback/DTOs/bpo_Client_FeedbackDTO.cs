using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infinigent_ClientFeednback.DTOs
{
    public class bpo_Client_FeedbackDTO
    {
  
        public string UserId { get; set; }
        public int QuestionId { get; set; }
        public int ResponseRatingId { get; set; }
        public string Creator { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsActive { get; set; }
    }
}