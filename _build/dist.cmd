del dist\*.zip

mkdir _temp
mkdir _temp\it

call dist_clean.cmd

rem msUtilities.20
copy "..\msUtilities.20\bin\Release\msUtilities.20.*" ".\_temp"
copy "..\msUtilities.20\bin\Release\it\*.dll" ".\_temp\it"
copy "..\msUtilities.Database.20\bin\Release\msUtilities.Database.20.*" ".\_temp"

cd _temp
"%path7z%\7z.exe" a -tzip -mx ..\_dist\msUtilities.20.zip *.dll *.pdb it\*.dll
cd ..

call dist_clean.cmd

rem msUtilities.35
copy "..\msUtilities.35\bin\Release\msUtilities.35.*" ".\_temp"
copy "..\msUtilities.35\bin\Release\it\*.dll" ".\_temp\it"
copy "..\msUtilities.Database.35\bin\Release\msUtilities.Database.35.*" ".\_temp"
copy "..\msUtilities.Database.Forms.Wpf.35\bin\Release\msUtilities.Database.Forms.Wpf.35.*" ".\_temp"

cd _temp
"%path7z%\7z.exe" a -tzip -mx ..\_dist\msUtilities.35.zip *.dll *.pdb it\*.dll
cd ..

call dist_clean.cmd

rem msUtilities.452
copy "..\msUtilities.452\bin\Release\msUtilities.452.*" ".\_temp"
copy "..\msUtilities.452\bin\Release\it\*.dll" ".\_temp\it"
copy "..\msUtilities.Database.452\bin\Release\msUtilities.Database.452.*" ".\_temp"
copy "..\msUtilities.Database.Forms.Wpf.452\bin\Release\msUtilities.Database.Forms.Wpf.452.*" ".\_temp"

cd _temp
"%path7z%\7z.exe" a -tzip -mx ..\_dist\msUtilities.452.zip *.dll *.pdb it\*.dll
cd ..

call dist_clean.cmd
