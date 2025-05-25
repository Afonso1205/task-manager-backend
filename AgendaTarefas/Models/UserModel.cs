namespace AgendaTarefas.Models
{
    public class UserModel
    {
        public required string Id { get; set; }
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
    }
}
