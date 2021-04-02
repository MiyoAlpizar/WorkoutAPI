﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutAPI.DTOs
{
   
    public class UserInfo
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UserInfoDTO
    {
        public string Email { get; set; }
    }

    public class UserToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }

    public class UserRoleCreateDTO
    {
        public string UserId { get; set; }
        public string RoleName { get; set; }
    }
}
