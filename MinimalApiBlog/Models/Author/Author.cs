namespace MinimalApiBlog.Models.Author;

public class Author
{
    public Author(string name, string description, string profilePictureUrl, List<SocialLink> links)
    {
        Name = name;
        Description = description;
        ProfilePictureUrl = profilePictureUrl;
        Links = links;
    }

    public string Name { get; set; }
    public string Description { get; set; }
    public string ProfilePictureUrl { get; set; }
    public List<SocialLink> Links { get; set; }
    
}