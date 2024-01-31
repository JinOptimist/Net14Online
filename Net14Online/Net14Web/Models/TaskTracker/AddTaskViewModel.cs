using Microsoft.AspNetCore.Mvc.Rendering;
using Net14Web.Models.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace Net14Web.Models.TaskTracker

{
    public class AddTaskViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Введите название")]
        [TaskTrackerValidation(ErrorMessage = "Название не должно содержать символы <>&")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Введите описание")]
        [TaskTrackerValidation(ErrorMessage = "Описание не должно содержать символы <>&")]
        public string? Description { get; set; }
        public int Priority { get; set; }
        public List<int>? PriorityOptions { get; set; }

    }
}
