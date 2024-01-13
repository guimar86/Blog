namespace BlogApi.Models.DTO;

public class CommentDto
{
    public int Id { get; set; }
    public string Content { get; set; }
    public User Author { get; set; }
    public BlogPost BlogPost { get; set; }
}