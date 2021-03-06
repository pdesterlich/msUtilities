set pathBase=%CD%\..

call localvars.cmd

call "%pathMsBuildInit%"

cd %pathBase%

rem aggiorno la versione - release
rem msUtilities
%pathAssemblyVersionUpdater%\assemblyVersionUpdater.exe -inc:3 msUtilities.20\Properties\AssemblyInfo.cs
%pathAssemblyVersionUpdater%\assemblyVersionUpdater.exe -inc:3 msUtilities.35\Properties\AssemblyInfo.cs
%pathAssemblyVersionUpdater%\assemblyVersionUpdater.exe -inc:3 msUtilities.452\Properties\AssemblyInfo.cs
rem msUtilities.Database
%pathAssemblyVersionUpdater%\assemblyVersionUpdater.exe -inc:3 msUtilities.Database.20\Properties\AssemblyInfo.cs
%pathAssemblyVersionUpdater%\assemblyVersionUpdater.exe -inc:3 msUtilities.Database.35\Properties\AssemblyInfo.cs
%pathAssemblyVersionUpdater%\assemblyVersionUpdater.exe -inc:3 msUtilities.Database.452\Properties\AssemblyInfo.cs
rem msUtilities.Database.Forms.Wpf
%pathAssemblyVersionUpdater%\assemblyVersionUpdater.exe -inc:3 msUtilities.Database.Forms.Wpf.35\Properties\AssemblyInfo.cs
%pathAssemblyVersionUpdater%\assemblyVersionUpdater.exe -inc:3 msUtilities.Database.Forms.Wpf.452\Properties\AssemblyInfo.cs

rem eseguo una pulizia delle directory
msbuild /t:clean /p:configuration=Release

rem compilo i due progetti
msbuild /t:build /p:configuration=Release

cd %pathBase%\_build

call dist.cmd