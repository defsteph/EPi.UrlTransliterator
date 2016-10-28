using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using EPiServer.Web;

namespace EPi.UrlTransliterator {
	[ModuleDependency(typeof(ServiceContainerInitialization)), InitializableModule]
	public class UrlSegmentGeneratorInitialization : IConfigurableModule {
		void IConfigurableModule.ConfigureContainer(ServiceConfigurationContext context) {
			context.Container.Configure(x => x.For<IUrlSegmentGenerator>().Use<TransliteratingUrlSegmentGenerator>());
		}
		void IInitializableModule.Initialize(InitializationEngine context) { }
		void IInitializableModule.Uninitialize(InitializationEngine context) { }
	}
}