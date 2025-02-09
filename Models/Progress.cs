namespace LearningVocab.Models
{
    public class Progress
    {
        public string UserId { get; set; }
        public int WordId { get; set; }
        public int Status { get; set; }
        public string Extension { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime ModifyAt { get; set; }
    }
}
