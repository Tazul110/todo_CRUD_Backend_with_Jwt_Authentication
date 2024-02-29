using Todo_backEnd.Model.TodoModel;
namespace Todo_backEnd.Model.ResponseModel
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string? StatusMessage { get; set; }

        public Todo? Todo { get; set; }

        public List<Todo>? listTodo { get; set; }
    }
}
