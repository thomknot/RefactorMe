using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using RefactorMe.DontRefactor.Models;
using RefactorMe;
using RefactorMe.DontRefactor.Data.Implementation;
using Ninject;
using Ninject.Modules;
using System.Reflection;
using System.Linq;
using RefactorMe.Utility;

namespace RefactorMe.Tests
{
    [TestClass]
    public class TestProductDataConsolidator
    {
        public static ProductDataConsolidator _productDataConsolidator;
        public static PhoneCaseRepository _phoneCaseRepository;
        public static LawnmowerRepository _lawnmowerRepository;
        public static TShirtRepository _tShirtRepository;   
        bool isEqual = true;

        [TestInitialize]
        public void MyTestInitialize()
        {
            StandardKernel kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            _phoneCaseRepository = kernel.Get<PhoneCaseRepository>();
            _lawnmowerRepository = kernel.Get<LawnmowerRepository>();
            _tShirtRepository = kernel.Get<TShirtRepository>();

            ProductDataConsolidator _productDataConsolidatorw = new ProductDataConsolidator(_phoneCaseRepository, _lawnmowerRepository, _tShirtRepository);
        }

        [TestMethod()]
        public void ProductWithNoCurrency()
        {
            //Arrange
            var expected = ProductDataConsolidator.Get("");
            expected.ForEach(x => x.Price = x.Price * 1);

            //Act           
            var actual = ProductDataConsolidator.Get("");
            isEqual = CompareList.ComparingList(actual, expected);

            //Assert
            Assert.IsTrue(isEqual);
        }

        [TestMethod()]
        public void ProductWithUSDCurrency()
        {
            //Arrange
            var expected = ProductDataConsolidator.Get("");
            expected.ForEach(x => x.Price = x.Price * 0.76);

            //Act 
            var actual = ProductDataConsolidator.Get("UsDollar");
            isEqual = CompareList.ComparingList(actual, expected);

            //Assert
            Assert.IsTrue(isEqual);
        }

        [TestMethod()]
        public void ProductWithEURO()
        {
            //Arrange
            var expected = ProductDataConsolidator.Get("");
            expected.ForEach(x => x.Price = x.Price * 0.67);

            //Act 
            var actual = ProductDataConsolidator.Get("Euro");
            isEqual = CompareList.ComparingList(actual, expected);

            //Assert
            Assert.IsTrue(isEqual);

        }

    }
}