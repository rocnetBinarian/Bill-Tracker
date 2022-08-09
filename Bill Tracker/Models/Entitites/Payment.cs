using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bill_Tracker.Models.Entitites
{
    public class Payment
    {
        public int Id { get; set; }
        public int BillId { get; set; }
        public double Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Notes { get; set; }
        public string ReceiptLocation { get; set; }

        public virtual Bill Bill { get; set; }
    }
}
