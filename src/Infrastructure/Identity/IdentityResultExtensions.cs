using azure_native_3tier_app.Application.Common.Models;
using Microsoft.AspNetCore.Identity;

namespace azure_native_3tier_app.Infrastructure.Identity;

public static class IdentityResultExtensions
{
    public static Result ToApplicationResult(this IdentityResult result)
    {
        return result.Succeeded
            ? Result.Success()
            : Result.Failure(result.Errors.Select(e => e.Description));
    }
}
