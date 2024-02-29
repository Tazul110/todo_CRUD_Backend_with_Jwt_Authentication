using Todo_backEnd.Model.LogIn_UsersModel;

using Todo_backEnd.Model.TodoModel;

namespace Todo_backEnd.Model.LogInResponseModel
{
    public class LogInResponse
    {
        public int StatusCode { get; set; }
        public string? StatusMessage { get; set; }

        public Users? Users { get; set; }

        public List<Users>? listUsers { get; set; }
    }
}
