using Microsoft.AspNetCore.Authorization;

namespace FunctionalService
{
    public class Policy
    {
        public static AuthorizationPolicy GetPolicy(string roleName)
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(roleName).Build();
        }
    }
}
