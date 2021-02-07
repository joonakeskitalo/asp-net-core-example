using AutoMapper;
using Sample.Api.DomainModel;
using Sample.Api.Endpoints.v1.UserEndpoints;
using Sample.Api.Endpoints.v1.AlbumEndpoints;
using Sample.Api.Endpoints.v1.SongEndpoints;
using Sample.Api.Endpoints.v1.ArtistEndpoints;

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

            CreateMap<CreateSongCommand, Song>();
            CreateMap<CreateSongResult, Song>();
            CreateMap<Song, CreateSongResult>();
            CreateMap<Song, UpdateSongResult>();
            CreateMap<Song, SongListResult>();
            CreateMap<Song, SongResult>();

            CreateMap<CreateArtistCommand, Artist>();
            CreateMap<CreateArtistResult, Artist>();
            CreateMap<Artist, CreateArtistResult>();
            CreateMap<Artist, UpdateArtistResult>();
            CreateMap<Artist, ArtistListResult>();
            CreateMap<Artist, ArtistResult>();
        }
    }
}
