namespace TcgBindersReloaded.Entities;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Authorization;

public class AdminRoleRequirement : IAuthorizationRequirement
{
    public string RequiredRole { get; }

    public AdminRoleRequirement(string requiredRole)
    {
        RequiredRole = requiredRole;
    }
}

