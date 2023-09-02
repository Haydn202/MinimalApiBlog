namespace MinimalApiBlog.Models.Author;

public abstract class SocialLink
{
    protected SocialLink(string linkUrl, SocialLinkType type)
    {
        LinkUrl = linkUrl;
        Type = type;
    }

    public string LinkUrl { get; set; }
    public SocialLinkType Type { get; set; }
}