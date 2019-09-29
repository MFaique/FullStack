using System.Collections.Generic;

namespace BackEnd.DTO
{
    public class UserClaims
    {
        public int id { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string linkedin { get; set; }
        public string facebook { get; set; }
        public IEnumerable<string> roles { get; set; }
    }
}