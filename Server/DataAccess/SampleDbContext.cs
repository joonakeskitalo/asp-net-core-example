using System;
using System.Collections.Generic;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Server.DomainModel;

namespace Server.DataAccess
{
    public class SampleDbContext : DbContext
    {
        public SampleDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            FakeData.Init(512);

            modelBuilder.Entity<Artist>().HasData(FakeData.Artists);
            modelBuilder.Entity<Album>().HasData(FakeData.Albums);
            modelBuilder.Entity<Song>().HasData(FakeData.Songs);
            modelBuilder.Entity<Genre>().HasData(FakeData.Genres);
            modelBuilder.Entity<User>().HasData(FakeData.Users);
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }

    public static class FakeData
    {
        public static List<Album> Albums = new List<Album>();
        public static List<Artist> Artists = new List<Artist>();
        public static List<Song> Songs = new List<Song>();
        public static List<User> Users = new List<User>();
        public static List<Genre> Genres = new List<Genre>();

        private static Faker f;

        public static void Init(int count)
        {
            f = new Faker();

            GenerateUsers(count);
            GenerateGenres(count);
            GenerateArtists(count);
        }

        private static void GenerateGenres(int genreCount)
        {
            for (var i = 0; i < genreCount; i++)
            {
                var genre = new Genre
                {
                    Id = Guid.NewGuid(),
                    Name = f.Music.Genre()
                };

                Genres.Add(genre);
            }
        }

        private static void GenerateUsers(int userCount)
        {
            for (var i = 0; i < userCount; i++)
            {
                var user = new User
                {
                    Id = Guid.NewGuid(),
                    Name = f.Name.FullName(),
                    Email = f.Internet.ExampleEmail(),
                    Password = f.Random.AlphaNumeric(32),
                    CreatedOn = DateTime.UtcNow,
                    UpdatedOn = DateTime.UtcNow
                };

                Users.Add(user);
            }
        }

        private static void GenerateArtists(int artistCount)
        {
            for (var i = 0; i < artistCount; i++)
            {
                var artist = new Artist
                {
                    Id = Guid.NewGuid(),
                    Name = f.Name.FullName()
                };

                Artists.Add(artist);

                var albumCount = 3;
                GenerateAlbums(artist, albumCount);
            }
        }

        private static void GenerateAlbums(Artist artist, int albumCount)
        {
            for (var i = 0; i < albumCount; i++)
            {
                var album = new Album
                {
                    Id = Guid.NewGuid(),
                    Name = f.Name.LastName(),
                    ArtistId = artist.Id
                };

                Albums.Add(album);
                GenerateSongs(album, artist, 12);
            }
        }

        private static void GenerateSongs(Album album, Artist artist, int songCount)
        {
            for (var i = 0; i < songCount; i++)
            {
                var song = new Song
                {
                    Id = Guid.NewGuid(),
                    Name = f.Name.LastName(),
                    AlbumId = album.Id,
                    ArtistId = artist.Id
                };

                Songs.Add(song);
            }
        }

    }
}