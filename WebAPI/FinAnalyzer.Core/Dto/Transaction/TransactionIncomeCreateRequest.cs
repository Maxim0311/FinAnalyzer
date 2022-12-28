using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinAnalyzer.Core.Dto.Transaction
{
    #nullable disable
    public class TransactionIncomeCreateRequest : TransactionCreateRequest
    {
        public int Destination { get; set; }

        public string Sender { get; set; }
    }
}
