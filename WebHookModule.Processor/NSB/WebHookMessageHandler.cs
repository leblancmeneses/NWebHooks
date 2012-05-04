using System;
using NServiceBus;
using WebHookModule.Messages;

namespace WebHookModule.Processor.NSB
{
	public class WebHookMessageHandler : IMessageHandler<WebHookMessage>
	{
		#region IMessageHandler<WebHookMessage> Members

		public void Handle(WebHookMessage message)
		{
			// Use RestSharp to post to URL
			// - and handle authentication
			throw new NotImplementedException();
		}

		#endregion
	}
}