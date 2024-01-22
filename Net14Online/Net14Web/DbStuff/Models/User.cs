using System;
namespace Net14Web.DbStuff.Models
{
	public class User : BaseModel
	{
        public string Name { get; set; }

        public int Age { get; set; }

        public string KindOfActivity { get; set; }
        
	}
}

