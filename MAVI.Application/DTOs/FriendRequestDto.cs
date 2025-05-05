namespace MAVI.Application.DTOs
{
    public class FriendRequestDto
    {
        public int Id { get; set; }
        public string Img { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Mutual { get; set; } 
    }
}
