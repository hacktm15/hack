using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LookingForGroup.Models
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }
        public virtual List<Group> Groups { get; set; }
        public string EmailAddress { get; set; }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Member) obj);
        }
        protected bool Equals(Member other)
        {
            return string.Equals(EmailAddress, other.EmailAddress);
        }

        public override int GetHashCode()
        {
            return (EmailAddress != null ? EmailAddress.GetHashCode() : 0);
        }

    }
}