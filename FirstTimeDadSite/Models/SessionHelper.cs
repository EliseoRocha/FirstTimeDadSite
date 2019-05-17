using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTimeDadSite.Models
{
    /// <summary>
    /// Helper class to provide easy access 
    /// to the current HttpContext (Sessions and cookies)
    /// </summary>
    public static class SessionHelper
    {
        private const string MemberIdKey = "Id";

        /// <summary>
        /// Create session for the user and store their MemberId
        /// </summary>
        public static void LogUserIn(IHttpContextAccessor context, int memberId)
        {
            context.HttpContext.Session.SetInt32(MemberIdKey, memberId);
        }

        /// <summary>
        /// Returns true if the user has a session created
        /// </summary>
        public static bool IsUserLoggedIn(IHttpContextAccessor context)
        {
            if (context.HttpContext.Session.GetInt32(MemberIdKey).HasValue)
            {
                return true;
            }

            return false;
        }
    }
}
