namespace BlogApi.Models.DTO;

public class CreateBlogPostRequest
{
    public string Title { get; set; }
    
    public int AuthorId { get; set; }
    public string Content { get; set; }

    
}