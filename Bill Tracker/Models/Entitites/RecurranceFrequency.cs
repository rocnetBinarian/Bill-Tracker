using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bill_Tracker.Models.Entitites
{
    public class RecurranceFrequency
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public int NumMonths { get; set; }

        public virtual IEnumerable<RecurringBill> RecurringBills { get; set; }
    }
}
