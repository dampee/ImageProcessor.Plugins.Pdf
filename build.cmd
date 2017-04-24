REM nuget pack

"%ProgramFiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe" ImageProcessor.Plugins.Pdf.csproj /t:Build /p:Configuration="Release45"
"%ProgramFiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe" ImageProcessor.Plugins.Pdf.csproj /t:Build;Package;Publish /p:Configuration="Release461"