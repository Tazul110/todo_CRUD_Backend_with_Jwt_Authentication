using System.ComponentModel.DataAnnotations;

namespace Todo_backEnd.Model.TodoModel
{
    public class Todo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string? Descrip { get; set; }
        public int IsActive { get; set; }

        public DateTime DueOn { get; set; }

        public DateTime CreatedOn { get; set; }
        public string? Priority { get; set; }
    }
}
