namespace LearningVocab.Models
{
    public class User
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public string RoleId { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime ModifyAt { get; set; }
    }
}
