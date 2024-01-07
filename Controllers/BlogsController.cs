using BlogApi.Models;
using BlogApi.Models.DTO;
using BlogApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers;

[ApiController]
[Route("api/blogs")]
public class BlogsController : ControllerBase
{
    private readonly IBlog _blogService;

    public BlogsController(IBlog blogService)
    {
        _blogService = blogService;
    }

    [HttpGet]
    public IActionResult List()
    {
        return Ok(_blogService.ListBlogPosts());
    }

    [HttpPost]
    public IActionResult CreateBlogPost([FromBody] BlogPostCreateDTO blogPostCreateDto)
    {
        var blogPost = _blogService.CreateBlogPost(blogPostCreateDto);

        return Created("", blogPost);
    }

    [HttpPut]
    public IActionResult UpdateBlogPost([FromBody] BlogPost blogPost)
    {
        var updatedBlogPost = _blogService.UpdateBlogPost(blogPost);
        return Ok(updatedBlogPost);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public IActionResult DeleteBlogPost(int id)
    {
        _blogService.DeleteBlogPost(id);
        return Ok();
    }
}