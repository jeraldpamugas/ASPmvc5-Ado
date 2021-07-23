﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPmvc5_Ado.Models
{
    public class UserProfile
    {
        [Display(Name = "Id")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        public Boolean IsActive { get; set; }
    }
}