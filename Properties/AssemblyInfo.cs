using System.Reflection;
using System.Runtime.InteropServices;

using EPiServer.PlugIn;

[assembly: AssemblyTitle("URL Transliteration")]
[assembly: AssemblyDescription("URL Transliteration for EPiServer CMS")]
[assembly: AssemblyCompany("Creuna AB")]
[assembly: AssemblyCopyright("Copyright 2016 Creuna AB")]
[assembly: AssemblyProduct("EPi.UrlTransliterator")]
[assembly: ComVisible(false)]
[assembly: Guid("4206e11f-3084-48b7-9ec3-203d2e5edbb2")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: PlugInSummary(MoreInfoUrl = "<A href='https://github.com/CreunaAB/EPi.UrlTransliterator'>GitHub Repository</A>", License = LicensingMode.Freeware)]
#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif