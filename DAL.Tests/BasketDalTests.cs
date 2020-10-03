using DAL.Concrete;
using NUnit.Framework;
using System.EnterpriseServices;
using System.Linq;
using System.Configuration;
using DTO;
using System.Runtime.InteropServices;

namespace DAL.Tests
{
    [TestFixture]
    [Transaction(TransactionOption.RequiresNew), ComVisible(true)]
    public class BasketDalTests : ServicedComponent
    {

        [Test]
        public void CreateTest()
        {
            BasketDal dal = new BasketDal(ConfigurationManager.ConnectionStrings["IMDB"].ConnectionString);
            var result = dal.CreateBasket(new BasketDTO
            {
                Title = "Test for basket",
                UserID = 1,
                BookID = 1,
                StatusID = 1,
                Author = "Test one",
                Price = 100,
                Amount = 1,
                Date = DateTime.Now
            });
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
        public void GetAllTest()
        {
            BasketDal dal = new BasketDal(ConfigurationManager.ConnectionStrings["IMDB"].ConnectionString);
            var result = dal.CreateBasket(new BasketDTO
            {
                Title = "Test for all baskets",
                UserID = 1,
                BookID = 1,
                StatusID = 1,
                Author = "Test one",
                Price = 100,
                Amount = 1,
                Date = DateTime.Now
            });
            var movies = dal.GetAllBaskets();
            Assert.AreEqual(1, movies.Count(x => x.Title == "get all baskets"));
        }

        

    }
}
