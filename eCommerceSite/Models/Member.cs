using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceSite.Models {
    public class Member {

        [Required] // Data Annotations
        public string UserName { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        // Int is automatically required
        [Key] // 'Primary' Key
        public int MemberID { get; set; }
    }

    public class LoginViewModel {
        public string Email { get; set; }
        public string Password { get; set; }


    }
}
