namespace CarWorkshop.Application.ApplicationUser;

public class CurrentUser
{
    public string Id { get; set; }
    public string Email { get; set; }
    public IEnumerable<string> Roles { get; set; }

    public CurrentUser(string id, string email, IEnumerable<string> roles)
    {
        Email = email;
        Id = id;
        Roles = roles;
    }

    public bool IsInRole(string role)
    {
        return Roles.Contains(role);
    }
}