namespace MAVI.Domain.Models.Post
{
    public class Post : BaseEntity
    {
        public string UserPhoto { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public DateTime Time { get; set; }
        public string Photo { get; set; } = string.Empty;

        public List<string> LikesPhotos { get; set; } = [];
        public string LikedBy { get; set; } = string.Empty;

        public string Caption { get; set; } = string.Empty;
        public string Tag { get; set; } = string.Empty;

        public string CommentsText { get; set; } = string.Empty;

        public int LikesCount => LikesPhotos.Count;

        public void UpdateCaption(string caption)
        {
            Caption = caption;
        }

        public void UpdateTag(string tag)
        {
            Tag = tag;
        }
    }
}
