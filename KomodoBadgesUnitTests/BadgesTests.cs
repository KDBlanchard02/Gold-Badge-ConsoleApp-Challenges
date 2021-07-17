using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using KomodoBadgesApp;
using static KomodoBadgesApp.BadgeRepository;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static KomodoBadgesApp.Badge;
using System.Threading.Tasks;

namespace KomodoBadgesTests
{
    [TestClass]
    public class BadgesTests
    {
        private BadgeRepository _repo;
        private Badge _badge;

        [TestInitialize]
        public void Arrange()
        {
            string[] doorAccess = { "A7", "A8", "A9" };
            List<string> DoorAccess = new List<string>(doorAccess);
            int BadgeID = 3;

            _repo = new BadgeRepository();
            _badge = new Badge(3, "Kevin", DoorAccess);

            _repo.CreateNewBadge(BadgeID, _badge);
        }


        [TestMethod]
        public void SetBadgeId_ShouldSetCorrectInt()
        {
            //arrange
            Badge badge = new Badge();

            //act
            badge.BadgeId = 3;
            int expected = 3;
            int actual = badge.BadgeId;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreateNewBadge_IsNotNull()
        {
            //arrange
            int BadgeID = 3;
            Badge badge = new Badge();
            BadgeRepository badgeRepository = new BadgeRepository();

            //act
            badgeRepository.CreateNewBadge(BadgeID, badge);
            Badge newBadge = badgeRepository.GetBadgeByID(BadgeID);

            //assert
            Assert.IsNotNull(newBadge);
        }

        [TestMethod]
        public void AddDoorsToBadge_AreDifferent()
        {
            //arrange
            string[] doorAccess = { "A7", "A8", "A9", "A10"};
            List<string> DoorAccess = new List<string>(doorAccess);

            Badge updatedBadge = new Badge(3, "Kevin", DoorAccess);

            //act
            _repo.AddBadgeDoorAccess(3, "A10");

            //assert
            Assert.AreNotSame(_badge, updatedBadge);
        }

        [TestMethod]
        public void RemoveDoorsFromBadge_AreDifferent()
        {
            //arrange
            string[] doorAccess = { "A7", "A8"};
            List<string> DoorAccess = new List<string>(doorAccess);

            Badge updatedBadge = new Badge(3, "Kevin", DoorAccess);

            //act
            _repo.RemoveBadgeDoorAccess(3, "A9");

            //assert
            Assert.AreNotSame(_badge, updatedBadge);
        }

        [TestMethod]
        public void RemoveAllDoorsFromBadge_IsEmpty()
        {
            //arrange
            string[] doorAccess = {};
            List<string> DoorAccess = new List<string>(doorAccess);

            Badge updatedBadge = new Badge(3, "Kevin", DoorAccess);

            //act
            _repo.DeleteAllDoorsFromBadge(3);

            //assert
            Assert.AreNotSame(_badge, updatedBadge);
        }

        [TestMethod]
        public void DisplayBadges_IsNotNull()
        {
            //arrange

            //act
            _repo.ShowAllBadges();

            //assert
            Assert.IsNotNull(_repo.ShowAllBadges());
        }
    }
}
