using AutoMapper;
using BlogApi.Data;
using BlogApi.Models;
using BlogApi.Models.DTO;

namespace BlogApi.Services;

public class BlogPostService : IBlog
{
    private readonly BlogDbContext _dbContext;
    private readonly ILogger<BlogPostService> _logger;
    private readonly IMapper _mapper;

    public BlogPostService(BlogDbContext dbContext, ILogger<BlogPostService> logger, IMapper mapper)
    {
        _dbContext = dbContext;
        _logger = logger;
        _mapper = mapper;
    }

    public BlogPost CreateBlogPost(CreateBlogPostRequest createBlogPost)
    {
        var blogPostToSave = _mapper.Map<BlogPost>(createBlogPost);
        blogPostToSave.CreatedAt = DateTime.UtcNow;
        _dbContext.BlogPosts.Add(blogPostToSave);
        _dbContext.SaveChanges();

        return blogPostToSave;
    }

    public BlogPost UpdateBlogPost(BlogPostDTO blogPost)
    {
        var existingBlogPost = _dbContext.BlogPosts.FirstOrDefault(bp => bp.Id.Equals(blogPost.Id));

        if (existingBlogPost == null)
        {
            _logger.LogError("Blog to update does not exist {id}", blogPost.Id);
            throw new Exception("Blog post does not exist");
        }

        _mapper.Map(blogPost, existingBlogPost);
        existingBlogPost.UpdatedAt = DateTime.UtcNow;
        _dbContext.BlogPosts.Update(existingBlogPost);
        _dbContext.SaveChanges();
        return existingBlogPost;
    }

    public List<BlogPostDTO> ListBlogPosts()
    {
        var blogPosts = _dbContext.BlogPosts.ToList();
        return _mapper.Map<List<BlogPostDTO>>(blogPosts);
    }

    public BlogPostDTO FindBlogPost(int id)
    {
        var existingBlogPost = _dbContext.BlogPosts.FirstOrDefault(bp => bp.Id.Equals(id));
        if (existingBlogPost == null)
        {
            _logger.LogError("User to find does not exist {id}", id);
            throw new Exception("User to find does not exist");
        }

        var mappedBlogPost = _mapper.Map<BlogPostDTO>(existingBlogPost);
        return mappedBlogPost;
    }

    public void DeleteBlogPost(int blogPostId)
    {
        var existingBlog = _dbContext.BlogPosts.FirstOrDefault(bp => bp.Id.Equals(blogPostId));
        if (existingBlog == null)
        {
            _logger.LogError("Blog to delete does not exist {id}", blogPostId);
            throw new Exception("Blog to delete does not exist");
        }

        _dbContext.BlogPosts.Remove(existingBlog);
        _dbContext.SaveChanges();
    }
}