dotnet publish -c Release -o dist --self-contained true -r win-x64 /p:PublishSingleFile=true

try {
    Get-Command makensis -ErrorAction Stop | Out-Null
}
catch {
    Write-Error 'NSIS compiler not found.' -Category NotInstalled -ErrorAction Stop
}
  
if (Test-Path '..\dist') {
    Get-ChildItem '..\dist' | Remove-Item -Recurse -Force
}
else {
    New-Item -Type Directory '..\dist' | Out-Null
}

Write-Host 'Check build release ...' -ForegroundColor Yellow
if (-not (Test-Path 'dist\CaixeiroViajante.exe')) {
    Write-Error 'Release not found. Try again build release.' -Category NotInstalled -ErrorAction Stop
}

Write-Host 'Building installer...' -ForegroundColor Yellow
makensis install.nsi 

Write-Host "`r`nPronto!" -ForegroundColor Green
Pause
