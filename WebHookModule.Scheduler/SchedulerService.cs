using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Microsoft.Practices.Unity;
using NServiceBus;

namespace WebHookModule.Scheduler
{
	public class SchedulerService
	{
		public void Start()
		{
			var unityContainer = new UnityContainer();
			IWindsorContainer container = GetContainer(unityContainer);

			//container.Kernel.ReleasePolicy = new MyReleasePolicy();

			IBus bus = Configure.With()
				.Log4Net()
				.CastleWindsorBuilder(container)
				.XmlSerializer()
				.MsmqTransport()
				.IsTransactional(true)
				.PurgeOnStartup(false)
				.UnicastBus()
				.ImpersonateSender(false)
				.LoadMessageHandlers()
				.CreateBus()
				.Start();


			unityContainer.RegisterInstance(bus);
		}

		public void Stop()
		{
			//LogMessageHelper.LogInformation(Keys.DisplayName, "stopped", null);
		}

		private IWindsorContainer GetContainer(IUnityContainer unityContainer)
		{
			IWindsorContainer container = new WindsorContainer();
			container.Register(
				Component.For<IUnityContainer>().Instance(unityContainer),
				Component.For<IWindsorContainer>().Instance(container)
				);

			return container;
		}
	}
}