@echo off

:: Release

echo Builder Release
echo:
echo Copying dependencies...
echo:
xcopy /e /y .\Dependencies\ ..\..\..\Release\ >> nul
del ..\..\..\Release\.gitkeep >>nul 2>>&1

cd .\Modules\Ark.Vinke.Library\Sources\
call .\Ark.Vinke.Library.Builder.Release.bat
cd ..\..\..\

cd .\Modules\Ark.Vinke.Framework\Sources\
call .\Ark.Vinke.Framework.Builder.Release.bat
cd ..\..\..\
