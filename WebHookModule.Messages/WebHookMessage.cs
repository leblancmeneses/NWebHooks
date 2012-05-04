using NServiceBus;

namespace WebHookModule.Messages
{
	public class WebHookMessage : IMessage
	{
		public string Url { get; set; }

		public CompletedMessage PayLoad { get; set; }
	}
}