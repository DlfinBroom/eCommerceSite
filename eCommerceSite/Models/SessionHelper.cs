using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceSite.Models {
    public static class SessionHelper {

        private const string MemberIdKey = "Id";

        /// <summary>
        /// Create a session for the user and store their MemberID
        /// </summary>
        public static void LogUserIn(int memberID, IHttpContextAccessor context) {
            context.HttpContext.Session.SetInt32(MemberIdKey, memberID);
        }

        /// <summary>
        /// Returns true if the user has a session created
        /// </summary>
        public static Boolean IsUserLogedIn(IHttpContextAccessor context) {
            if(context.HttpContext.Session.GetInt32(MemberIdKey).HasValue){
                return true;
            }
            return false;
        }

        /// <summary>
        /// Gets the number of items in the users shoping cart
        /// </summary>
        public static int GetCartTotal(IHttpContextAccessor accessor) {
            string data = accessor.HttpContext.Request.Cookies["Cart"];
            if (string.IsNullOrEmpty(data)) {
                return 0;
            }
            List<Product> pro = JsonConvert.DeserializeObject<List<Product>>(data);
            return pro.Count;
        }
    }
}
