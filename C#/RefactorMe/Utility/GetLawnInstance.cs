using RefactorMe.DontRefactor.Data.Implementation;
using RefactorMe.DontRefactor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMe.Utility
{
    public static class GetLawnInstance
    {
        public static IQueryable<Product> _lawnmowerInstance;
        public static IQueryable<Product> GetLawnmower(LawnmowerRepository _lawnmowerRepository, double exchangeRate)
        {
            if (_lawnmowerInstance == null)
            {
                _lawnmowerInstance = _lawnmowerRepository.GetAll().Select(x => new Product
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price * exchangeRate,
                    Type = "Lawn Mower"
                });
            }

            return _lawnmowerInstance;
        }
    }
}
