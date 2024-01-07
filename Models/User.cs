namespace BlogApi.Models;

public class User
{
    public virtual int Id { get; set; }
    public virtual string Username { get; set; }
    public virtual string Email { get; set; }
    public virtual DateTime CreatedAt { get; set; }
    public virtual DateTime UpdatedAt { get; set; }
}