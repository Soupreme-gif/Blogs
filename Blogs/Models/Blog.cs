namespace Blogs.Models;

public class Blog
{
    public int BlogId {get;set;}
    public string Name { get; set; }

    // entity framework relationship
    // Navigation Properties
    public virtual List<Post> Posts {get;set;}
}