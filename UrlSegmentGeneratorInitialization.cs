using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using EPiServer.Web;

namespace EPi.UrlTransliterator {
	[ModuleDependency(typeof(ServiceContainerInitialization)), InitializableModule]
	public class UrlSegmentGeneratorInitialization : IConfigurableModule {
		void IConfigurableModule.ConfigureContainer(ServiceConfigurationContext context) {
			context.Services.RemoveAll(typeof(IUrlSegmentGenerator));
			context.Services.AddSingleton<IUrlSegmentGenerator, TransliteratingUrlSegmentGenerator>();
		}
		void IInitializableModule.Initialize(InitializationEngine context) { }
		void IInitializableModule.Uninitialize(InitializationEngine context) { }
	}
}