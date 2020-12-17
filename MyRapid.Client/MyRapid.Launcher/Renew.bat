@ECHO OFF
powershell.exe -command "ls '*.*' | foreach-object { $_.LastWriteTime =  Get-Date ; $_.CreationTime = Get-Date }"
