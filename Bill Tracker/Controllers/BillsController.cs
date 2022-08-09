using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using Bill_Tracker.Models.ViewModels;

namespace Bill_Tracker.Controllers
{
    [Route("Bills")]
    public class BillsController : ControllerBase
    {
        public BillsController()
            : base(Log.ForContext<BillsController>()) { }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            VM_BillsIndex vm;
            using (var context = new Models.Entitites.BillContext())
            {
                var list = context.Bills.ToList();
                vm = new VM_BillsIndex()
                {
                    Bills = list
                        .OrderByDescending(x => x.BILLTYPE)
                        .ThenBy(x => x.Id)
                        .ToList()
                };
            }
            return View("~/Views/Bills/Index.cshtml", vm);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromForm] VM_Partial_CreateBillForm data)
        {
            using (var context = new Models.Entitites.BillContext())
            {
                if (data.Recurring)
                {
                    var rbill = new Models.Entitites.RecurringBill()
                    {
                        DisplayName = data.Name,
                        Enabled = data.RecurranceActive,
                        RecurranceFrequencyId = data.RecurranceFrequency
                    };
                    context.RecurringBills.Add(rbill);
                } else
                {
                    var bill = new Models.Entitites.Bill()
                    {
                        DisplayName = data.Name
                    };
                    context.Bills.Add(bill);
                }
                await context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
