using NServiceBus;

namespace WebHookModule.Messages
{
	public class CompletedMessage : IMessage
	{
		public int Id { get; set; }
	}
}