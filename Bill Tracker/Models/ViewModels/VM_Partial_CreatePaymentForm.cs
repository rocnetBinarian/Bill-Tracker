using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bill_Tracker.Models.ViewModels
{
    public class VM_Partial_CreatePaymentForm
    {
        public int BillId { get; set; }
        public double? Amount { get; set; } = null;
        [Display(Name = "Payment Date")]
        public DateTime PaymentDate { get; set; }
        public string Notes { get; set; }
        [Display(Name = "Receipt Location")]
        public string ReceiptLocation { get; set; }
    }
}
