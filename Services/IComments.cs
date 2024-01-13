using BlogApi.Models;
using BlogApi.Models.DTO;

namespace BlogApi.Services;

public interface IComments
{
    Task<List<CommentDto>> ListCommentsByBlog(int postId);
    Task CreateComment(CreateCommentDto commentDto);
    Task<CommentDto> UpdateComment(int id, UpdateCommentDto commentDto);
    Task DeleteComment(int id);
}