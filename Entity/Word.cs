namespace LearningVocab.Models
{
    public class Word
    {
        public int WordId { get; set; }
        public string WordName { get; set; }
        public string Definition { get; set; }
        public string Description { get; set; }
        public string Pronunciation { get; set; }
        public string Examples { get; set; }
        public int Type { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime ModifyAt { get; set; }
    }
}
