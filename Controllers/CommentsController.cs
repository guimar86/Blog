using BlogApi.Models.DTO;
using BlogApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers;

[ApiController]
[Route("api/comments")]
public class CommentsController : ControllerBase
{
    private readonly IComments _commentService;

    public CommentsController(IComments commentService)
    {
        _commentService = commentService;
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> List([FromRoute] int id)
    {
        var comments = await _commentService.ListCommentsByBlog(id);
        return Ok(comments);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCommentDto commentDto)
    {
        await _commentService.CreateComment(commentDto);
        return Ok();
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentDto commentDto)
    {
        var updatedComment = await _commentService.UpdateComment(id, commentDto);
        return Ok(updatedComment);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _commentService.DeleteComment(id);
        return Ok();
    }
}