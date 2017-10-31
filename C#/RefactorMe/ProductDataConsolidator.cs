using RefactorMe.DontRefactor.Data.Implementation;
using RefactorMe.DontRefactor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefactorMe.Utility;
using Ninject;
using System.Reflection;
namespace RefactorMe
{
    public class ProductDataConsolidator
    {
        public static PhoneCaseRepository _phoneCaseRepository;
        public static LawnmowerRepository _lawnmowerRepository;
        public static TShirtRepository _tShirtRepository;

        //This constructor can be done with DI Container - NInject to Bind ProductConsolidatorService to ProductConsolidator
        public ProductDataConsolidator(PhoneCaseRepository phoneCaseRepository,
            LawnmowerRepository lawnmowerRepository,
            TShirtRepository tShirtRepository)
        {
            _phoneCaseRepository = phoneCaseRepository;
            _lawnmowerRepository = lawnmowerRepository;
            _tShirtRepository = tShirtRepository;
        }

        public static List<Product> Get(string currency)
        {
            //get exchange rate - this method is safe even if currency is null
            double exchangeRate = CurrencyExchange.GetExchangeRate(currency);
            var allProducts = new List<Product>();

            // Get lawnmower products            
            var lawmower = _lawnmowerRepository.GetAll().Select(x => new Product
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price * exchangeRate,
                Type = "Lawmower"
            });
            //Get phoneCase products 
            var phoneCase = _phoneCaseRepository.GetAll().Select(x => new Product
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price * exchangeRate,
                Type = "Phone case"
            }); ;
            //Get tShirt products 
            var tShirts = _tShirtRepository.GetAll().Select(x => new Product
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price * exchangeRate,
                Type = "T - Shirt"
            }); ;
            allProducts.AddRange(lawmower);
            allProducts.AddRange(phoneCase);
            allProducts.AddRange(tShirts);
            return allProducts;
        }
        #region 
        //public static List<Product> Get() {
        //    var l = new LawnmowerRepository().GetAll();
        //    var p = new PhoneCaseRepository().GetAll();
        //    var t = new TShirtRepository().GetAll();

        //    var ps = new List<Product>();

        //    foreach (var i in l) {
        //        ps.Add(new Product() {
        //            Id = i.Id,
        //            Name = i.Name,
        //            Price = i.Price,
        //            Type = "Lawnmower"
        //        });
        //    }

        //    foreach (var i in p) {
        //        ps.Add(new Product() {
        //            Id = i.Id,
        //            Name = i.Name,
        //            Price = i.Price,
        //            Type = "Phone Case"
        //        });
        //    }

        //    foreach (var i in t) {
        //        ps.Add(new Product() {
        //            Id = i.Id,
        //            Name = i.Name,
        //            Price = i.Price,
        //            Type = "T-Shirt"
        //        });
        //    }

        //    return ps;
        //}

        //public static List<Product> GetInUSDollars() {
        //    var l = new LawnmowerRepository().GetAll();
        //    var p = new PhoneCaseRepository().GetAll();
        //    var t = new TShirtRepository().GetAll();

        //    var ps = new List<Product>();

        //    foreach (var i in l) {
        //        ps.Add(new Product() {
        //            Id = i.Id,
        //            Name = i.Name,
        //            Price = i.Price * 0.76,
        //            Type = "Lawnmower"
        //        });
        //    }

        //    foreach (var i in p) {
        //        ps.Add(new Product() {
        //            Id = i.Id,
        //            Name = i.Name,
        //            Price = i.Price * 0.76,
        //            Type = "Phone Case"
        //        });
        //    }

        //    foreach (var i in t) {
        //        ps.Add(new Product() {
        //            Id = i.Id,
        //            Name = i.Name,
        //            Price = i.Price * 0.76,
        //            Type = "T-Shirt"
        //        });
        //    }

        //    return ps;
        //}

        //public static List<Product> GetInEuros() {
        //    var l = new LawnmowerRepository().GetAll();
        //    var p = new PhoneCaseRepository().GetAll();
        //    var t = new TShirtRepository().GetAll();

        //    var ps = new List<Product>();

        //    foreach (var i in l) {
        //        ps.Add(new Product() {
        //            Id = i.Id,
        //            Name = i.Name,
        //            Price = i.Price * 0.67,
        //            Type = "Lawnmower"
        //        });
        //    }

        //    foreach (var i in p) {
        //        ps.Add(new Product() {
        //            Id = i.Id,
        //            Name = i.Name,
        //            Price = i.Price * 0.67,
        //            Type = "Phone Case"
        //        });
        //    }

        //    foreach (var i in t) {
        //        ps.Add(new Product() {
        //            Id = i.Id,
        //            Name = i.Name,
        //            Price = i.Price * 0.67,
        //            Type = "T-Shirt"
        //        });
        //    }

        //    return ps;
        //}

        #endregion
    }

}
