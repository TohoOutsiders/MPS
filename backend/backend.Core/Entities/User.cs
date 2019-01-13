using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace backend.Core.Entities
{
    public class User
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        [MaxLength(64)]
        public string NickName { get; set; }
        /// <summary>
        /// 用户名(登陆名)
        /// </summary>
        [MaxLength(64)]

        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [MaxLength(64)]

        public string Password { get; set; }
        /// <summary>
        /// 用户角色
        /// </summary>
        public CustomEnum.UserRole UserRole { get; set; }
    }
}
