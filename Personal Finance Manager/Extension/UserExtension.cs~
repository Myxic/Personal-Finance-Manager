using System;
using System.Security.Claims;

namespace Personal_Finance_Manager.Extension
{
    public static class UserExtension
    {
        public static string? GetUserId(this ClaimsPrincipal user)
        {
            return user.FindFirst("Id")?.Value;
        }
    }
}

