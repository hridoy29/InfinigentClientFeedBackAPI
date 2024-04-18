using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infinigent_ClientFeednback.DTOs
{
    public class ClientFeedBackDataDTO
    {
        public string UserID { get; set; }
        public string Question { get; set; }
        public string Rating_Value { get; set; }
        public int point { get; set; }
        public string OthersValue { get; set; }
        public DateTime Date { get; set; }
    }
}