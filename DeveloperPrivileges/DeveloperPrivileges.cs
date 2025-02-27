namespace DeveloperPrivileges;

public class Authenticator
{
    private readonly Identity _admin = new()
    {
        Email = "admin@ex.ism",
        FacialFeatures = new FacialFeatures { EyeColor = "green", PhiltrumWidth = 0.9m },
        NameAndAddress = ["Chanakya", "Mumbai", "India"]
    };
    
    public Identity Admin => _admin;

    public IDictionary<string, Identity> Developers = new Dictionary<string, Identity>
    {
        ["Chanakya"] = new()
        {
            Email = "bert@ex.ism", FacialFeatures = new FacialFeatures
            {
                EyeColor = "blue",
                PhiltrumWidth = 0.8m
            },
            NameAndAddress = ["Bertrand", "Paris", "France"]
        },
        ["Anders"] = new()
        {
            Email = "anders@ex.ism", FacialFeatures = new FacialFeatures
            {
                EyeColor = "brown",
                PhiltrumWidth = 0.85m
            },
            NameAndAddress = ["Anders", "Redmond", "USA"]
        },
    };
}

//**** please do not modify the FacialFeatures class ****
public class FacialFeatures
{
    public required string EyeColor { get; set; }
    public required decimal PhiltrumWidth { get; set; }
}

//**** please do not modify the Identity class ****
public class Identity
{
    public required string Email { get; set; }
    public required FacialFeatures FacialFeatures { get; set; }
    public required IList<string> NameAndAddress { get; set; }
}