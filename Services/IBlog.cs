using BlogApi.Models;
using BlogApi.Models.DTO;

namespace BlogApi.Services;

public interface IBlog
{
    BlogPost CreateBlogPost(BlogPostCreateDTO blogPost);
    BlogPost UpdateBlogPost(BlogPostDTO blogPost);
    List<BlogPostDTO> ListBlogPosts();

    BlogPostDTO FindBlogPost(int id);
    void DeleteBlogPost(int blogPostId);
}