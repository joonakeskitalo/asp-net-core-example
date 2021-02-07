using SampleEndpointApp.DomainModel;

namespace Sample.Api.DomainModel
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
