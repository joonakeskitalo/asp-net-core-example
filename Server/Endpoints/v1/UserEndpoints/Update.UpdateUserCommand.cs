using System;
namespace Server.Endpoints.v1.UserEndpoints
{
    public class UpdateUserCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
