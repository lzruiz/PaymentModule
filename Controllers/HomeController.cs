using Microsoft.AspNetCore.Mvc;
using PaymentModule.Models;
using PaymentModule.Services;
using System.Data;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PaymentModule.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISqlService _sqlService;

        public HomeController(ISqlService sqlService)
        {
            _sqlService = sqlService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var strSql = "Select * from dbo.Biller";
            DataTable data = _sqlService.Query(strSql);
            List<BillerModel> biller = new List<BillerModel>();
            foreach(DataRow item in data.Rows)
            {
                biller.Add(new BillerModel() { transaction_id = Convert.ToInt32(item["transaction_id"]), biller_name = item["biller_name"].ToString(), amount_to_pay = Convert.ToInt32(item["amount_to_pay"]), transaction_type = item["transaction_type"].ToString() }) ;
            }
            return View(biller);
        }

        // ignore
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}