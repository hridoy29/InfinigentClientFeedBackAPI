using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infinigent_ClientFeednback.DTOs
{
    public class ClientFeedBackParentDTO
    {
        public string UserID { get; set; }
        public DateTime Date { get; set; }
        public int  Sum { get; set; }
        public List<ClientFeedBackDataDTO> questions { get; set; }
    }
}