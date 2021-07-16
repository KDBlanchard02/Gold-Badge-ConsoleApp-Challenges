using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadgesApp
{
    public class Badge
    {
        public int BadgeId { get; set; }
        public string BadgeName { get; set; }
        public List<string> DoorAccess { get; set; }

        public Badge()
        {

        }

        public Badge(int badgeId, string badgeName, List<string> doorAccess)
        {
            BadgeId = badgeId;
            BadgeName = badgeName;
            DoorAccess = doorAccess;
        }
    }
}
