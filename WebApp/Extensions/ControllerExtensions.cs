using Microsoft.AspNetCore.Mvc;

namespace WebApp.Extensions;

public static class ControllerExtensions
{
    public static string? GetCurrentUserId(this ControllerBase controller)
    {
        return controller.User.Claims.FirstOrDefault(claim => claim.Type == "id")?.Value;
    }
}