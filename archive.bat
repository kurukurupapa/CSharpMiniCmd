@echo off

rem set PATH=PATH;C:\Windows\Microsoft.NET\Framework\v3.5
set homedir="%~dp0"
rem set destname=vcsminicmd-%BUILD_NUMBER%
set destname=vcsminicmd-%BUILD_NUMBER%
set destdir=%homedir%\dest\%destname%
set destbindir=%destdir%\bin
set destdocdir=%destdir%\doc

rem echo �r���h...
rem MSBuild minicmd.sln /property:Configuration=Release /t:Rebuild

echo �t�@�C���R�s�[...
mkdir %destdir%
mkdir %destbindir%
mkdir %destdocdir%
copy %homedir%\MiniBack\bin\Release\* %destbindir%\
copy %homedir%\MiniExcel\bin\Release\* %destbindir%\
copy %homedir%\MiniFileList\bin\Release\* %destbindir%\
copy %homedir%\MiniFilePropChanger\bin\Release\* %destbindir%\
copy %homedir%\ReadMe.txt %destbindir%\
del %destbindir%\*.pdb

rem echo �A�[�J�C�u...
rem cd %destdir%\..
rem "%JAVA_HOME%\bin\jar.exe" cvfM %destname%.zip %destname%

echo �����o�b�`���s��A���̎菇�����{���Ă��������B
rem echo �E�f�B���N�g��[%destdir%]��ZIP���k���Ă��������B
echo �ESourceForge.jp�փ��O�C�����Ă��������B
echo �E�_�E�����[�h���Ǘ�����AVisualC#MiniCommands�p�b�P�[�W�̐V�K�쐬�����N���N���b�N���A
echo �@�쐬����ZIP�t�@�C�����A�b�v���[�h���Ă��������B

rem pause
