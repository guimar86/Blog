namespace BlogApi.Models.DTO;

public class CommentCreateDTO
{
    public string Content { get; set; }
    public User Author { get; set; }
    public BlogPost BlogPost { get; set; }
}