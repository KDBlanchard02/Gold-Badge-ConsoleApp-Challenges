using Microsoft.VisualStudio.TestTools.UnitTesting;
using KomodoCafeApp;

namespace KomodoCafeApp
{
    [TestClass]
    public class CafeTests
    {
        private MenuRepository _repo;
        private Menu _menu;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuRepository();
            _menu = new Menu(9, "Classic Gyro", "An impossible-not-to-love flavor explosion.", 7.99);

            _repo.CreateMenuItem(_menu);
        }

        [TestMethod]
        public void SetBadgeId_ShouldSetCorrectInt()
        {
            //act
            _menu.Number = 9;
            int expected = 9;
            int actual = _menu.Number;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreateMenuItem_IsNotNull()
        {
            //arrange

            //act
            _repo.CreateMenuItem(_menu);

            //assert
            Assert.IsNotNull(_menu);
        }

        [TestMethod]
        public void DeleteMenuItem_IsTrue()
        {
            //arrange

            //act
            bool deleteResult = _repo.DeleteMenuItemByNumber(_menu.Number);

            //assert
            Assert.IsTrue(deleteResult);
        }

        [TestMethod]
        public void DisplayMenu_IsNotNull()
        {
            //arrange

            //act
            _repo.DisplayMenuItems();

            //assert
            Assert.IsNotNull(_repo.DisplayMenuItems());
        }

        [TestMethod]
        public void GetMenuByNumber_IsNotNull()
        {
            //arrange

            //act
            Menu menu = _repo.GetMenuItemByNumber(_menu.Number);

            //assert
            Assert.IsNotNull(menu);
        }
    }
}
