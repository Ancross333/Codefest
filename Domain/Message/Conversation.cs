
using Domain.User;

namespace Domain.Message
{
	public record Conversation
	{
		public ProfilePicture ProfilePicture { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int OtherUserId { get; set; }
	}
}
