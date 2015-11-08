using System;
using System.Collections.Generic;
using System.Linq;
using LookingForGroup.Models;
using LookingForGroup.ViewModels;

namespace LookingForGroup.Providers
{
    public class Provider : IDisposable
    {
        private readonly BloggingContext _context;

        public Provider()
        {
            _context=new BloggingContext();
        }

        public string CreateGroup(GroupViewModel viewModel)
        {
            var group = new Group
            {
                Description = viewModel.Description,
                FestivalId = viewModel.FestivalId,
                FestivalName = viewModel.FestivalName,
                GroupName = viewModel.GroupName,
                GroupSize = viewModel.GroupSize,
                LimitDate = viewModel.LimitDate,
                RoomBooked = !string.IsNullOrEmpty(viewModel.RoomId),
                RoomId = viewModel.RoomId,
                TransportBooked = viewModel.HasTransport
            };
            var groups = new List<Group> {@group};
            var admin = new Member
            {
                EmailAddress = viewModel.Email,
                Groups = groups
            };
            var party = new Party {GroupInfo = group, Leader = admin, Password = viewModel.Password};
            if (_context.Groups.Any(e=>e.GroupName.Equals(group.GroupName)))
            {
                return "A group with that name allready exists";
            }
            if (!_context.Members.Any(e => e.EmailAddress.Equals(admin.EmailAddress)))
            {
                _context.Members.Add(admin);
            }
            _context.Groups.Add(group);
            _context.Parties.Add(party);
            _context.SaveChanges();
            return null;
        }

        public string JoinParty(int partyId, string email)
        {
            var party = _context.Parties.FirstOrDefault(e => e.PartyId.Equals(partyId));
            if (party == null)
            {
                return "Party does not exist";
            }
            var member = _context.Members.FirstOrDefault(e => e.EmailAddress.Equals(email));
            if (member == null)
            {
                member = new Member {EmailAddress = email, Groups = new List<Group>()};
                _context.Members.Add(member);
            }
            if (party.PartyMembers.Count >= party.GroupInfo.GroupSize)
            {
                return "Party is full";
            }
            member.Groups.Add(party.GroupInfo);
            party.PartyMembers.Add(member);
            _context.SaveChanges();
            return null;
        }

        public string EditGroup(GroupViewModel viewModel)
        {
            var group = _context.Groups.FirstOrDefault(e => e.GroupId.Equals(viewModel.GroupId));
            if (group == null)
            {
                return "Group does not exist";
            }
            foreach (Group groupToCompare in _context.Groups)
            {
                if (ComapreGroups(viewModel, groupToCompare))
                {
                    return "A group with this name allready exists";
                }
            }
            group.Description = viewModel.Description;
            group.FestivalId = viewModel.FestivalId;
            group.FestivalName = viewModel.FestivalName;
            group.GroupName = viewModel.GroupName;
            group.GroupSize = viewModel.GroupSize;
            group.LimitDate = viewModel.LimitDate;
            group.RoomBooked = !string.IsNullOrEmpty(viewModel.RoomId);
            group.RoomId = viewModel.RoomId;
            group.TransportBooked = viewModel.HasTransport;
            _context.SaveChanges();
            return null;
        }

        private static bool ComapreGroups(GroupViewModel viewModel, Group existingGroup)
        {
            return existingGroup.GroupName.Equals(viewModel.GroupName) && !existingGroup.GroupId.Equals(viewModel.GroupId) &&
                   existingGroup.FestivalName.Equals(viewModel.FestivalName);
        }

        public string CanEditGroup(int partyId, string email, string password)
        {
            var party = _context.Parties.FirstOrDefault(e => e.PartyId.Equals(partyId));
            if (party == null)
            {
                return "Party does not exist";
            }
            if (!party.Leader.EmailAddress.Equals(email))
            {
                return "Your are not the leader of this party";
            }
            if (!party.Password.Equals(password))
            {
                return "Invalid password";
            }
            return null;
        }
        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }


        public IEnumerable<Party> QuerryByFestival(string festivalId)
        {
            var parties = _context.Parties.Where(e => e.GroupInfo.FestivalId.Equals(festivalId));
            return parties;
        }
    }
}