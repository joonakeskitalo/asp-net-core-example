using System;

namespace Server.Endpoints.v1.UserEndpoints
{
    public class CreateUserCommand
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedOn {get; set;} = DateTime.Now;
        public DateTime UpdatedOn {get; set;} = DateTime.Now;
    }
}
