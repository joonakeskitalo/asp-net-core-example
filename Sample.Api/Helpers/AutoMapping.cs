using AutoMapper;
using Sample.Api.DomainModel;
using Sample.Api.Endpoints.v1.UserEndpoints;

namespace Sample.Api.Helpers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<CreateUserCommand, User>();
            CreateMap<UpdateUserCommand, User>();
            CreateMap<User, CreateUserResult>();
            CreateMap<User, UpdateUserResult>();
            CreateMap<User, UserListResult>();
            CreateMap<User, UserResult>();
        }
    }
}
