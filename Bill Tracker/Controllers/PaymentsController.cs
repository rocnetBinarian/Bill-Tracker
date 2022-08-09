using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bill_Tracker.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Bill_Tracker.Controllers
{
    [Route("Payments")]
    public class PaymentsController : ControllerBase
    {
        public PaymentsController()
            : base(Log.ForContext<PaymentsController>()) { }

        [HttpGet]
        [Route("Get/Bill")]
        public async Task<IActionResult> GetForBill([FromQuery] int BillId)
        {
            using (var context = new Models.Entitites.BillContext())
            {
                var list = await context.Payments
                    .Where(x => x.BillId == BillId)
                    .OrderByDescending(x => x.PaymentDate)
                    .Select(x => new { x.Id, x.PaymentDate, x.Amount, x.Notes })
                    .ToListAsync();

                return Json(list);
            }
        }

        [HttpGet]
        [Route("Get/Payment")]
        public async Task<IActionResult> Get([FromQuery] int PaymentId)
        {
            using (var context = new Models.Entitites.BillContext())
            {
                var payment = await context.Payments.FirstOrDefaultAsync(x => x.Id == PaymentId);
                return Json(payment);
            }
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromForm] VM_Partial_CreatePaymentForm reqData)
        {
            using (var context = new Models.Entitites.BillContext())
            {
                var payment = new Models.Entitites.Payment()
                {
                    BillId = reqData.BillId,
                    Amount = (double) reqData.Amount,
                    Notes = reqData.Notes,
                    PaymentDate = reqData.PaymentDate,
                    ReceiptLocation = reqData.ReceiptLocation
                };
                context.Payments.Add(payment);
                await context.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Bills");
        }
    }
}
