using Castle.Windsor;
using Microsoft.Practices.Unity;
using NServiceBus;
using WebHookModule.Messages;

namespace WebHookModule.Scheduler.NSB
{
	public class CompletedMessageHandler : IMessageHandler<CompletedMessage>
	{
		private readonly IBus _nservicebus;

		public CompletedMessageHandler(
			IWindsorContainer windsorContainer,
			IBus nservicebus,
			IUnityContainer unityContainer)
		{
			_nservicebus = nservicebus;
		}

		#region IMessageHandler<CompletedMessage> Members

		public void Handle(CompletedMessage message)
		{
			// batch the request to handle each message individually
			_nservicebus.Send(new WebHookMessage
			                  	{
			                  		PayLoad = message,
			                  		Url = "http://www.robusthaven.com"
			                  	});
		}

		#endregion
	}
}