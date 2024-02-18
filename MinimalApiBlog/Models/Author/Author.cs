namespace MinimalApiBlog.Models.Author;

public record Author(string Name, string Description, string ProfilePictureUrl, List<SocialLink> Links)
{
    public string Name { get; set; } = Name;
    public string Description { get; set; } = Description;
    public string ProfilePictureUrl { get; set; } = ProfilePictureUrl;
    public List<SocialLink> Links { get; set; } = Links;
}