using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Net14Web.Models.TaskTracker
{
    public class TaskViewModel
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Priority { get; set; }
        public string? Owner { get; set; }
        public bool CanDelete { get; set; }
        public string GetImageSource()
        {
            switch (Priority)
            {
                case 1:
                    return "https://media1.giphy.com/media/lRLzrbhmh5pFf4jOga/giphy.gif?cid=ecf05e47npb4sdiuxtpzro6t4axvmzmw8603pspal0t8rvi5&ep=v1_gifs_related&rid=giphy.gif&ct=s";
                case 2: 
                    return "https://media0.giphy.com/media/Tgxr8pn069Sf7mgv0e/giphy.gif?cid=ecf05e47eomc10ib8lngb0aecsa70cw47pvofqjyaye33t5z&ep=v1_gifs_related&rid=giphy.gif&ct=s";
                case 3: 
                    return "https://media2.giphy.com/media/hQd1EyvVrfxu012N4P/giphy.gif?cid=ecf05e47npb4sdiuxtpzro6t4axvmzmw8603pspal0t8rvi5&ep=v1_gifs_related&rid=giphy.gif&ct=s";
                default:
                    return "https://media0.giphy.com/media/Tgxr8pn069Sf7mgv0e/giphy.gif?cid=ecf05e47eomc10ib8lngb0aecsa70cw47pvofqjyaye33t5z&ep=v1_gifs_related&rid=giphy.gif&ct=s";
            }
        }
    }
}
