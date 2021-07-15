using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimsApp
{
    class ClaimsRepository
    {
        //CRUD

        private readonly List<Claim> claims = new List<Claim>();

        //Create

        public void CreateClaim(Claim claim)
        {
            claims.Add(claim);
        }

        //Read
        
        public List<Claim> SeeAllClaims()
        {
            return claims;
        }

        //Delete
        public void DeleteClaim(Claim claim)
        {
            claims.Remove(claim);
        }
    }
}
