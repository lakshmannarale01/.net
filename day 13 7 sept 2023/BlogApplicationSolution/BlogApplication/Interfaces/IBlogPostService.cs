using BlogApplication.Models;

namespace BlogApplication.Interfaces
{
    public interface IBlogPostService
    {
        public BlogPost UpdateTitle(BlogPost blogPost);

        public BlogPost UpdateBPost(BlogPost blogPost);

        //public BlogPost UpdateAuthorId(BlogPost blogPost);

        //public BlogPost UpdateTagId(BlogPost blogPost);

        public IList<BlogPost> GetAllBlogPost();
    }
}
