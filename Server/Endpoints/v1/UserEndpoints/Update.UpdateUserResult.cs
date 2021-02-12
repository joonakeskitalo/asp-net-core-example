using System;
namespace Server.Endpoints.v1.UserEndpoints
{
    public class UpdateUserResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
