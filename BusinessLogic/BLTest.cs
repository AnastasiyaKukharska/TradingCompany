using DAL.Interfaces;
using DAL.Concrete;
using DTO;
using NUnit.Framework;
using System;
using System.Configuration;

using System.EnterpriseServices;

using System.Runtime.InteropServices;


namespace BusinessLogic
{

    [TestFixture]
    [Transaction(TransactionOption.RequiresNew), ComVisible(true)]
    public class BLTest
    {



        [Test]
        public void AddBasketTest()
        {
            // BasketDal dal = new BasketDal(ConfigurationManager.ConnectionStrings["IMDB"].ConnectionString);
            var b = new BasketDTO
            {
                Title = "BLTest for basket",
                UserID = 1,
                BookID = 1,
                StatusID = 1,
                Author = "BLTest one",
                Price = 100,
                Amount = 1,
                Date = DateTime.Now
            };
            var result = new BasketDTO();
            result.AddBasket(b);
            Assert.IsTrue(result.BasketID != 0, "returned ID should be more than zero");

        }
        [TearDown]
        public void Teardown()
        {
            if (ContextUtil.IsInTransaction)
            {
                ContextUtil.SetAbort();
            }
        }
 
        [Test]
        public void GetBasketTest()
        {
           BasketDAL dal = new BasketDAL(ConfigurationManager.ConnectionStrings["IMDB"].ConnectionString);
           BasketDTO result = new BasketDTO(dal);

            Assert.IsTrue(result.GetBasket(5).BasketID == 5, "Cannot find the item");
        }
    }
}
