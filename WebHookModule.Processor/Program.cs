using System;
using Topshelf;

namespace WebHookModule.Processor
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

			HostFactory.Run(x =>
			                	{
			                		x.Service<ProcessorService>(s =>
			                		                            	{
			                		                            		s.ConstructUsing(service => new ProcessorService());
			                		                            		s.WhenStarted(tc => tc.Start());
			                		                            		s.WhenStopped(tc => tc.Stop());
			                		                            	});
			                		x.RunAsLocalSystem();

			                		x.SetDescription("WebHookModule.Processor message subscriber.");
			                		x.SetDisplayName(Keys.DisplayName);
			                		x.SetServiceName(Keys.DisplayName);
			                	});
		}


		private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			var exc = e.ExceptionObject as Exception;
			if (exc != null)
			{
				//LogMessageHelper.LogError(exc, Keys.DisplayName);
			}
			else
			{
				//LogMessageHelper.LogError("UnhandledException", string.Format("UnhandledException from {0}.", sender.GetType().FullName), null);
			}

			Environment.Exit(-1);
		}
	}
}