using Microsoft.AspNetCore.Mvc;

namespace WebApp.Extensions;

public static class ControllerExtensions
{
    public static Guid? GetCurrentUserId(this ControllerBase controller)
    {
        var idString = controller.User.Claims.FirstOrDefault(claim => claim.Type == "id")?.Value;
        return idString == null ? null : Guid.Parse(idString);
    }
}