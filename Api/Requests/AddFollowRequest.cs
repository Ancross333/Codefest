namespace Api.Requests
{
	public class AddFollowRequest
	{
        public int FolloweeId { get; set; }
        public int FollowerId { get; set; }
    }
}
