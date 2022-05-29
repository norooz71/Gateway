using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPP.Gateway.Services.Abstractions.Dtos.RoutingDecide
{
    public class UserAuthData
    {
        public IEnumerable<string> CSRF{ get; set; }

        public User User{ get; set; }
    }

    public class User
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Role { get; set; }
    }
}
