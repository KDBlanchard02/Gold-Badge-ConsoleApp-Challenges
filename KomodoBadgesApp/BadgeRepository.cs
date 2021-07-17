using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static KomodoBadgesApp.Badge;
using System.Threading.Tasks;

namespace KomodoBadgesApp
{
    public class BadgeRepository
    {
        //CRUD 

        private readonly Dictionary<int, Badge> _badges = new Dictionary<int, Badge>();

        //Create
        public bool CreateNewBadge(int BadgeID, Badge badge)
        {
            if (BadgeID != 0)
            {
                _badges.Add(BadgeID, badge);
                return true;
            }
            else
            {
                return false;
            }
        }

        //Read
        public Dictionary<int, Badge> ShowAllBadges()
        {
            return _badges;
        }

        public Badge GetBadgeByID(int badgeId)
        {
            foreach (KeyValuePair<int, Badge> item in _badges)
            {
                if (item.Key == badgeId)
                {
                    return item.Value;
                }
            }

            return null;
        }

        //Update

        public void RemoveBadgeDoorAccess(int badgeId, string doorAccess)
        {
            Badge badge = GetBadgeByID(badgeId);

            badge.DoorAccess.Remove(doorAccess);      

        }

        public void AddBadgeDoorAccess(int badgeId, string doorAccessTwo)
        {
            Badge badge = GetBadgeByID(badgeId);

            badge.DoorAccess.Add(doorAccessTwo);
        }


        //Delete


        public void DeleteAllDoorsFromBadge(int badgeId)
        {
            Badge badge = GetBadgeByID(badgeId);

            badge.DoorAccess.Clear();
        }
    }
}
