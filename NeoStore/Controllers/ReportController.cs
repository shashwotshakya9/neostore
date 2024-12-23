using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NeoStore.Data;
using NeoStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeoStore.Controllers
{
    public class ReportController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StockListReport(String search)
        {
            List<ProductStockViewModel> lstData = new List<ProductStockViewModel>();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                if (String.IsNullOrEmpty(search))
                {
                    command.CommandText = "SELECT p.Id as ProductId, p.ProductName, s.Quantity, p.Model from Product p inner join Stock s on p.Id=s.ProductId";
                }
                else
                {
                    command.CommandText = "SELECT p.Id as ProductId, p.ProductName, s.Quantity,p.Model from Product p inner join Stock s on p.Id=s.ProductId WHERE p.ProductName LIKE '%" + search + "%'";
                }
                _context.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    ProductStockViewModel data;
                    while (result.Read())
                    {
                        data = new ProductStockViewModel();
                        data.ProductId = result.GetInt32(0);
                        data.ProductName = result.GetString(1);
                        data.StockQuantity = result.GetInt32(2);
                        data.ProductModel = result.GetString(3);
                        lstData.Add(data);
                    }
                }
            }
            return View(lstData.Where(x => x.StockQuantity > 0));
        }

        public IActionResult CustomerPurchaseReport(String search)
        {
            List<CustomerPurchaseViewModel> lstData = new List<CustomerPurchaseViewModel>();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                if (String.IsNullOrEmpty(search))
                {
                    command.CommandText = "SELECT c.Id, c.Name, s.Id, s.BillNumber, s.SaleDate, p.Id, p.ProductCode, p.ProductName, p.Model, sd.Quantity, sd.Price, sd.Total FROM Customer c " +
                        "JOIN Sale s " +
                        "ON c.Id = s.CustomerId " +
                        "JOIN SaleDetail sd " +
                        "ON s.Id = sd.SaleId " +
                        "JOIN Product p " +
                        "ON sd.ProductId = p.Id " +
                        "WHERE s.SaleDate >= GETDATE() - 31";
                }
                else
                {
                    command.CommandText = "SELECT c.Id, c.Name, s.Id, s.BillNumber, s.SaleDate, p.Id, p.ProductCode, p.ProductName, p.Model, sd.Quantity, sd.Price, sd.Total FROM Customer c " +
                        "JOIN Sale s " +
                        "ON c.Id = s.CustomerId " +
                        "JOIN SaleDetail sd " +
                        "ON s.Id = sd.SaleId " +
                        "JOIN Product p " +
                        "ON sd.ProductId = p.Id " +
                        "WHERE s.SaleDate >= GETDATE() - 31 AND c.Name LIKE '%"+search+"%'";
                }
                _context.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    CustomerPurchaseViewModel data;
                    while (result.Read())
                    {
                        data = new CustomerPurchaseViewModel();
                        data.CustomerId = result.GetInt32(0);
                        data.CustomerName = result.GetString(1);
                        data.SaleId = result.GetInt32(2);
                        data.BillNumber = result.GetString(3);
                        data.SaleDate = result.GetDateTime(4);
                        data.ProductId = result.GetInt32(5);
                        data.ProductCode = result.GetString(6);
                        data.ProductName = result.GetString(7);
                        data.ProductModel = result.GetString(8);
                        data.PurchaseQunatity = result.GetInt32(9);
                        data.UnitPrice = result.GetFloat(10);
                        data.Total = result.GetFloat(11);
                        lstData.Add(data);
                    }
                }
            }
            return View(lstData);
        }
        public IActionResult CustomerPreviousPurchaseReport()
        {
            List<CustomerPreviousPurchaseViewModel> lstData = new List<CustomerPreviousPurchaseViewModel>();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
               
          
            command.CommandText = "SELECT c.Id, c.Name FROM Customer c LEFT JOIN Sale s ON c.Id = s.CustomerId WHERE c.Id NOT IN( SELECT c.Id FROM Customer c INNER JOIN Sale s ON c.Id = s.CustomerId WHERE s.SaleDate >= GETDATE() - 31)";
               
                _context.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    CustomerPreviousPurchaseViewModel data;
                    while (result.Read())
                    {
                        data = new CustomerPreviousPurchaseViewModel();
                        data.CustomerId = result.GetInt32(0);
                        data.CustomerName = result.GetString(1);
                        lstData.Add(data);
                    }
                }
            }
            return View(lstData);
        }

        public IActionResult ProductNotSoldViewModelReport()
        {
            List<ProductNotSoldViewModel> lstData = new List<ProductNotSoldViewModel>();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {


                command.CommandText = "SELECT p.Id, p.ProductCode, p.ProductName, c.Type, s.Quantity FROM Stock s LEFT JOIN Product p ON s.ProductId = p.Id LEFT JOIN Category c ON p.ProductCategory = c.Id LEFT JOIN SaleDetail sd ON p.Id = sd.ProductId LEFT JOIN Sale sl ON sd.SaleId = sl.Id WHERE p.Id NOT IN(SELECT sd.ProductId FROM SaleDetail sd INNER JOIN Sale s ON sd.SaleId = s.Id WHERE s.SaleDate >= GETDATE() - 31)";

                _context.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    ProductNotSoldViewModel data;
                    while (result.Read())
                    {
                        data = new ProductNotSoldViewModel();
                        data.ProductId = result.GetInt32(0);
                        data.ProductCode = result.GetString(1);
                        data.ProductName = result.GetString(2);
                        data.ProductCategory = result.GetString(3);
                        data.AvailableStock = result.GetInt32(4);
                        lstData.Add(data);
                    }
                }
            }
            return View(lstData);
        }

        public IActionResult OutOfStockReport(string option)
        {
            List<OutOfStockViewModel> listData = new List<OutOfStockViewModel>();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT p.Id, p.ProductName, p.ProductCode, s.Quantity, pr.PurchaseDate, c.Type FROM Product p " +
                    "JOIN Stock s ON p.Id=s.ProductId " +
                    "JOIN PurchaseDetail pd ON p.Id=pd.ProductId " +
                    "JOIN Purchase pr ON pd.PurchaseId=pr.Id " +
                    "JOIN Category c ON p.ProductCategory=c.Id";

                _context.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    OutOfStockViewModel data;
                    while (result.Read())
                    {
                        data = new OutOfStockViewModel();
                        data.ProductId = result.GetInt32(0);
                        data.ProductName = result.GetString(1);
                        data.ProductCode = result.GetString(2);
                        data.ProductQuantity = result.GetInt32(3);
                        data.StockedDate = result.GetDateTime(4);
                        data.ProductCategory = result.GetString(5);
                        listData.Add(data);
                    }
                }
            }
            if (option == "Date")
            {
                var d = listData.Where(x => x.ProductQuantity == 0);
                return View(d.OrderByDescending(x => x.StockedDate));
            }
            else if (option == "Name")
            {
                var a = listData.Where(x => x.ProductQuantity == 0);
                return View(a.OrderBy(x => x.ProductName));
            }
            else
            {
                return View(listData.Where(x => x.ProductQuantity == 0));
            }
        }
    }
}
