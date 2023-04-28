using Microsoft.AspNetCore.Mvc;
using PaymentModule.Models;
using PaymentModule.Services;
using System;
using System.Data;
using System.Diagnostics;
using System.Dynamic;
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

            DataTable accountData = _sqlService.Query("SELECT * FROM dbo.Account");
            List<AccountModel> account = new();
            foreach(DataRow item in accountData.Rows)
            {
                account.Add(new AccountModel() {
                    accountNumber = item["accountNumber"].ToString(), 
                    accountHolder = item["accountHolder"].ToString(),
                    customerAddress = item["customerAddress"].ToString() }) ;
            }

            DataTable billersData = _sqlService.Query("SELECT * FROM dbo.Billers");
            List<BillersModel> billers = new();
            foreach(DataRow item in billersData.Rows)
            {
                billers.Add(new BillersModel() {
                    billerID = Convert.ToInt32(item["billerID"]),
                    billerName = item["billerName"].ToString(),
                    isDeleted = Convert.ToBoolean(item["IsDeleted"])
                });
            }

            DataTable transactionTypeData = _sqlService.Query("SELECT * FROM dbo.TransactionType");
            List<TransactionType> transactionTypes = new();
            foreach(DataRow item in transactionTypeData.Rows)
            {
                transactionTypes.Add(new TransactionType() {
					typeID = Convert.ToInt32(item["TypeID"]),
					typeName = item["typeName"].ToString(),
					isDeleted = Convert.ToBoolean(item["IsDeleted"])
				});

            }

            DataTable paymentTypeData = _sqlService.Query("SELECT * FROM dbo.PaymentType");
            List<PaymentType> paymentTypes = new();
            foreach(DataRow item in paymentTypeData.Rows)
            {
                paymentTypes.Add(new PaymentType()
                {
					typeID = Convert.ToInt32(item["TypeID"]),
					typeName = item["typeName"].ToString(),
					isDeleted = Convert.ToBoolean(item["IsDeleted"])
				});
            }

            //PaymentTableViewModel objPaymentTableViewModel = new PaymentTableViewModel();
            //objPaymentTableViewModel.AccountsViewModel = account;
            //objPaymentTableViewModel.BillersViewModel = billers;

            //return View(objPaymentTableViewModel);

            dynamic paymentView = new ExpandoObject();
            paymentView.AccountModel = account;
            paymentView.BillersModel = billers;
            paymentView.TransactionType = transactionTypes;
            paymentView.PaymentType = paymentTypes;

            return View(paymentView);

		}

        // To work on 
        public IActionResult Add()
        {

            return View();
        }

        public IActionResult Update() {

            return View();
        }

        public IActionResult Delete()
        {

            return View();
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