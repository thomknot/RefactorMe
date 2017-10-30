using RefactorMe.DontRefactor.Data.Implementation;
using RefactorMe.DontRefactor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMe.Utility
{
    public static class GetPhoneInstance
    {
        public static IQueryable<Product> _phoneCaseInstance;
        public static IQueryable<Product> GetPhone(PhoneCaseRepository phoneCaseRepository, double exchangeRate)
        {
            if (_phoneCaseInstance == null)
            {
                _phoneCaseInstance = phoneCaseRepository.GetAll().Select(x => new Product
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price * exchangeRate,
                    Type = "Phone Case"
                });
            }

            return _phoneCaseInstance;
        }
    }
}
