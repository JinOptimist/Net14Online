﻿using Net14Web.DbStuff.Models.Movies;

namespace Net14Web.DbStuff.Models
{
    public class Alert : BaseModel
    {
        public string Message { get; set; }

        public virtual User Creater {  get; set; }

        public virtual List<User> NotifiedUsers { get; set; }
    }
}
