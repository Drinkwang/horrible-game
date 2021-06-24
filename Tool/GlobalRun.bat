@SET EXCEL_FOLDER=.\xlsx\
@SET JSON_FOLDER=..\Assets\Resources\Json\
@SET C_FOLDER=..\Assets\script\modle\AutoModel\
@SET EXE=.\excel2json\excel2json.exe

@ECHO Converting excel files in folder %EXCEL_FOLDER% ...
for /f "delims=" %%i in ('dir /b /a-d /s %EXCEL_FOLDER%\*.xlsx') do (
    @echo   processing %%~nxi 
    @CALL %EXE% --excel %EXCEL_FOLDER%\%%~nxi --json %JSON_FOLDER%\%%~ni.json --header 3
    @CALL %EXE% --excel %EXCEL_FOLDER%\%%~nxi --csharp %C_FOLDER%\%%~ni.cs --header 3
)