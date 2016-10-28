$vsVersion = "14.0"
$regKey = "HKLM:\software\Microsoft\MSBuild\ToolsVersions\$vsVersion"
$regProperty = "MSBuildToolsPath"

$msbuildExe = join-path -path (Get-ItemProperty $regKey).$regProperty -childpath "msbuild.exe"

&$msbuildExe EPi.UrlTransliterator.csproj /t:Build /p:Configuration="Release46"
&$msbuildExe EPi.UrlTransliterator.csproj /t:Build /p:Configuration="Release452"
.\NuGet.exe pack EPi.UrlTransliterator.csproj -OutputDirectory "Build" -Build -Properties Configuration=Release461