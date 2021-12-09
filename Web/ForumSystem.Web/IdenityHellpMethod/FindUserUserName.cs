namespace ForumSystem.Web.IdenityHellpMethod
{
    using System.Security.Claims;

    public static class FindUserUserName
    {
        public static string GetUserId(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
