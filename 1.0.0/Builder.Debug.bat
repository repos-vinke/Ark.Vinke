@echo off

:: Debug

echo Builder Debug
echo:
echo Copying dependencies...
echo:
xcopy /e /y .\Dependencies\ ..\..\..\Debug\ >> nul
del ..\..\..\Debug\.gitkeep >>nul 2>>&1

cd .\Modules\Ark.Vinke.Library\Sources\
call .\Ark.Vinke.Library.Builder.Debug.bat
cd ..\..\..\
