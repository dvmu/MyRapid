'延时等待
On Error Resume Next

'循环3次 3秒
For i = 0 To 3  Step 1

FileReplace "MyRapid.Client.exe.txt" ,"MyRapid.Client.exe.config"
FileReplace "MyRapid.Launcher2.exe" ,"MyRapid.Launcher.exe"
'延时1秒
WScript.Sleep 1000
Next

'
Function FileDelete(delFile)
  Set oFSO = CreateObject("Scripting.FileSystemObject") 
  If oFSO.FileExists(delFile) Then 
      oFSO.DeleteFile(delFile)
  End If
  If oFSO.FolderExists(delFile) Then
      oFSO.DeleteFolder delFile,True
  End If
End Function

Function FileReplace(oldFile ,NewFile)
  Set oFSO = CreateObject("Scripting.FileSystemObject") 
  If oFSO.FileExists(oldFile) Then 
    If oFSO.FileExists(NewFile) Then
      oFSO.DeleteFile(NewFile)
    End If
    Set File = oFSO.GetFile(oldFile)
    '重命名文件
    File.name= NewFile
  End If
End Function

Function FileLink(linkFile ,linkName) 
  SET oFSO = CreateObject("Scripting.FileSystemObject")
  If oFSO.FileExists(linkFile) Then 
    Set linkDir = oFSO.GetFile(Wscript.ScriptName).ParentFolder
    Set WshShell = WScript.CreateObject("WScript.Shell")
    strDesktop = WshShell.SpecialFolders("Desktop") '特殊文件夹“桌面”
    '在桌面创建一个快捷方式
    set oShellLink = WshShell.CreateShortcut(strDesktop & "\" & linkName & ".lnk")
    oShellLink.TargetPath = linkDir & "\" & linkFile  '可执行文件路径
    oShellLink.Arguments = "" '程序的参数
    oShellLink.WindowStyle = 1 '参数1默认窗口激活，参数3最大化激活，参数7最小化
    oShellLink.Hotkey = ""  '快捷键
    oShellLink.IconLocation = linkDir & "\" & linkFile & ", 0"  '图标
    oShellLink.Description = ""  '备注
    oShellLink.WorkingDirectory = linkDir  '起始位置
    oShellLink.Save  '创建保存快捷方式
  End If
End Function

'删除自己
SET oFSO = CreateObject("Scripting.FileSystemObject")
oFSO.DeleteFile(WScript.ScriptName)

