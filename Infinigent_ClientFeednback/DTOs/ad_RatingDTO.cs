using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infinigent_ClientFeednback.DTOs
{
    public class ad_RatingDTO
    {
        public int Id { get; set; }
        public int Rating_Point { get; set; }
        public string Rating_Value { get; set; }
        public bool IsActive { get; set; }
    }
}