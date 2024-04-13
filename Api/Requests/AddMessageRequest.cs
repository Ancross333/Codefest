namespace Api.Requests
{
	public class AddMessageRequest
	{
		public int SenderId { get; set; }
		public int ReceiverId { get; set; }
		public DateTime CreatedAt { get; set; }
		public string Content { get; set; }
	}
}
