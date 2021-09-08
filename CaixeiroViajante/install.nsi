Unicode true

!include "MUI2.nsh"

!define PRODUCT_NAME "CaixeiroViajante"
!define PRODUCT_PUBLISHER "CaixeiroViajante"
 
; MUI Settings
!define MUI_ABORTWARNING
!define MUI_ICON "${NSISDIR}\Contrib\Graphics\Icons\modern-install.ico"
!define MUI_UNICON "${NSISDIR}\Contrib\Graphics\Icons\modern-uninstall.ico"

; Installer pages
!insertmacro MUI_PAGE_WELCOME
!insertmacro MUI_PAGE_DIRECTORY
!insertmacro MUI_PAGE_INSTFILES
!insertmacro MUI_PAGE_FINISH

; Uninstaller pages
!insertmacro MUI_UNPAGE_CONFIRM
!insertmacro MUI_UNPAGE_INSTFILES
!insertmacro MUI_UNPAGE_FINISH

; Language files
!insertmacro MUI_LANGUAGE "PortugueseBR"

; MUI end ------

Name "${PRODUCT_NAME}"
OutFile "..\dist\CaixeiroViajanteInstall.exe"
ShowInstDetails show
ShowUnInstDetails show
SetCompress auto
InstallDir "$DESKTOP\CaixeiroViajante"
RequestExecutionLevel user

Function .onInit
FunctionEnd

Section "Principal" SEC01
  SetOutPath "$INSTDIR"
  AllowSkipFiles off
  File /r "dist\*"
SectionEnd

Section -Post
  WriteUninstaller "$INSTDIR\uninst.exe"
SectionEnd

Section Uninstall
  # remove todos os arquivos da pasta de instalacao
  RMDir /r "$INSTDIR"

SectionEnd
 
Section "Desktop Shortcut" SectionX

  SetShellVarContext current

  CreateShortCut "$Desktop\CaixeiroViajante.lnk" "$INSTDIR\CaixeiroViajante.exe"

SectionEnd