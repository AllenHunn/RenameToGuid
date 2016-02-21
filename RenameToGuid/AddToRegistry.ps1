$mypath = '"' + $PSScriptRoot + '\RenameToGuid.exe" "%1"'
$mypathExt = '"' + $PSScriptRoot + '\RenameToGuid.exe" "%w"'
New-PSDrive -Name HKCR -PSProvider Registry -Root HKEY_CLASSES_ROOT | Out-Null
New-Item -Path HKCR:Directory\shell\RenameToGuid\command -Value $mypath –Force
New-Item -Path HKCR:Directory\Background\shell\RenameToGuid\command -Value $mypathExt –Force
New-Item -Path HKCR:*\shell\RenameToGuid\command -Value $mypath –Force