using Microsoft.Extensions.Configuration;

public class AppSettings
{

    public string StringConnection { get; } = null!;
    public string Password { get; } = null!;
    public string Url { get; set; } = null!;
    public Dictionary<string,string> Services { get; } = null!;
    public string UserId {get;}  = null!;
    public Dictionary<string,string> Actions { get; } = null!;
}