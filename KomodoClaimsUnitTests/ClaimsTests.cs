using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using KomodoClaimsApp;

namespace KomodoClaimsTests
{
    [TestClass]
    public class ClaimsTests
    {
        private ClaimsRepository _repo;
        private Claim _claim;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimsRepository();

            DateTime incidentDate = new DateTime(06/28/2021);
            DateTime claimDate = new DateTime(07 / 16 / 2021);

            _claim = new Claim(4444, Claim.ClaimType.Car, "Test claim", 44.44, incidentDate, claimDate, true);

            _repo.CreateClaim(_claim);
        }

        [TestMethod]
        public void CreateClaim_IsNotNull()
        {
            //arrange

            //act
            _repo.CreateClaim(_claim);

            //assert
            Assert.IsNotNull(_claim);
        }

        [TestMethod]
        public void DeleteClaim_IsNotNull()
        {
            //arrange

            //act
            _repo.DeleteClaim(_claim);

            //assert
            Assert.IsNotNull(_claim);
        }

        [TestMethod]
        public void SeeAllClaims_IsNotNull()
        {
            //arrange

            //act
            _repo.SeeAllClaims();

            //assert
            Assert.IsNotNull(_repo.SeeAllClaims());
        }
    }
}
