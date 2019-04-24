using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using backend.Core.Customers;

namespace backend.Core.Entities
{
    [Table("user")]
    public class User: Entity
    {
        [Column("user_name"), MaxLength(64)]
        public string UserName { get; set; }
        [Column("nick_name"), MaxLength(64)]
        public string NickName { get; set; }
        [Column("phone"), MaxLength(64)]
        public string Phone { get; set; }
        [Column("email"), MaxLength(64)]
        public string Email { get; set; }   
        [Column("is_verify_phone")]
        public CustomerEnum.Verification IsVerifyPhone { get; set; }    
        [Column("is_verify_email")]
        public CustomerEnum.Verification IsVerifyEmail { get; set; }
        [Column("password"), MaxLength(64)]
        public string Password { get; set; }
        [Column("user_role")]
        public CustomerEnum.UserRole UserRole { get; set; }
    }
}
