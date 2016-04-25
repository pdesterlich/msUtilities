set pathBase=%CD%\..

call localvars.cmd

call "%pathMsBuildInit%"

cd %pathBase%

rem aggiorno la versione
%pathAssemblyVersionUpdater%\assemblyVersionUpdater.exe -inc:3 msUtilities\Properties\AssemblyInfo.cs
%pathAssemblyVersionUpdater%\assemblyVersionUpdater.exe -inc:3 msUtilities_452\Properties\AssemblyInfo.cs
%pathAssemblyVersionUpdater%\assemblyVersionUpdater.exe -inc:3 msDatabaseUtilities_20\Properties\AssemblyInfo.cs
%pathAssemblyVersionUpdater%\assemblyVersionUpdater.exe -inc:3 msDatabaseUtilities_452\Properties\AssemblyInfo.cs

rem eseguo una pulizia delle directory
msbuild /t:clean /p:configuration=Release

rem compilo i due progetti
msbuild /t:build /p:configuration=Release

cd %pathBase%\_build