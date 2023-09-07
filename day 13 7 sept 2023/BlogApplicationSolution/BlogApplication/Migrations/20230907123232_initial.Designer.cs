﻿// <auto-generated />
using System;
using BlogApplication.BlogContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BlogApplication.Migrations
{
    [DbContext(typeof(BContexts))]
    [Migration("20230907123232_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BlogApplication.Models.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AuthorId"));

                    b.Property<string>("AuthorsName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Pic")
                        .HasColumnType("text");

                    b.HasKey("AuthorId");

                    b.ToTable("authors");

                    b.HasData(
                        new
                        {
                            AuthorId = 1,
                            AuthorsName = "ABC",
                            Description = "full time Blooger",
                            Email = "abc@gmail.com",
                            Pic = "/images/pic1.png"
                        },
                        new
                        {
                            AuthorId = 2,
                            AuthorsName = "DEF",
                            Description = "Bloger on Social Media",
                            Email = "def@gmail.com",
                            Pic = "/images/pic2.png"
                        });
                });

            modelBuilder.Entity("BlogApplication.Models.BlogPost", b =>
                {
                    b.Property<int>("BlogPostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BlogPostId"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<string>("BPost")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TagId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("BlogPostId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("TagId");

                    b.ToTable("blogPosts");

                    b.HasData(
                        new
                        {
                            BlogPostId = 1,
                            AuthorId = 1,
                            BPost = "blog, in full Web log or Weblog, online journal where an individual, group, or corporation presents a record of activities, thoughts, or beliefs. Some blogs operate mainly as news filters, collecting various online sources and adding short comments and Internet links. Other blogs concentrate on presenting original material. In addition, many blogs provide a forum to allow visitors to leave comments and interact with the publisher. “To blog” is the act of composing material for a blog. Materials are largely written, but pictures, audio, and videos are important elements of many blogs. The “blogosphere” is the online universe of blogs.",
                            TagId = 1,
                            Title = "Blog"
                        },
                        new
                        {
                            BlogPostId = 2,
                            AuthorId = 2,
                            BPost = "The tiger has a muscular body with strong forelimbs, a large head and a tail that is about half the length of its body. Its pelage colouration varies between shades of orange with a white underside and distinctive vertical black stripes; the patterns of which are unique in each individual",
                            TagId = 2,
                            Title = "Tiger"
                        });
                });

            modelBuilder.Entity("BlogApplication.Models.CategoryTag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TagId"));

                    b.Property<int?>("BlogPostId")
                        .HasColumnType("integer");

                    b.Property<string>("TagTitle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("TagId");

                    b.HasIndex("BlogPostId");

                    b.ToTable("categoryTags");

                    b.HasData(
                        new
                        {
                            TagId = 1,
                            TagTitle = "Social"
                        },
                        new
                        {
                            TagId = 2,
                            TagTitle = "animal"
                        },
                        new
                        {
                            TagId = 3,
                            TagTitle = "country"
                        });
                });

            modelBuilder.Entity("BlogApplication.Models.BlogPost", b =>
                {
                    b.HasOne("BlogApplication.Models.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlogApplication.Models.CategoryTag", "CategoryTag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("CategoryTag");
                });

            modelBuilder.Entity("BlogApplication.Models.CategoryTag", b =>
                {
                    b.HasOne("BlogApplication.Models.BlogPost", null)
                        .WithMany("Tags")
                        .HasForeignKey("BlogPostId");
                });

            modelBuilder.Entity("BlogApplication.Models.BlogPost", b =>
                {
                    b.Navigation("Tags");
                });
#pragma warning restore 612, 618
        }
    }
}
