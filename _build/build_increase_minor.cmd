set pathBase=%CD%\..

call localvars.cmd

call "%pathMsBuildInit%"

cd %pathBase%

rem aggiorno la versione - minor
%pathAssemblyVersionUpdater%\assemblyVersionUpdater.exe -inc:2 msUtilities.20\Properties\AssemblyInfo.cs
%pathAssemblyVersionUpdater%\assemblyVersionUpdater.exe -inc:2 msUtilities.35\Properties\AssemblyInfo.cs
%pathAssemblyVersionUpdater%\assemblyVersionUpdater.exe -inc:2 msUtilities.452\Properties\AssemblyInfo.cs
%pathAssemblyVersionUpdater%\assemblyVersionUpdater.exe -inc:2 msUtilities.Database.20\Properties\AssemblyInfo.cs
%pathAssemblyVersionUpdater%\assemblyVersionUpdater.exe -inc:2 msUtilities.Database.35\Properties\AssemblyInfo.cs
%pathAssemblyVersionUpdater%\assemblyVersionUpdater.exe -inc:2 msUtilities.Database.452\Properties\AssemblyInfo.cs

rem aggiorno la versione - release
%pathAssemblyVersionUpdater%\assemblyVersionUpdater.exe -inc:3 msUtilities.20\Properties\AssemblyInfo.cs
%pathAssemblyVersionUpdater%\assemblyVersionUpdater.exe -inc:3 msUtilities.35\Properties\AssemblyInfo.cs
%pathAssemblyVersionUpdater%\assemblyVersionUpdater.exe -inc:3 msUtilities.452\Properties\AssemblyInfo.cs
%pathAssemblyVersionUpdater%\assemblyVersionUpdater.exe -inc:3 msUtilities.Database.20\Properties\AssemblyInfo.cs
%pathAssemblyVersionUpdater%\assemblyVersionUpdater.exe -inc:3 msUtilities.Database.35\Properties\AssemblyInfo.cs
%pathAssemblyVersionUpdater%\assemblyVersionUpdater.exe -inc:3 msUtilities.Database.452\Properties\AssemblyInfo.cs

rem eseguo una pulizia delle directory
msbuild /t:clean /p:configuration=Release

rem compilo i due progetti
msbuild /t:build /p:configuration=Release

cd %pathBase%\_build