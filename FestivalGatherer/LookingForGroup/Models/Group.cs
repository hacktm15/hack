using System;

namespace LookingForGroup.Models
{
    public class Group
    {
        public string Description { get; set; }
        public bool TransportBooked { get; set; }
        public bool RoomBooked { get; set; }
        public DateTime LimitDate { get; set; }
        public string FestivalId { get; set; }
        public string GroupSize { get; set; }
        public string RoomId { get; set; }
        public string GroupName { get; set; }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Group) obj);
        }
        protected bool Equals(Group other)
        {
            return string.Equals(GroupName, other.GroupName);
        }

        public override int GetHashCode()
        {
            return (GroupName != null ? GroupName.GetHashCode() : 0);
        }
    }
}