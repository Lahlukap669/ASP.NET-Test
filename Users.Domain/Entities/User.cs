namespace Users.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = default!;
        public string FullName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Mobile { get; set; } = default!;
        public string Language { get; set; } = default!;
        public string Culture { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
