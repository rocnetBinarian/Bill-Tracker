using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

using Bill_Tracker.Models.Entitites;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bill_Tracker.Models.ViewModels
{
    public class VM_BillsIndex
    {

        public List<int> BillIds
        {
            get
            {
                return Bills.Select(x => x.Id).OrderBy(x => x).ToList();
            }
        }

        public List<SelectListItem> BillList
        {
            get
            {
                var list = new List<SelectListItem>();
                foreach (var b in Bills)
                {
                    list.Add(new SelectListItem()
                    {
                        Text = b.DisplayName,
                        Value = b.Id.ToString()
                    });
                }
                return list;
            }
        }
        public List<Bill> Bills { get; set; }
    }
}
