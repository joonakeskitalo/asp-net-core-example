namespace Server.Endpoints.v1.UserEndpoints
{
    public class CreateUserCommand
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
