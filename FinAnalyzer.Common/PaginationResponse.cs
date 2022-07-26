﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinAnalyzer.Common
{
    public class PaginationResponse<T>
    {
        public List<T> Items { get; set; }

        public int TotalCount { get; set; }
    }
}
