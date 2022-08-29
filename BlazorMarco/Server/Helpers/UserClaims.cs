using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MontotoApp.Server.Helpers
{
    public static class UserClaims
    {
        public static string GetUserId(HttpContext httpContext)
        {
            return httpContext.User.FindFirst(
            "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid")?.Value;
        }
        public static string GetUserName(HttpContext httpContext)
        {
            return httpContext.User.FindFirst(
            "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")?.Value;
        }        
        public static string GetUserEmail(HttpContext httpContext)
        {            
            return httpContext.User.FindFirst(
            "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;       
        }
        public static string GetUserSucursal(HttpContext httpContext)
        {
            return httpContext.User.FindFirst(
            "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/locality")?.Value;
        }
        public static string GetUserDepartamento(HttpContext httpContext)
        {
            return httpContext.User.FindFirst(
            "http://schemas.microsoft.com/ws/2008/06/identity/claims/groupsid")?.Value;
        }
        public static string GetUserJefeArea(HttpContext httpContext)
        {
            return httpContext.User.FindFirst(
            "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname")?.Value;
        }
    }
}
