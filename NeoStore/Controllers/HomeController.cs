using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NeoStore.Data;
using NeoStore.Models;
using NeoStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NeoStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        /*private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/

        public IActionResult Index()
        {
            List<LowStockViewModel> listData = new List<LowStockViewModel>();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT p.id, p.ProductName, p.ProductCode, st.Quantity From Product p " +
                    "JOIN Stock st on p.id=st.ProductId";

                _context.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    LowStockViewModel data;
                    while (result.Read())
                    {
                        data = new LowStockViewModel();
                        data.ProductId = result.GetInt32(0);
                        data.ProductName = result.GetString(1);
                        data.ProductCode = result.GetString(2);
                        data.Quantity = result.GetInt32(3);
                        listData.Add(data);
                    }
                }
            }
            return View(listData.Where(x => x.Quantity < 10 && x.Quantity != 0));
        }

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
