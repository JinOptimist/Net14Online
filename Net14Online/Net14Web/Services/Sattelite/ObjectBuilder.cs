using Net14Web.Models.Sattelite;

namespace Net14Web.Services.Sattelite
{
    public class ObjectBuilder
    {
        public Objects BuildRandomObject()
        {
            var objects = new Objects
            {
                Name = "rand",
                Type = "Автомобиль",
                IconURL = "https://cdn-icons-png.flaticon.com/512/263/263057.png"
            };
            return objects;

        }
    }
}
