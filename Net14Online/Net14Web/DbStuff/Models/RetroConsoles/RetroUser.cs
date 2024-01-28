﻿using Net14Web.Models.RetroConsoles;
using System;

namespace Net14Web.DbStuff.Models.RetroConsoles
{
    public class RetroUser : BaseModel
    {
        public string? Login { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public virtual List<ConsolesRetroUser> ConsolesRetroUsers { get; set; } = new List<ConsolesRetroUser>();
    }
}

