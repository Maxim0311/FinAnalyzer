using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinAnalyzer.Core.Dto;

public class CategoriesStatsResponse
{
    public string Name { get; set; }

    public decimal Value { get; set; }

    public string Color { get; set; }
}
