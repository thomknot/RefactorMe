using RefactorMe.DontRefactor.Data.Implementation;
using RefactorMe.DontRefactor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMe.Utility
{
    public static class GetTshirtInstance
    {
        public static IQueryable<Product> _tshirtInstance;
        public static IQueryable<Product> GetTShirt(TShirtRepository tShirtRepository, double exchangeRate)
        {
            if (_tshirtInstance == null)
            {
                _tshirtInstance = tShirtRepository.GetAll().Select(x => new Product
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price * exchangeRate,
                    Type = "T-Shirt"
                });
            }

            return _tshirtInstance;
        }
    }
}
