using System;
using System.Collections.Generic;
using System.Linq;
using LookingForGroup.Controllers;
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
            if (_context.Groups.Contains(group))
            {
                return "A group with that name allready exists";
            }
            if (!_context.Members.Contains(admin))
            {
                _context.Members.Add(admin);
            }
            _context.Groups.Add(group);
            _context.Members.Add(admin);
            _context.Parties.Add(party);
            _context.SaveChanges();
            return null;
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}