using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class UserFollowing
    {
        public string ObserverId { get; set; } = null!;
        public AppUser Observer { get; set; } = null!;
        public string TargetId { get; set; } = null!;
        public AppUser Target { get; set; } = null!;
    }
}