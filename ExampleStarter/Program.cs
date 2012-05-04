using System;
using NServiceBus;
using WebHookModule.Messages;

namespace ExampleStarter
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			IBus bus = Configure.With()
				.Log4Net()
				.DefaultBuilder()
				.XmlSerializer()
				.MsmqTransport()
				.IsTransactional(true)
				.PurgeOnStartup(false)
				.UnicastBus()
				.ImpersonateSender(false)
				.LoadMessageHandlers()
				.CreateBus()
				.Start();

			while (true)
			{
				Console.WriteLine("Press enter to send CompletedMessage.");
				Console.WriteLine(
					"Scheduler should pick it up and for each registered url send a WebHookMessage to the Processor service.");
				Console.ReadLine();

				var m = new CompletedMessage {Id = 1};

				bus.Send(m);
			}
		}
	}
}