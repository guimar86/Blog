namespace BlogApi.Models;

public class Comment
{
    //Properties: Content, CreatedAt, UpdatedAt, User (Author), BlogPost 

    public int Id { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public User Author { get; set; }
    public BlogPost BlogPost { get; set; }
}