using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceSite.Models {
    public class MemberDB {
        public static Member AddMember( Member mem, CommerceContext context ) {
            // Creates insert query
            context.Members.Add(mem);

            // Executes insert query
            context.SaveChanges();

            return mem;
        }
    }
}
