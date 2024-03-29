@SET EXCEL_FOLDER=.\xlsx\
@SET JSON_FOLDER=..\Assets\Resources\Json\
@SET C_FOLDER=..\Assets\script\modle\AutoModel\
@SET C2_FOLDER=..\Assets\script\modle\proxy\AutoProxy\
@SET EXE=.\excel2json\excel2json.exe
ECHO 注意,该文件运行需要关闭excel文件
@ECHO Converting excel files in folder %EXCEL_FOLDER% ...
for /f "delims=" %%i in ('dir /b /a-d /s %EXCEL_FOLDER%\*.xlsx') do (
    @echo   processing %%~nxi 
    @CALL %EXE% --excel %EXCEL_FOLDER%\%%~nxi --json %JSON_FOLDER%\%%~ni.json --header 3 --array true --cell_json true
    @CALL %EXE% --excel %EXCEL_FOLDER%\%%~nxi --csharp %C_FOLDER%\%%~ni.cs --header 3
    @CALL %EXE% --excel %EXCEL_FOLDER%\%%~nxi --csharp2 %C2_FOLDER%\%%~ni.cs --header 3
)