using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bill_Tracker.Models.ViewModels
{
    public class VM_Partial_CreateBillForm
    {
        [Required]
        [Display(Name = "Bill Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Is Recurring?")]
        public bool Recurring { get; set; } = false;

        [Required]
        [Display(Name = "Recurrance Active")]
        public bool RecurranceActive { get; set; } = true;

        [Display(Name = "Recurrance Frequency")]
        public int RecurranceFrequency { get; set; } = 1;

        private List<Entitites.RecurranceFrequency> _RecurranceFrequencies { get; set; }
        public List<Entitites.RecurranceFrequency> RecurranceFrequencies
        {
            get
            {
                if (_RecurranceFrequencies != null)
                {
                    return _RecurranceFrequencies;
                }
                var list = new List<Entitites.RecurranceFrequency>();
                using (var context = new Entitites.BillContext())
                {
                    _RecurranceFrequencies = context.RecurranceFrequencies.ToList();
                }
                return _RecurranceFrequencies;
            }
        }
    }
}
