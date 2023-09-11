using BlogApplication.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace BlogApplication.BlogContext
{
    public class BContexts :DbContext
    {
        public BContexts(DbContextOptions options): base(options) 
        
        {
            
        }

        #region CollectionToTable
        public DbSet<Author> authors { get; set; }// author
        public DbSet<BlogPost> blogPosts { get; set; } //blogpost
        public DbSet<CategoryTag> categoryTags { get; set; } // categoryTag
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    Id = 1,
                    AuthorsName = "ABC",
                    Phone = "8856904770",
                    Description = "full time Blooger",
                    Email="abc@gmail.com",
                    Pic = "/images/pic1.png"
                },
                new Author
                {
                    Id = 2,
                    AuthorsName = "DEF",
                    Description = "Bloger on Social Media",
                    Email="def@gmail.com",
                    Phone = "8856904771",
                    Pic = "/images/pic2.png"
                });

            modelBuilder.Entity<CategoryTag>().HasData(
                new CategoryTag
                {
                    Id = 1,
                    TagTitle = "Social"
                },
                new CategoryTag
                {
                    Id = 2,
                    TagTitle="animal"
                },
                new CategoryTag
                {
                    Id = 3,
                    TagTitle="country"
                }

                );
            modelBuilder.Entity<BlogPost>().HasData(
                new BlogPost
                {
                    Id = 1,
                    AuthorsName = "ABC",
                    Title = "Blog",
                    BPost = "blog, in full Web log or Weblog, online journal where an individual, group, or corporation presents a record of activities, thoughts, or beliefs. Some blogs operate mainly as news filters, collecting various online sources and adding short comments and Internet links. Other blogs concentrate on presenting original material. In addition, many blogs provide a forum to allow visitors to leave comments and interact with the publisher. “To blog” is the act of composing material for a blog. Materials are largely written, but pictures, audio, and videos are important elements of many blogs. The “blogosphere” is the online universe of blogs.",
                    //AuthorId = 1,
                    //TagId = 1

                },
            new BlogPost
            {
                Id = 2,
                Title = "Tiger",
                AuthorsName = "DEF",
                BPost = "The tiger has a muscular body with strong forelimbs, a large head and a tail that is about half the length of its body. Its pelage colouration varies between shades of orange with a white underside and distinctive vertical black stripes; the patterns of which are unique in each individual",
                //    AuthorId = 2,
                //    TagId = 2
                //}
            }
            );

        }

    }
}
