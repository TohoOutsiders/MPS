using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Api.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string UserName { get; set; }
        public string NickName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
