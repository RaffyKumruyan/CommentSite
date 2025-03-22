namespace CommentSite.Models
{
    public class Comment
    {
        public string Name { get; set; }
        public string Message { get; set; }
        public DateTime PostedAt { get; set; } = DateTime.Now;
    }
}