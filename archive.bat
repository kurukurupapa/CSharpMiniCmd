@echo off

rem set PATH=PATH;C:\Windows\Microsoft.NET\Framework\v3.5
set homedir="%~dp0"
rem set destname=vcsminicmd-%BUILD_NUMBER%
set destname=vcsminicmd-%BUILD_NUMBER%
set destdir=%homedir%\dest\%destname%
set destbindir=%destdir%\bin
set destdocdir=%destdir%\doc

rem echo ビルド...
rem MSBuild minicmd.sln /property:Configuration=Release /t:Rebuild

echo ファイルコピー...
mkdir %destdir%
mkdir %destbindir%
mkdir %destdocdir%
copy %homedir%\MiniBack\bin\Release\* %destbindir%\
copy %homedir%\MiniExcel\bin\Release\* %destbindir%\
copy %homedir%\MiniFileList\bin\Release\* %destbindir%\
copy %homedir%\MiniFilePropChanger\bin\Release\* %destbindir%\
copy %homedir%\ReadMe.txt %destbindir%\
del %destbindir%\*.pdb

rem echo アーカイブ...
rem cd %destdir%\..
rem "%JAVA_HOME%\bin\jar.exe" cvfM %destname%.zip %destname%

echo ■当バッチ実行後、次の手順を実施してください。
rem echo ・ディレクトリ[%destdir%]をZIP圧縮してください。
echo ・SourceForge.jpへログインしてください。
echo ・ダウンロード＞管理から、VisualC#MiniCommandsパッケージの新規作成リンクをクリックし、
echo 　作成したZIPファイルをアップロードしてください。

rem pause
