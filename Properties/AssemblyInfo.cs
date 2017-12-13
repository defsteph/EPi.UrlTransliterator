using System.Reflection;
using System.Runtime.InteropServices;

using EPiServer.PlugIn;

[assembly: AssemblyTitle("URL Transliteration")]
[assembly: AssemblyDescription("URL Transliteration for EPiServer CMS")]
[assembly: AssemblyCompany("@defsteph")]
[assembly: AssemblyCopyright("Copyright 2017")]
[assembly: AssemblyProduct("EPi.UrlTransliterator")]
[assembly: ComVisible(false)]
[assembly: Guid("4206e11f-3084-48b7-9ec3-203d2e5edbb2")]
[assembly: AssemblyVersion("2.0.1.0")]
[assembly: AssemblyFileVersion("2.0.1.0")]
[assembly: PlugInSummary(MoreInfoUrl = "<A href='https://github.com/defsteph/EPi.UrlTransliterator'>GitHub Repository</A>", License = LicensingMode.Freeware)]
#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif