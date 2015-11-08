using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LookingForGroup.Models
{
    public class Party
    {
        [Key]
        public int PartyId { get; set; }
        public string Password { get; set; }
        public virtual Group GroupInfo { get; set; }
        public virtual Member Leader { get; set; }
        public virtual List<Member> PartyMembers { get; set; }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Party) obj);
        }
        protected bool Equals(Party other)
        {
            return string.Equals(PartyId, other.PartyId);
        }

        public override int GetHashCode()
        {
            return PartyId.GetHashCode();
        }
    }
}