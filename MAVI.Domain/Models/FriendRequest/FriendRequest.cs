namespace MAVI.Domain.Models.FriendRequest
{
    public class FriendRequest : BaseEntity
    {
        public string Img { get; set; }  = string.Empty;
        public string Name { get;  set; } = string.Empty;
        public int Mutual { get;  set; } = 0;

        public void UpdateMutual(int newCount)
        {
            Mutual = newCount;
        }
    }
}
