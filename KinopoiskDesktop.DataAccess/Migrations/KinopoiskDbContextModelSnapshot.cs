﻿// <auto-generated />
using System;
using KinopoiskDesktop.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KinopoiskDesktop.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class KinopoiskDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("KinopoiskDesktop.Domain.Models.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LoggedAt")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<string>("SecondName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("KinopoiskDesktop.Domain.Models.AppUserMovie", b =>
                {
                    b.Property<Guid>("AppUserId")
                        .HasColumnType("TEXT");

                    b.Property<int>("MovieId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsFavorite")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsWatched")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("Rating")
                        .HasColumnType("REAL");

                    b.HasKey("AppUserId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("AppUsersMovies");
                });

            modelBuilder.Entity("KinopoiskDesktop.Domain.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("TEXT");

                    b.Property<int?>("MovieId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("KinopoiskDesktop.Domain.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("TEXT");

                    b.Property<int?>("MovieId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("KinopoiskDesktop.Domain.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("Completed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CoverUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EditorAnnotation")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("EndYear")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FilmLength")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImdbId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("KinopoiskHDId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("KinopoiskId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LogoUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NameEn")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NameOriginal")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NameRu")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PosterUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PosterUrlPreview")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProductionStatus")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RatingAgeLimits")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double?>("RatingFilmCritics")
                        .HasColumnType("REAL");

                    b.Property<int?>("RatingFilmCriticsVoteCount")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("RatingImdb")
                        .HasColumnType("REAL");

                    b.Property<int?>("RatingImdbVoteCount")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("RatingKinopoisk")
                        .HasColumnType("REAL");

                    b.Property<int?>("RatingKinopoiskVoteCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RatingMpaa")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ReviewsCount")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("Serial")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool?>("ShortFilm")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Slogan")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("StartYear")
                        .HasColumnType("INTEGER");

                    b.Property<TimeSpan?>("SyncPeriod")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("SyncedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("WebUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("KinopoiskDesktop.Domain.Models.MovieCountry", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CountryId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MovieId", "CountryId");

                    b.HasIndex("CountryId");

                    b.ToTable("MoviesCountries");
                });

            modelBuilder.Entity("KinopoiskDesktop.Domain.Models.MovieGenre", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GenreId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MovieId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("MoviesGenres");
                });

            modelBuilder.Entity("KinopoiskDesktop.Domain.Models.AppUserMovie", b =>
                {
                    b.HasOne("KinopoiskDesktop.Domain.Models.AppUser", null)
                        .WithMany("AppUserMovies")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KinopoiskDesktop.Domain.Models.Movie", null)
                        .WithMany("MovieAppUsers")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KinopoiskDesktop.Domain.Models.Country", b =>
                {
                    b.HasOne("KinopoiskDesktop.Domain.Models.Movie", null)
                        .WithMany("Countries")
                        .HasForeignKey("MovieId");
                });

            modelBuilder.Entity("KinopoiskDesktop.Domain.Models.Genre", b =>
                {
                    b.HasOne("KinopoiskDesktop.Domain.Models.Movie", null)
                        .WithMany("Genres")
                        .HasForeignKey("MovieId");
                });

            modelBuilder.Entity("KinopoiskDesktop.Domain.Models.MovieCountry", b =>
                {
                    b.HasOne("KinopoiskDesktop.Domain.Models.Country", "Country")
                        .WithMany("MovieCountries")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KinopoiskDesktop.Domain.Models.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("KinopoiskDesktop.Domain.Models.MovieGenre", b =>
                {
                    b.HasOne("KinopoiskDesktop.Domain.Models.Genre", "Genre")
                        .WithMany("MovieGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KinopoiskDesktop.Domain.Models.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("KinopoiskDesktop.Domain.Models.AppUser", b =>
                {
                    b.Navigation("AppUserMovies");
                });

            modelBuilder.Entity("KinopoiskDesktop.Domain.Models.Country", b =>
                {
                    b.Navigation("MovieCountries");
                });

            modelBuilder.Entity("KinopoiskDesktop.Domain.Models.Genre", b =>
                {
                    b.Navigation("MovieGenres");
                });

            modelBuilder.Entity("KinopoiskDesktop.Domain.Models.Movie", b =>
                {
                    b.Navigation("Countries");

                    b.Navigation("Genres");

                    b.Navigation("MovieAppUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
