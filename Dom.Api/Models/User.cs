using Microsoft.AspNetCore.Identity;

namespace Dom.Api.Models;

public class AppUser : IdentityUser<long>
{
    public List<IdentityRole<long>>? Roles { get; set; } //RBAC - Role Basic Authentication
}
