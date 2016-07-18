set pathBase=%CD%\..

call localvars.cmd

call "%pathMsBuildInit%"

cd %pathBase%

rem eseguo una pulizia delle directory
msbuild /t:clean /p:configuration=Release

rem compilo i due progetti
msbuild /t:build /p:configuration=Release

cd %pathBase%\_build

call dist.cmd