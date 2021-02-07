using AutoMapper;
using Sample.Api.DomainModel;
using Sample.Api.Endpoints.v1.UserEndpoints;
using Sample.Api.Endpoints.v1.AlbumEndpoints;

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

            CreateMap<CreateAlbumCommand, Album>();
            CreateMap<CreateAlbumResult, Album>();
            CreateMap<Album, CreateAlbumResult>();
            CreateMap<Album, UpdateAlbumResult>();
            CreateMap<Album, AlbumListResult>();
            CreateMap<Album, AlbumResult>();
        }
    }
}
