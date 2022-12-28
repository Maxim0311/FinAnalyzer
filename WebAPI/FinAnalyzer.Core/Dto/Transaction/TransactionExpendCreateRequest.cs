using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinAnalyzer.Core.Dto.Transaction
{
    #nullable disable
    public class TransactionExpendCreateRequest : TransactionCreateRequest
    {
        public string Destination { get; set; }

        public int Sender { get; set; }
    }
}
