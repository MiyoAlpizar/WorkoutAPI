using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WorkoutAPI
{
    public static class HttpContextExtensions
    {
        public async static Task InsertPaginationParams<T>(this HttpContext httpContext, IQueryable<T> queryable, int registersPerPage)
        {
            double quantity = await queryable.CountAsync();
            double pagesQuantity = Math.Ceiling(quantity / registersPerPage);
            httpContext.Response.Headers.Add("pagesQuantity", pagesQuantity.ToString());
        }

        public static string GetUserId(this HttpContext httpContext)
        {
            return httpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
        }

        public static bool IsUserOwner(this HttpContext httpContext, string id)
        {
            var user = httpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            if (user == null) return false;
            else
                return user == id;
        }

    }
}
