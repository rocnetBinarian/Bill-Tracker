using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bill_Tracker.Models.Entitites
{
    public class Bill
    {
        public Bill()
        {
            BILLTYPE = "Normal";
        }
        public Bill(string BillType)
        {
            BILLTYPE = BillType;
        }
        public readonly string BILLTYPE;

        public int Id { get; set; }
        public string DisplayName { get; set; }

        public virtual IEnumerable<RecurringBill> RecurringBills { get; set; }
        public virtual IEnumerable<Payment> Payments { get; set; }
    }

    public class RecurringBill : Bill
    {
        public RecurringBill()
            : base("Recurring")
        { }
        public new int Id { get; set; } // must be Bill's Id
        public bool Enabled { get; set; }
        public int RecurranceFrequencyId { get; set; }


        public virtual RecurranceFrequency RecurranceFrequency { get; set; }
        public virtual Bill Bill { get; set; }
    }
}
