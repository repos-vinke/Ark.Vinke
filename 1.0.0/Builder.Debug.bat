@echo off

:: Debug

echo Builder Debug
echo:

echo Copying dependencies...
xcopy /e /y .\Dependencies\ ..\..\..\Debug\ >> nul
del ..\..\..\Debug\.gitkeep >>nul 2>>&1
echo:

cd .\Modules\Ark.Vinke.Library\Sources\
call .\Ark.Vinke.Library.Builder.Debug.bat
cd ..\..\..\

cd .\Modules\Ark.Vinke.Framework\Sources\
call .\Ark.Vinke.Framework.Builder.Debug.bat
cd ..\..\..\

cd .\Modules\Ark.Vinke.Facilities\Sources\
call .\Ark.Vinke.Facilities.Builder.Debug.bat
cd ..\..\..\

cd .\Modules\Ark.Vinke.System\Sources\
call .\Ark.Vinke.System.Builder.Debug.bat
cd ..\..\..\

cd .\Modules\Ark.Vinke\Sources\
call .\Ark.Vinke.Builder.Debug.bat
cd ..\..\..\
