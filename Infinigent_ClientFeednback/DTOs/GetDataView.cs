﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infinigent_ClientFeednback.DTOs
{
    public class GetDataView
    {
        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }
        public int type { get; set; }
    }
}