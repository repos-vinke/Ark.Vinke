@echo off

:: Release

echo Builder Release
echo:

echo Copying Defaults...
xcopy /e /y .\Defaults\ ..\..\..\Release\ >> nul
del ..\..\..\Release\.gitkeep >>nul 2>>&1
del ..\..\..\Release\Both\.gitkeep >>nul 2>>&1
del ..\..\..\Release\Client\.gitkeep >>nul 2>>&1
del ..\..\..\Release\Server\.gitkeep >>nul 2>>&1
echo:

cd .\Modules\Ark.Vinke.Library\Sources\
call .\Ark.Vinke.Library.Builder.Release.bat
cd ..\..\..\

cd .\Modules\Ark.Vinke.Framework\Sources\
call .\Ark.Vinke.Framework.Builder.Release.bat
cd ..\..\..\

cd .\Modules\Ark.Vinke.Facilities\Sources\
call .\Ark.Vinke.Facilities.Builder.Release.bat
cd ..\..\..\

cd .\Modules\Ark.Vinke.System\Sources\
call .\Ark.Vinke.System.Builder.Release.bat
cd ..\..\..\

cd .\Modules\Ark.Vinke\Sources\
call .\Ark.Vinke.Builder.Release.bat
cd ..\..\..\
