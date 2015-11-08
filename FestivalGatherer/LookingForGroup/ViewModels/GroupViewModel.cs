using System;

namespace LookingForGroup.ViewModels
{
    public class GroupViewModel
    {
        public int GroupId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RoomId { get; set; }
        public string FestivalId { get; set; }
        public int GroupSize { get; set; }
        public string GroupName { get; set; }
        public DateTime LimitDate { get; set; }
        public string Description { get; set; }
        public string FestivalName { get; set; }
        public bool HasTransport { get; set; }
    }
}