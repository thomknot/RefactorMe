using RefactorMe.DontRefactor.Data;
using RefactorMe.DontRefactor.Data.Implementation;
using RefactorMe.DontRefactor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMe
{
   public class NinjectBinding : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {

            ////   Bind(typeof(IReadOnlyRepository<>)).To(typeof(BaseReadOnlyRepository<>));
            //Bind(typeof(BaseReadOnlyRepository<PhoneCase>)).To<PhoneCaseRepository>();
            //Bind(typeof(BaseReadOnlyRepository<Lawnmower>)).To<LawnmowerRepository>();
            //Bind(typeof(BaseReadOnlyRepository<TShirt>)).To<TShirtRepository>();
            ////  Bind<PhoneCaseRepository>().To<IReadOnlyRepository(  PhoneCase)>);
        }
    }
}
