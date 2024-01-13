namespace BlogApi.Models.DTO;

public class CreateCommentDto
{
    public string Content { get; set; }
    public int Author { get; set; }
    public int BlogPost { get; set; }
}