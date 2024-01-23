using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Net14Web.Models.TaskTracker

{
    public class AddTaskViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
    }
}
