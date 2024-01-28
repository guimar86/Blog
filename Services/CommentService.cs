using AutoMapper;
using BlogApi.Data;
using BlogApi.Models;
using BlogApi.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Services;

public class CommentService : IComments
{
    private readonly BlogDbContext _dbContext;
    private readonly IMapper _mapper;

    public CommentService(BlogDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<CommentDto>> ListCommentsByBlog(int postId)
    {
        var blog = await _dbContext.BlogPosts.FirstOrDefaultAsync(p => p.Id.Equals(postId));
        if (blog == null)
        {
            throw new Exception("Blog not found");
        }

        var comments = _dbContext.Comments.Where(c => c.BlogPost.Equals(blog));

        var mappedComments = _mapper.Map<List<CommentDto>>(comments);

        return mappedComments;
    }

    public async Task CreateComment(CreateCommentDto commentDto)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(p => p.Id.Equals(commentDto.Author)) ??
                   throw new RecordNotFoundException("Invalid comment author");
        var blog = await _dbContext.BlogPosts.FirstOrDefaultAsync(p => p.Id.Equals(commentDto.BlogPost)) ??
                   throw new RecordNotFoundException("Invalid blog post");

        var comment = _mapper.Map<Comment>(commentDto);
        comment.Author = user;
        comment.BlogPost = blog;
        comment.CreatedAt = DateTime.UtcNow;
        await _dbContext.AddAsync(comment);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<CommentDto> UpdateComment(int id, UpdateCommentDto commentDto)
    {
        var comment = await _dbContext.Comments
                          .Include(a => a.Author)
                          .Include(b => b.BlogPost)
                          .FirstOrDefaultAsync(p => p.Id == id) ??
                      throw new RecordNotFoundException("Comment does not exist");
        _mapper.Map(commentDto, comment);
        comment.UpdatedAt = DateTime.UtcNow;
        _dbContext.Update(comment);
        await _dbContext.SaveChangesAsync();
        var updatedComment = _mapper.Map<CommentDto>(comment);
        return updatedComment;
    }

    public async Task DeleteComment(int id)
    {
        var comment = await _dbContext.Comments.FirstOrDefaultAsync(p => p.Id == id);
        if (comment != null)
        {
            _dbContext.Remove(comment);
            await _dbContext.SaveChangesAsync();
        }
    }
}